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
namespace DAchaucay
{
    public partial class FormChiTietHoaDon : Form
    {
        DataTable tblChitiethoadon;
        public FormChiTietHoaDon()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FormChiTietHoaDon_Load(object sender, EventArgs e)
        {
            btnThemmoi.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = true;
            txtMaHDBan.ReadOnly = true;
            txtTennhanvien.ReadOnly = true;
            txtTenkhach.ReadOnly = true;
            txtDiachi.ReadOnly = true;
            txtDienthoai.ReadOnly = true;
            txtTenchaucay.ReadOnly = true;
            txtDongia.ReadOnly = true;
           /* txtThanhtien.ReadOnly = true;
            txtTongtien.ReadOnly = true;*/
            txtGiamgia.Text = "0";
         /*   txtTongtien.Text = "0";*/
            Functions.FillCombo("SELECT Makhachhang, Tenkhachhang FROM tblKhachhang", cboMakhach, "Makhachhang", "Makhachhang");
            cboMakhach.SelectedIndex = -1;
            Functions.FillCombo("SELECT Manhanvien, Tennhanvien FROM tblNhanvien", cboManhanvien, "Manhanvien", "Tenkhachhang");
            cboManhanvien.SelectedIndex = -1;
            Functions.FillCombo("SELECT Machaucay, Tenhaucay FROM tblChaucay", cboMachaucay, "Machaucay", "Machaucay");
            cboMachaucay.SelectedIndex = -1;
            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txtMaHDBan.Text != "")
            {
                LoadInfoHoadon();
                btnXoa.Enabled = true;
            }
            LoadDataGridView();
        }

