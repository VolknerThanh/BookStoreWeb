using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHang.Models
{
    public class Cart
    {
        dbQLBansachDataContext data = new dbQLBansachDataContext();
        public int MaSach { set; get; }
        public string TenSach { get; set; }
        public string AnhBia { get; set; }
        public Double DonGia { get; set; }
        public int SoLuong { get; set; }
        public Double ThanhTien { get { return SoLuong * DonGia; } }
        public Cart(int id)
        {
            MaSach = id;
            SACH sach = data.SACHes.Single(n => n.Masach == id);
            TenSach = sach.Tensach;
            AnhBia = sach.Hinhminhhoa;
            DonGia = double.Parse(sach.Dongia.ToString());
            SoLuong = 1;
        }
    }
}