﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDTO
    {
        #region Attributes Product
        private string maSP;
        private string tenSP;
        private int giaBan;
        private int slTon;
        private string manhomSP;
        private string nuocSX;
        private string ngaySX;
        private string hanSD;
        #endregion
        #region Khởi tạo cho Product
        public ProductDTO()
        {

        }

        public ProductDTO(string maSP, string tenSP, int giaBan, int slTon, string manhomSP,
            string nuocSX, string ngaySX, string hanSD)
        {
            MaSP = maSP;
            TenSP = tenSP;
            GiaBan = giaBan;
            SlTon = slTon;
            ManhomSP = manhomSP;
            NuocSX = nuocSX;
            NgaySX = ngaySX;
            HanSD = hanSD;
        }
        #endregion
        #region Property cho lớp Product
        public string MaSP { get => maSP; set => maSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public int GiaBan { get => giaBan; set => giaBan = value; }
        public int SlTon { get => slTon; set => slTon = value; }
        public string ManhomSP { get => manhomSP; set => manhomSP = value; }
        public string NuocSX { get => nuocSX; set => nuocSX = value; }
        public string NgaySX { get => ngaySX; set => ngaySX = value; }
        public string HanSD { get => hanSD; set => hanSD = value; }
        #endregion
    }
}
