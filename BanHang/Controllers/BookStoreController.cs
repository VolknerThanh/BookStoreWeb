using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanHang.Models;

using PagedList;
using PagedList.Mvc;

namespace BanHang.Controllers
{
    public class BookStoreController : Controller
    {
        dbQLBansachDataContext data = new dbQLBansachDataContext();

        private List<SACH> getNewBook(int count, string name)
        {
            //return data.SACHes.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
            if (!String.IsNullOrEmpty(name))
                return (from s in data.SACHes
                        where s.Tensach.ToUpper().Contains(name.ToUpper())
                        orderby s.Ngaycapnhat descending
                        select s).Take(count).ToList();
            else
                return (from s in data.SACHes
                        orderby s.Ngaycapnhat descending
                        select s).Take(count).ToList();

        }

        // GET: BookStore
        public ActionResult Index(int? page, FormCollection collection)
        {
            int pageSize = 4;
            int pageNum = (page ?? 1);
            string name = collection["SearchingBox"];
            var sachmoi = getNewBook(15, name);
            return View(sachmoi.ToPagedList(pageNum, pageSize));
        }

        public ActionResult ChuDe()
        {
            var chude = from cd in data.CHUDEs select cd;
            return PartialView(chude);
        }
        public ActionResult NhaXuatBan()
        {
            var nhaxuatban = from nxb in data.NHAXUATBANs select nxb;
            return PartialView(nhaxuatban);
        }
        public ActionResult SPTheoChude(int id)
        {
            var sach = from s in data.SACHes where s.MaCD == id select s;
            return View(sach);
        }
        public ActionResult SPTheoNSX(int id)
        {
            var sach = from s in data.SACHes where s.MaNXB == id select s;
            return View(sach);
        }
        public ActionResult Details(int id)
        {
            var sach = from s in data.SACHes where s.Masach == id select s;
            return View(sach.Single());
        }
        public ActionResult Search()
        {
            return PartialView();
        }
    }
}