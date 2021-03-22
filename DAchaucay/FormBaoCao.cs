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
    public partial class FormBaoCao : Form
    {
        DataTable tblChaucay;

        public FormBaoCao()
        {
            InitializeComponent();
        }
        public void loadbaocao()
        {
            
        }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * FROm tblChaucay";
            CrystalReport1 rpt = new CrystalReport1();
            rpt.SetDataSource(Functions.GetDataToTable(sql));
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
