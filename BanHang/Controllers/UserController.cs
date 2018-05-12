using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanHang.Models;

namespace BanHang.Controllers
{
    public class UserController : Controller
    {
        dbQLBansachDataContext data = new dbQLBansachDataContext();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(FormCollection collection, KHACHHANG kh)
        {
            var hoten = collection["HoTenKH"];
            var tenDN = collection["TenDN"];
            var matkhau = collection["Matkhau"];
            var matkhaunhaplai = collection["XacnhanMK"];
            var diachi = collection["DiaChi"];
            var email = collection["MailKH"];
            var sdt = collection["SDT"];
            var ngaysinh = String.Format("{0:MM/DD/YYYY}", collection["ngaySinh"]);
            var gioitinh = collection["gioitinh"];

            if (String.IsNullOrEmpty(hoten))
                ViewData["Loi1"] = "Chưa nhập họ tên !";
            else if (String.IsNullOrEmpty(tenDN))
                ViewData["Loi2"] = "Chưa điền tên đăng nhập !";
            else if (String.IsNullOrEmpty(matkhau))
                ViewData["Loi3"] = "Chưa điền mật khẩu !";
            else if (String.IsNullOrEmpty(matkhaunhaplai))
                ViewData["Loi4"] = "Chưa xác nhận mật khẩu nhập lại !";
            else if (String.IsNullOrEmpty(sdt))
                ViewData["Loi5"] = "Chưa điền số điện thoại !";
            else if (String.IsNullOrEmpty(diachi))
                ViewData["Loi6"] = "Địa chỉ không được trống !";
            else if (String.IsNullOrEmpty(email))
                ViewData["Loi7"] = "Chưa điền địa chỉ email !";
            else if (matkhau != matkhaunhaplai)
                ViewData["Loi4"] = "Mật khẩu nhập lại sai !";
            else
            {
                kh.HoTenKH = hoten;
                kh.TenDN = tenDN;
                kh.Matkhau = matkhau;
                kh.Email = email;
                kh.DienthoaiKH = sdt;
                kh.DiachiKH = diachi;
                kh.Ngaysinh = DateTime.Parse(ngaysinh);
                kh.Gioitinh = bool.Parse(gioitinh);

                data.KHACHHANGs.InsertOnSubmit(kh);
                data.SubmitChanges();
                return RedirectToAction("DangNhap");
            }
            return this.DangKy();
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var tendn = collection["TenDN"];
            var matkhau = collection["MatKhau"];
            if (String.IsNullOrEmpty(tendn))
                ViewData["loi1"] = "Không được để trống !";
            else if (String.IsNullOrEmpty(matkhau))
                ViewData["loi2"] = "Không được để trống !";
            else
            {
                KHACHHANG kh = data.KHACHHANGs.SingleOrDefault(n => n.TenDN == tendn && n.Matkhau == matkhau);
                if (kh != null)
                {
                    ViewBag.ThongBao = "ĐĂNG NHẬP THÀNH CÔNG !";
                    Session["TaiKhoan"] = kh;
                    Session["TenDangNhap"] = tendn;
                    return RedirectToAction("Order", "Cart", new { area = "" });
                }
                else
                {
                    ViewBag.ThongBao = "TÊN ĐĂNG NHẬP HOẶC MẬT KHẨU KHÔNG ĐÚNG !";
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["TaiKhoan"] = null;
            Session["TenDangNhap"] = null;
            return RedirectToAction("Index", "BookStore");
        }
    }
}