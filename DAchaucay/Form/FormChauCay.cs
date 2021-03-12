using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAchaucay.Class;
using System.Data;
using System.Data.SqlClient;
namespace DAchaucay
{
    public partial class FormChauCay : Form
    {
        DataTable tblChaucay;
        public FormChauCay()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormChauCay_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT Maloaichaucay, Loaichaucay from tblLoaichaucay";
            txtMaCC.ReadOnly = true;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView();
            Functions.FillCombo(sql, cboTenCC, "Loaichaucay", "Loaichaucay");
            cboTenCC.SelectedIndex = -1;
            ResetValues();
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from tblChaucay";
            tblChaucay = Functions.GetDataToTable(sql);
            dgvCC.DataSource = tblChaucay;
            dgvCC.Columns[0].HeaderText = "Mã Chậu Cây";
            dgvCC.Columns[1].HeaderText = "Chất liệu";
            dgvCC.Columns[2].HeaderText = "Tên Chậu Cây";
            dgvCC.Columns[3].HeaderText = "Kích thước";
            dgvCC.Columns[4].HeaderText = "Đơn giá ";
            dgvCC.Columns[5].HeaderText = "Ảnh";
            dgvCC.Columns[6].HeaderText = "Số lượng";
            dgvCC.Columns[0].Width = 80;
            dgvCC.Columns[1].Width = 140;
            dgvCC.Columns[2].Width = 80;
            dgvCC.Columns[3].Width = 80;
            dgvCC.Columns[4].Width = 100;
            dgvCC.Columns[5].Width = 100;
            dgvCC.Columns[6].Width = 200;
            dgvCC.AllowUserToAddRows = false;
            dgvCC.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues()
        {
            txtMaCC.Text = "";
            txtMaCC.Text = "";
            cboTenCC.Text = "";
            txtSoluong.Text = "0";
            txtDongia.Text = "0";
            txtSoluong.Enabled = true;
            txtDongia.Enabled = false;
            txtAnh.Text = "";
            picAnh.Image = null;
        }

        private void dgvCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string Maloaichaucay;
            string sql;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaCC.Focus();
                return;
            }
            if (tblChaucay.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaCC.Text = dgvCC.CurrentRow.Cells["Machaucay"].Value.ToString();
            cboTenCC.Text = dgvCC.CurrentRow.Cells["Tenhaucay"].Value.ToString();
            Maloaichaucay = dgvCC.CurrentRow.Cells["Maloaichaucay"].Value.ToString();
            sql = "SELECT Maloaichaucay FROM tblLoaichaucay WHERE Maloaichaucay=N'" + Maloaichaucay + "'";
            txtMaCC.Text = Functions.GetFieldValues(sql);
            txtSoluong.Text = dgvCC.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtKichthuoc.Text = dgvCC.CurrentRow.Cells["Kichthuoc"].Value.ToString();
            txtDongia.Text = dgvCC.CurrentRow.Cells["Dongia"].Value.ToString();
            sql = "SELECT Anh FROM tblChaucay WHERE Machaucay=N'" + txtMaCC.Text + "'";
            txtAnh.Text = Functions.GetFieldValues(sql);
            picAnh.Image = Image.FromFile(txtAnh.Text);
           
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
            txtMaCC.Enabled = true;
            txtMaCC.Focus();
            txtSoluong.Enabled = true;
            txtDongia.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã chậu cây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaCC.Focus();
                return;
            }
            if (cboTenCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chậu cây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTenCC.Focus();
                return;
            }
            if (txtMaCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã loại chậu cây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaCC.Focus();
                return;
            }
            if (txtKichthuoc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập kích thước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtKichthuoc.Focus();
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh hoạ cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOpen.Focus();
                return;
            }
            /*sql = "SELECT Machaucay FROM tblChaucay WHERE Machaucay=N'" + txtMaCC.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã tồn tại, bạn phải chọn mã hàng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaCC.Focus();
                return;
            }*/
            /*   sql = "INSERT INTO tblChaucay(Machaucay,Tenchaucay,Maloaichaucay,SoLuong,Dongia,Anh,) VALUES(N'"
                   + txtMaCC.Text.Trim() + "',N'" + txtMaCC.Text.Trim() +
                   "',N'" + cboMaLCC.SelectedValue.ToString() +
                   "'," + txtSoluong.Text.Trim() + "," + txtDongia.Text +
                   ",'" + txtAnh.Text + "')";*/
            sql = "INSERT INTO tblChaucay(Machaucay,Maloaichaucay,Tenhaucay,Kichthuoc, Dongia,Anh,Soluong) VALUES(N'"
      + txtMaCC.Text.Trim() + "',N'" + txtMaCC.Text.Trim() +
      "',N'" +cboTenCC.SelectedValue.ToString() +
      "','" + txtKichthuoc.Text.Trim() + "'," + txtDongia.Text +
      ",'" + txtAnh.Text + "','" + txtSoluong.Text +  "')";


            Functions.RunSQL(sql);
            LoadDataGridView();
            //ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaCC.Enabled = false;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtAnh.Text = dlgOpen.FileName;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblChaucay.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaCC.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaCC.Focus();
                return;
            }
            if (cboTenCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTenCC.Focus();
                return;
            }
            if (txtMaCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaCC.Focus();
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải ảnh minh hoạ cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAnh.Focus();
                return;
            }
            sql = "UPDATE tblChaucay SET Tenhaucay=N'" + cboTenCC.SelectedValue.ToString() +
                "',Maloaichaucay=N'" + txtMaLCC.Text.Trim().ToString() +
                "',Soluong=" + txtSoluong.Text +
                ",Anh='" + txtAnh.Text + "',Kichthuoc=N'" + txtKichthuoc.Text + "',Dongia=" + txtDongia.Text + " WHERE Machaucay=N'" + txtMaCC.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblChaucay.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaCC.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblChaucay WHERE Machaucay=N'" + txtMaCC.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
                ResetValues();
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnThem.Enabled = true;
                btnBoQua.Enabled = false;
                btnLuu.Enabled = false;
                txtMaCC.Enabled = false;
            
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain();
            formMain.Show();
            Visible = false;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;
          
            sql = "SELECT * from tblChaucay WHERE 1=1";
            if (txtMaCC.Text != "")
                sql += " AND Machaucay LIKE N'%" + txtMaCC.Text + "%'";
            /*if (txtTenCC.Text != "")
                sql += " AND Tenhaucay LIKE N'%" + txtTenCC.Text + "%'";
            if (cboMaLCC.Text != "")
                sql += " AND Maloaichaucay LIKE N'%" + cboMaLCC.SelectedValue + "%'";*/
            tblChaucay = Functions.GetDataToTable(sql);
            if (tblChaucay.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblChaucay.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvCC.DataSource = tblChaucay;
            ResetValues();
        }
    }
}