        private void LoadInfoHoadon()
        {
            string str;
            str = "SELECT Ngayban FROM tblHoadon WHERE Mahoadon = N'" + txtMaHDBan.Text + "'";
            txtNgayban.Text = Functions.ConvertDateTime(Functions.GetFieldValues(str));
            str = "SELECT Manhanvien FROM tblHoadon WHERE Mahoadon = N'" + txtMaHDBan.Text + "'";
            cboManhanvien.Text = Functions.GetFieldValues(str);
            str = "SELECT Makhachhang FROM tblHoadon WHERE Mahoadon = N'" + txtMaHDBan.Text + "'";
            cboMakhach.Text = Functions.GetFieldValues(str);
          
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT a.Machaucay, b.Tenhaucay, a.Soluong, b.Dongia, a.Giamgia FROM tblChitiethoadon AS a, tblChaucay AS b WHERE a.Mahoadon = N'" + txtMaHDBan.Text + "' AND a.Machaucay=b.Machaucay";
            tblChitiethoadon = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tblChitiethoadon;
            DataGridView.Columns[0].HeaderText = "Mã hàng";
            DataGridView.Columns[1].HeaderText = "Tên hàng";
            DataGridView.Columns[2].HeaderText = "Số lượng";
            DataGridView.Columns[3].HeaderText = "Đơn giá";
            DataGridView.Columns[4].HeaderText = "Giảm giá %";
          /*  DataGridView.Columns[5].HeaderText = "Thành tiền";*/
            DataGridView.Columns[0].Width = 80;
            DataGridView.Columns[1].Width = 130;
            DataGridView.Columns[2].Width = 80;
            DataGridView.Columns[3].Width = 90;
            DataGridView.Columns[4].Width = 90;
            /*DataGridView.Columns[5].Width = 90;*/
            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = true;
            btnLuu.Enabled = true;
            btnThemmoi.Enabled = false;
            ResetValues();
            txtMaHDBan.Text = Functions.CreateKey("HDB");
            LoadDataGridView();
        }
        private void ResetValues()
        {
            txtMaHDBan.Text = "";
            txtNgayban.Text = DateTime.Now.ToShortDateString();
            cboManhanvien.Text = "";
            cboMakhach.Text = "";
        /*    txtTongtien.Text = "0";*/
            //lblBangchu.Text = "Bằng chữ: ";
          /*  cboMahang.Text = "";*/
            txtSoluong.Text = "";
            txtGiamgia.Text = "0";
           /* txtThanhtien.Text = "0";*/
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            sql = "SELECT Mahoadon FROM tblHoadon WHERE Mahoadon=N'" + txtMaHDBan.Text + "'";
            if (!Functions.CheckKey(sql))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                if (txtNgayban.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNgayban.Focus();
                    return;
                }
                if (cboManhanvien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboManhanvien.Focus();
                    return;
                }
                if (cboMakhach.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMakhach.Focus();
                    return;
                }
                sql = "INSERT INTO tblHoadon(Mahoadon, Ngayban, Manhanvien, Makhachhang) VALUES (N'" + txtMaHDBan.Text.Trim() + "','" +
                      Functions.ConvertDateTime(txtNgayban.Text.Trim()) + "',N'" + cboManhanvien.SelectedValue + "',N'" +
                      cboMakhach.SelectedValue + "')";
                Functions.RunSQL(sql);
            }
            // Lưu thông tin của các mặt hàng
            if (cboMachaucay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chậu cây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMachaucay.Focus();
                return;
            }
            if ((txtSoluong.Text.Trim().Length == 0) || (txtSoluong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }
            if (txtGiamgia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiamgia.Focus();
                return;
            }
            sql = "SELECT Machaucay FROM tblChitiethoadon WHERE Machaucay=N'" + cboMachaucay.SelectedValue + "' AND Mahoadon = N'" + txtMaHDBan.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHang();
                cboMachaucay.Focus();
                return;
            }
            sql = "INSERT INTO tblChitiethoadon(Mahoadon,Machaucay,Soluong, Dongia,Giamgia) VALUES(N'" + txtMaHDBan.Text.Trim() + "',N'" + cboMachaucay.SelectedValue + "'," + txtSoluong.Text + "," + txtDongia.Text + "," + txtGiamgia.Text + ")";
            Functions.RunSQL(sql);
            LoadDataGridView();
        }

        private void ResetValuesHang()
        {
            cboMachaucay.Text = "";
            txtSoluong.Text = "";
            txtGiamgia.Text = "0";
        }

        private void DataGridView_DoubleClick(object sender, EventArgs e)
        {
            string mahangxoa, sql;
            Double thanhtienxoa, soluongxoa, sl, slcon, tong, tongmoi;
            if (tblChitiethoadon.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                mahangxoa = DataGridView.CurrentRow.Cells["Machaucay"].Value.ToString();
                soluongxoa = Convert.ToDouble(DataGridView.CurrentRow.Cells["Soluong"].Value.ToString());
                /*thanhtienxoa = Convert.ToDouble(DataGridView.CurrentRow.Cells["Thanhtien"].Value.ToString());*/
                sql = "DELETE tblChitiethoadon WHERE Mahoadon=N'" + txtMaHDBan.Text + "' AND Machaucay = N'" + mahangxoa + "'";
                Functions.RunSQL(sql);
                // Cập nhật lại số lượng cho các mặt hàng
               /* sl = Convert.ToDouble(Functions.GetFieldValues("SELECT Soluong FROM tblHang WHERE Mahang = N'" + mahangxoa + "'"));
                slcon = sl + soluongxoa;
                sql = "UPDATE tblHang SET Soluong =" + slcon + " WHERE Mahang= N'" + mahangxoa + "'";
                Functions.RunSQL(sql);*/
                // Cập nhật lại tổng tiền cho hóa đơn bán
              /*  tong = Convert.ToDouble(Functions.GetFieldValues("SELECT Tongtien FROM tblHDBan WHERE MaHDBan = N'" + txtMaHDBan.Text + "'"));
                tongmoi = tong - thanhtienxoa;*/
               /* sql = "UPDATE tblHDBan SET Tongtien =" + tongmoi + " WHERE MaHDBan = N'" + txtMaHDBan.Text + "'";*/
                Functions.RunSQL(sql);
           /*     txtTongtien.Text = tongmoi.ToString();*/
                //lblBangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(tongmoi.ToString());
                LoadDataGridView();
            }
        }

        private void cboManhanvien_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboManhanvien.Text == "")
                txtTennhanvien.Text = "";
            // Khi chọn Mã nhân viên thì tên nhân viên tự động hiện ra
            str = "Select Tennhanvien from tblNhanvien where Manhanvien =N'" + cboManhanvien.SelectedValue + "'";
            txtTennhanvien.Text = Functions.GetFieldValues(str);
        }

        private void cboMakhach_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMakhach.Text == "")
            {
                txtTenkhach.Text = "";
                txtDiachi.Text = "";
                txtDienthoai.Text = "";
            }
            //Khi chọn Mã khách hàng thì các thông tin của khách hàng sẽ hiện ra
            str = "Select Tenkhachhang from tblKhachhang where Makhachhang = N'" + cboMakhach.SelectedValue + "'";
            txtTenkhach.Text = Functions.GetFieldValues(str);
            str = "Select Diachi from tblKhachhang where Makhachhang = N'" + cboMakhach.SelectedValue + "'";
            txtDiachi.Text = Functions.GetFieldValues(str);
            str = "Select Dienthoai from tblKhachhang where Makhachhang= N'" + cboMakhach.SelectedValue + "'";
            txtDienthoai.Text = Functions.GetFieldValues(str);
        }

        private void cboMachaucay_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMachaucay.Text == "")
            {
                txtTenchaucay.Text = "";
                txtDongia.Text = "";
            }
            // Khi chọn mã hàng thì các thông tin về hàng hiện ra
            str = "SELECT Tenhaucay FROM tblChaucay WHERE Machaucay =N'" + cboMachaucay.SelectedValue + "'";
            txtTenchaucay.Text = Functions.GetFieldValues(str);
            str = "SELECT Dongia FROM tblChaucay WHERE Machaucay =N'" + cboMachaucay.SelectedValue + "'";
            txtDongia.Text = Functions.GetFieldValues(str);
            /*  str = "SELECT Soluong FROM tblHang WHERE Machaucay =N'" + cboMachaucay.SelectedValue + "'";
              txtTon.Text = Functions.GetFieldValues(str);
              str = "SELECT Ghichu FROM tblHang WHERE Machaucay =N'" + cboMachaucay.SelectedValue + "'";
              txtBH.Text = Functions.GetFieldValues(str);*/
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            double sl, slcon, slxoa;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "SELECT Machaucay,Soluong FROM tblChitiethoadon WHERE Mahoadon = N'" + txtMaHDBan.Text + "'";
                /*DataTable tblHang = Functions.GetDataToTable(sql);
                for (int hang = 0; hang <= tblHang.Rows.Count - 1; hang++)
                {
                    // Cập nhật lại số lượng cho các mặt hàng
                    sl = Convert.ToDouble(Functions.GetFieldValues("SELECT Soluong FROM tblHang WHERE Mahang = N'" + tblHang.Rows[hang][0].ToString() + "'"));
                    slxoa = Convert.ToDouble(tblHang.Rows[hang][1].ToString());
                    slcon = sl + slxoa;
                    sql = "UPDATE tblHang SET Soluong =" + slcon + " WHERE Mahang= N'" + tblHang.Rows[hang][0].ToString() + "'";
                    Functions.RunSQL(sql);
                }*/

                //Xóa chi tiết hóa đơn
                sql = "DELETE tblChitiethoadon WHERE Mahoadon=N'" + txtMaHDBan.Text + "'";
                Functions.RunSqlDel(sql);

                //Xóa hóa đơn
                sql = "DELETE tblHoadon WHERE Mahoadon=N'" + txtMaHDBan.Text + "'";
                Functions.RunSqlDel(sql);
                ResetValues();
                LoadDataGridView();
                btnXoa.Enabled = true;
               /* btnInhoadon.Enabled = false;*/
            }
        }

        private void cboMaHD_DropDown(object sender, EventArgs e)
        {
                Functions.FillCombo("SELECT Mahoadon FROM tblHoadon", cboMaHD, "Mahoadon", "Mahoadon");
                cboMaHD.SelectedIndex = -1;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cboMaHD.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaHD.Focus();
                return;
            }
            txtMaHDBan.Text = cboMaHD.Text;
            LoadInfoHoadon();
            LoadDataGridView();
            btnXoa.Enabled = true;
            btnLuu.Enabled = true;
           /* btnInhoadon.Enabled = true;*/
            cboMaHD.SelectedIndex = -1;
        }
    }
    
}
