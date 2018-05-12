using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanHang.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace BanHang.Controllers
{
    public class AdminController : Controller
    {
        dbQLBansachDataContext data = new dbQLBansachDataContext();
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["TaiKhoanAdmin"] == null)
                return RedirectToAction("Login");
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Sach(int ? page)
        {
            if (Session["TaiKhoanAdmin"] == null)
                return RedirectToAction("Login");

            int pageNumber = (page ?? 1);
            int pageSize = 7;
            return View(data.SACHes.ToList().OrderBy(n => n.Masach).ToPagedList(pageNumber, pageSize) );
        }

        [HttpPost]
        public ActionResult Login(FormCollection collect)
        {
            var tenDangNhap = collect["username"];
            var matKhau = collect["password"];

            if (String.IsNullOrEmpty(tenDangNhap))
                ViewData["Loi1"] = "Điền đầy đủ tên đăng nhập !";
            else if (String.IsNullOrEmpty(matKhau))
                ViewData["Loi2"] = "Điền mật khẩu !";
            else
            {
                Admin ad = data.Admins.SingleOrDefault(n => n.UserAdmin == tenDangNhap && n.PassAdmin == matKhau);
                if (ad != null)
                {
                    Session["TaiKhoanAdmin"] = ad;
                    Session["TenTaiKhoan"] = tenDangNhap;
                    return RedirectToAction("Index", "Admin");
                }
                else
                    ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không chính xác !";
            }

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (Session["TaiKhoanAdmin"] == null)
                return RedirectToAction("Login");

            ViewBag.MaCD = new SelectList(data.CHUDEs.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChuDe");
            ViewBag.MaNXB = new SelectList(data.NHAXUATBANs.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(SACH sach, HttpPostedFileBase fileupload)
        {
            ViewBag.MaCD = new SelectList(data.CHUDEs.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChuDe");
            ViewBag.MaNXB = new SelectList(data.NHAXUATBANs.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");
            if (fileupload == null)
            {
                ViewBag.ThongBao = "Vui lòng chọn ảnh bìa!";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var filename = Path.GetFileName(fileupload.FileName);
                    var path = Path.Combine(Server.MapPath("~/img"), filename);
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.ThongBao = "Hình ảnh đã tồn tại!";
                    }
                    else
                    {
                        fileupload.SaveAs(path);
                    }
                    sach.Hinhminhhoa = filename;
                    data.SACHes.InsertOnSubmit(sach);
                    data.SubmitChanges();
                }
                return RedirectToAction("Sach");
            }
        }
        public ActionResult Details(int id)
        {
            if (Session["TaiKhoanAdmin"] == null)
                return RedirectToAction("Login");

            SACH sach = data.SACHes.SingleOrDefault(n => n.Masach == id);
            ViewBag.Masach = sach.Masach;
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sach);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["TaiKhoanAdmin"] == null)
                return RedirectToAction("Login");

            SACH sach = data.SACHes.SingleOrDefault(n => n.Masach == id);
            ViewBag.Masach = sach.Masach;
            if(sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sach);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult XacNhanXoa(int id)
        {
            SACH sach = data.SACHes.SingleOrDefault(n => n.Masach == id);
            ViewBag.Masach = sach.Masach;
            if(sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.SACHes.DeleteOnSubmit(sach);
            data.SubmitChanges();
            return RedirectToAction("Sach");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["TaiKhoanAdmin"] == null)
                return RedirectToAction("Login");

            SACH sach = data.SACHes.SingleOrDefault(n => n.Masach == id);
            if(sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaCD = new SelectList(data.CHUDEs.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChuDe", sach.MaCD);
            ViewBag.MaNXB = new SelectList(data.NHAXUATBANs.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB", sach.MaNXB);
            return View(sach);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(SACH sach, HttpPostedFileBase fileupload)
        {
            ViewBag.MaCD = new SelectList(data.CHUDEs.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChuDe");
            ViewBag.MaNXB = new SelectList(data.NHAXUATBANs.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB");
            if(fileupload == null)
            {
                ViewBag.ThongBao = "Vui lòng chọn ảnh bìa";
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var filename = Path.GetFileName(fileupload.FileName);
                    var path = Path.Combine(Server.MapPath("../../img"), filename);
                    if (System.IO.File.Exists(path))
                        ViewBag.ThongBao = "Hình ảnh đã tồn tại!";
                    else
                        fileupload.SaveAs(path);

                    //SACH thisBook = data.SACHes.Where(x => x.Masach == sach.Masach).Single<SACH>();
                    SACH thisBook = data.SACHes.SingleOrDefault(n => n.Masach == sach.Masach);
                    thisBook.Tensach = sach.Tensach;
                    thisBook.Masach = sach.Masach;
                    thisBook.Dongia = sach.Dongia;
                    thisBook.MaCD = sach.MaCD;
                    thisBook.MaNXB = sach.MaNXB;
                    thisBook.Ngaycapnhat = sach.Ngaycapnhat;
                    thisBook.Soluongban = sach.Soluongban;
                    thisBook.Mota = sach.Mota;
                    thisBook.moi = sach.moi;
                    thisBook.Hinhminhhoa = filename;
                    data.SubmitChanges();
                }
                return RedirectToAction("Sach");
            }
        }
        [HttpPost]
        public ActionResult Logout()
        {
            Session["TaiKhoanAdmin"] = null;
            Session["TenTaiKhoan"] = null;
            return RedirectToAction("Login");
        }
    }
}