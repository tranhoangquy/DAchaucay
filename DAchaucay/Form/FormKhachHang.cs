using DAchaucay.Class;
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
    public partial class FormKhachHang : Form
    {
        DataTable tblKhachhang;
        public FormKhachHang()
        {
            InitializeComponent();
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            txtMaKH.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from tblKhachhang";
            tblKhachhang = Functions.GetDataToTable(sql); //Lấy dữ liệu từ bảng
            dgvKH.DataSource = tblKhachhang; //Hiển thị vào dataGridView
            dgvKH.Columns[0].HeaderText = "Mã khách";
            dgvKH.Columns[1].HeaderText = "Tên khách";
            dgvKH.Columns[2].HeaderText = "Địa chỉ";
            dgvKH.Columns[3].HeaderText = "Điện thoại";
            dgvKH.Columns[0].Width = 100;
            dgvKH.Columns[1].Width = 150;
            dgvKH.Columns[2].Width = 150;
            dgvKH.Columns[3].Width = 150;
            dgvKH.AllowUserToAddRows = false;
            dgvKH.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKH.Focus();
                return;
            }
            if (tblKhachhang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaKH.Text = dgvKH.CurrentRow.Cells["Makhachhang"].Value.ToString();
            txtTenKH.Text = dgvKH.CurrentRow.Cells["Tenkhachhang"].Value.ToString();
            txtDiachi.Text = dgvKH.CurrentRow.Cells["Diachi"].Value.ToString();
            txtDienthoai.Text = dgvKH.CurrentRow.Cells["Dienthoai"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaKH.Enabled = true;
            txtMaKH.Focus();
        }
        private void ResetValues()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtDiachi.Text = "";
            txtDienthoai.Text = "";
        }
    }
}
