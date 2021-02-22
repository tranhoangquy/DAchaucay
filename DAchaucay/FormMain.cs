using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAchaucay
{

    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        //logout
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Hide();
            FormLogin fl = new FormLogin();
            fl.Show();
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        //-----
        private void FormMain_Load(object sender, EventArgs e)
        {
            Class.Functions.Connect();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Class.Functions.Disconnect(); //Đóng kết nối
            Application.Exit(); //Thoát
        }

        private void loạiChậuCâyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                FormLoaiChauCay formLoaiChauCay= new FormLoaiChauCay(); //Khởi tạo đối tượng
                formLoaiChauCay.ShowDialog(); //Hiển thị
            }
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                FormNhanVien formNhanVien = new FormNhanVien();
                formNhanVien.ShowDialog();
            }
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                FormKhachHang formKhachHang = new FormKhachHang();
                formKhachHang.ShowDialog();
            }
        }

        private void hóaĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            {
                FormChiTietHoaDon formChiTietHoaDon = new FormChiTietHoaDon();
                formChiTietHoaDon.ShowDialog();
            }
        }

        private void chậuCâyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                FormChauCay formChauCay = new FormChauCay();
                formChauCay.ShowDialog();
            }
        }

        private void tìmHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHoaDon formHoaDon = new FormHoaDon();
            formHoaDon.ShowDialog();
        }
    }
}
