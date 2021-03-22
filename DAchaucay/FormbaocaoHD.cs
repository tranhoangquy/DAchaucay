using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAchaucay.Class;
namespace DAchaucay
{
    public partial class FormBaoCaoHD : Form
    {
        DataTable tblChaucay,tblHoadon, tblChitiethoadon, tblNhanvien, tblKhachhang;

        private void FormBaoCaoHD_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dt_timetruoc_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dt_timesau_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql;

            sql = "SELECT tblChitiethoadon.Mahoadon, tblChaucay.Tenhaucay, tblChitiethoadon.Soluong, tblChitiethoadon.Dongia, tblChitiethoadon.Giamgia, tblHoadon.Ngayban, tblNhanvien.Tennhanvien, tblKhachhang.Tenkhachhang FROM tblChaucay INNER JOIN tblChitiethoadon ON tblChaucay.Machaucay = tblChitiethoadon.Machaucay INNER JOIN tblHoadon ON tblChitiethoadon.Mahoadon = tblHoadon.Mahoadon INNER JOIN tblKhachhang ON tblHoadon.Makhachhang = tblKhachhang.Makhachhang INNER JOIN tblNhanvien ON tblHoadon.Manhanvien = tblNhanvien.Manhanvien";
            CrystalReport2 rpt = new CrystalReport2();
            rpt.SetDataSource(Functions.GetDataToTable(sql));
            crystalReportViewer1.ReportSource = rpt;
        }

        private void btnThongke_Click(object sender, EventArgs e)
        {
            string sql;
            
            sql = "SELECT tblChitiethoadon.Mahoadon, tblChaucay.Tenhaucay, tblChitiethoadon.Soluong, tblChitiethoadon.Dongia, tblChitiethoadon.Giamgia, tblHoadon.Ngayban, tblNhanvien.Tennhanvien, tblKhachhang.Tenkhachhang FROM tblChaucay INNER JOIN tblChitiethoadon ON tblChaucay.Machaucay = tblChitiethoadon.Machaucay INNER JOIN tblHoadon ON tblChitiethoadon.Mahoadon = tblHoadon.Mahoadon INNER JOIN tblKhachhang ON tblHoadon.Makhachhang = tblKhachhang.Makhachhang INNER JOIN tblNhanvien ON tblHoadon.Manhanvien = tblNhanvien.Manhanvien";
            if ((dt_timetruoc.Text != "") && (dt_timesau.Text != ""))
            {
                sql = sql + " AND Ngayban >= '" + dt_timetruoc.Text + "' AND Ngayban <= '" + dt_timesau.Text + "'";
            }
            CrystalReport2 rpt = new CrystalReport2();
            rpt.SetDataSource(Functions.GetDataToTable(sql));
            crystalReportViewer1.ReportSource = rpt;
        }

        public FormBaoCaoHD()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
