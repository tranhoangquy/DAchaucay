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
            //Class.Functions.Connect();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
           // Class.Functions.Disconnect(); //Đóng kết nối
            //Application.Exit(); //Thoát
        }

       
    }
}
