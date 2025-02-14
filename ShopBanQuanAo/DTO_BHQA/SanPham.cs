﻿namespace DTO_BHQA
{
    public class SanPham
    {
        private string _MaSp;
        private string _TenSp;
        private double _GiaSp;
        private string _DonViTinh;

        public string MaSp { get => _MaSp; set => _MaSp = value; }
        public string TenSp { get => _TenSp; set => _TenSp = value; }
        public double GiaSp { get => _GiaSp; set => _GiaSp = value; }
        public string DonViTinh { get => _DonViTinh; set => _DonViTinh = value; }

        public SanPham() { }
        public SanPham(string maSp, string tenSp, double giaSp, string donViTinh)
        {
            _MaSp = maSp;
            _TenSp = tenSp;
            _GiaSp = giaSp;
            _DonViTinh = donViTinh;
        }
    }
}
