using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanHang.Models;

namespace BanHang.Controllers
{
    public class CartController : Controller
    {
        dbQLBansachDataContext data = new dbQLBansachDataContext();

        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public List<Cart> GetCart()
        {
            List<Cart> listCart = Session["GioHang"] as List<Cart>;
            if(listCart == null)
            {
                listCart = new List<Cart>();
                Session["GioHang"] = listCart;
            }

            return listCart;
        }
        public ActionResult AddToCart(int id, string strURL)
        {
            List<Cart> listCart = GetCart();

            Cart item = listCart.Find(n => n.MaSach == id);
            if(item == null)
            {
                item = new Cart(id);
                listCart.Add(item);
            }
            else
            {
                item.SoLuong++;
            }
            return Redirect(strURL);
        }

        public int CountQuantity()
        {
            int sum = 0;
            List<Cart> listCart = Session["GioHang"] as List<Cart>;
            if (listCart != null)
                sum = listCart.Sum(n => n.SoLuong);
            return sum;
        }

        public double TotalPrice()
        {
            double total = 0;
            List<Cart> listCart = Session["GioHang"] as List<Cart>;
            if (listCart != null)
                total += listCart.Sum(n => n.ThanhTien);
            return total;
        }
        public ActionResult DisplayCart()
        {
            List<Cart> listCart = GetCart();
            if (listCart.Count == 0)
                return RedirectToAction("Index", "BookStore");

            ViewBag.TongSoLuong = CountQuantity();
            ViewBag.TongThanhTien = TotalPrice();
            return View(listCart);
        }
        public ActionResult UpdateCart(int id, FormCollection collection)
        {
            List<Cart> listCart = GetCart();
            Cart item = listCart.SingleOrDefault(n => n.MaSach == id);
            if (item != null)
                item.SoLuong = int.Parse(collection["txtQuantity"].ToString());
            return RedirectToAction("DisplayCart");
        }
        public ActionResult RemoveCart(int id)
        {
            List<Cart> listCart = GetCart();

            Cart item = listCart.SingleOrDefault(n => n.MaSach == id);

            if(item != null)
            {
                listCart.RemoveAll(n => n.MaSach == id);
                return RedirectToAction("DisplayCart");
            }
            if (listCart.Count == 0)
                return RedirectToAction("Index", "BookStore");

            return RedirectToAction("DisplayCart");
        }
        public ActionResult RemoveAllCart()
        {
            List<Cart> listCart = GetCart();
            listCart.Clear();
            return RedirectToAction("Index", "BookStore");
        }
        public ActionResult CartInfor()
        {
            ViewBag.TongSoLuong = CountQuantity();
            ViewBag.TongThanhTien = TotalPrice();
            return PartialView();
        }
        [HttpGet]
        public ActionResult Order()
        {
            if (Session["TaiKhoan"] == null || String.IsNullOrEmpty(Session["TaiKhoan"].ToString()))
                return RedirectToAction("DangNhap", "User");
            if (Session["GioHang"] == null)
                return RedirectToAction("Index", "BookStore");

            List<Cart> listCart = GetCart();
            ViewBag.TongSoLuong = CountQuantity();
            ViewBag.TongThanhTien = TotalPrice();

            return View(listCart);
        }
        [HttpPost]
        public ActionResult Order(FormCollection collection)
        {
            DONDATHANG ddh = new DONDATHANG();
            KHACHHANG kh = (KHACHHANG)Session["TaiKhoan"];

            List<Cart> listCart = GetCart();
            ddh.MaKH = kh.MaKH;
            ddh.NgayDH = DateTime.Now;
            var ngaygiao = String.Format("{0:MM/DD/YYYY}", collection["NgayGiao"]);
            ddh.Ngaygiaohang = DateTime.Parse(ngaygiao);
            ddh.HTGiaohang = false;
            ddh.HTThanhtoan = false;
            data.DONDATHANGs.InsertOnSubmit(ddh);
            data.SubmitChanges();

            foreach(var item in listCart)
            {
                CTDATHANG ctdh = new CTDATHANG();
                ctdh.SoDH = ddh.SoDH;
                ctdh.Masach = item.MaSach;
                ctdh.Soluong = item.SoLuong;
                ctdh.Dongia = (decimal)item.DonGia;
                data.CTDATHANGs.InsertOnSubmit(ctdh);
            }
            data.SubmitChanges();
            Session["GioHang"] = null;
            return RedirectToAction("ConfirmOrder", "Cart");
        }
        public ActionResult ConfirmOrder()
        {
            return View();
        }
    }
}