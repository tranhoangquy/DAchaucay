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
using System.Data.SqlClient;
using COMExcel = Microsoft.Office.Interop.Excel;
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
            txtManhanvien.ReadOnly = true;
            txtMakhach.ReadOnly = true;
            txtDiachi.ReadOnly = true;
            txtDienthoai.ReadOnly = true;
            txtMachaucay.ReadOnly = true;
            txtDongia.ReadOnly = true;
           /* txtThanhtien.ReadOnly = true;
            txtTongtien.ReadOnly = true;*/
            txtGiamgia.Text = "0";
         /*   txtTongtien.Text = "0";*/
            Functions.FillCombo("SELECT Makhachhang, Tenkhachhang FROM tblKhachhang", cboTenkhach, "Tenkhachhang", "Tenkhachhang");
            cboTenkhach.SelectedIndex = -1;
            Functions.FillCombo("SELECT Manhanvien, Tennhanvien FROM tblNhanvien", cboTennhanvien, "Tennhanvien", "Tenkhachhang");
            cboTennhanvien.SelectedIndex = -1;
            Functions.FillCombo("SELECT Machaucay, Tenhaucay FROM tblChaucay", cboTenchaucay, "Tenhaucay", "Tenhaucay");
            cboTenchaucay.SelectedIndex = -1;
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
            txtManhanvien.Text = Functions.GetFieldValues(str);
            str = "SELECT Makhachhang FROM tblHoadon WHERE Mahoadon = N'" + txtMaHDBan.Text + "'";
            txtMakhach.Text = Functions.GetFieldValues(str);
          
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
            cboTenkhach.Text = "";
            /*    txtTongtien.Text = "0";*/
            //lblBangchu.Text = "Bằng chữ: ";
            txtMachaucay.Text = "";
            txtSoluong.Text = "";
            txtGiamgia.Text = "0";
            txtDiachi.Text = "";
            txtDienthoai.Text = "";
            txtDongia.Text = "";
            txtMakhach.Text = "";
            cboTenchaucay.Text = "";
            txtMachaucay.Text = "";
            txtDongia.Text = "";
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
                if (txtManhanvien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtManhanvien.Focus();
                    return;
                }
                if (txtMakhach.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMakhach.Focus();
                    return;
                }
                sql = "INSERT INTO tblHoadon(Mahoadon, Ngayban, Manhanvien, Makhachhang) VALUES (N'" + txtMaHDBan.Text.Trim() + "','" +
                      Functions.ConvertDateTime(txtNgayban.Text.Trim()) + "',N'" + txtManhanvien.Text.Trim() + "',N'" +
                      txtMakhach.Text.Trim() + "')";
                Functions.RunSQL(sql);
            }
            // Lưu thông tin của các mặt hàng
            if (txtMachaucay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chậu cây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMachaucay.Focus();
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
            sql = "SELECT Machaucay FROM tblChitiethoadon WHERE Machaucay=N'" + txtMachaucay.Text.Trim() + "' AND Mahoadon = N'" + txtMaHDBan.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHang();
                txtMachaucay.Focus();
                return;
            }
            sql = "INSERT INTO tblChitiethoadon(Mahoadon,Machaucay,Soluong, Dongia,Giamgia) VALUES(N'" + txtMaHDBan.Text.Trim() + "',N'" + txtMachaucay.Text.Trim() + "'," + txtSoluong.Text + "," + txtDongia.Text + "," + txtGiamgia.Text + ")";
            Functions.RunSQL(sql);
            LoadDataGridView();
        }

        private void ResetValuesHang()
        {
            cboTenchaucay.Text = "";
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
                btnThemmoi.Enabled = true;
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

        private void cboTenkhach_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboTenkhach.Text == "")
            {
                txtMakhach.Text = "";
                txtDiachi.Text = "";
                txtDienthoai.Text = "";
            }
            //Khi chọn Mã khách hàng thì các thông tin của khách hàng sẽ hiện ra
            str = "Select Makhachhang from tblKhachhang where Tenkhachhang = N'" + cboTenkhach.SelectedValue + "'";
            txtMakhach.Text = Functions.GetFieldValues(str);
            str = "Select Diachi from tblKhachhang where Tenkhachhang = N'" + cboTenkhach.SelectedValue + "'";
            txtDiachi.Text = Functions.GetFieldValues(str);
            str = "Select Dienthoai from tblKhachhang where Tenkhachhang= N'" + cboTenkhach.SelectedValue + "'";
            txtDienthoai.Text = Functions.GetFieldValues(str);
        }

        private void cboTennhanvien_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboTennhanvien.Text == "")
                txtManhanvien.Text = "";
            // Khi chọn Mã nhân viên thì tên nhân viên tự động hiện ra
            str = "Select Manhanvien from tblNhanvien where Tennhanvien =N'" + cboTennhanvien.SelectedValue + "'";
            txtManhanvien.Text = Functions.GetFieldValues(str);
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void cboTenchaucay_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboTenchaucay.Text == "")
            {
                txtMachaucay.Text = "";
                txtDongia.Text = "";
            }
            // Khi chọn mã hàng thì các thông tin về hàng hiện ra
            str = "SELECT Machaucay FROM tblChaucay WHERE Tenhaucay =N'" + cboTenchaucay.SelectedValue + "'";
            txtMachaucay.Text = Functions.GetFieldValues(str);
            str = "SELECT Dongia FROM tblChaucay WHERE Tenhaucay =N'" + cboTenchaucay.SelectedValue + "'";
            txtDongia.Text = Functions.GetFieldValues(str);
            /*  str = "SELECT Soluong FROM tblHang WHERE Machaucay =N'" + cboMachaucay.SelectedValue + "'";
              txtTon.Text = Functions.GetFieldValues(str);
              str = "SELECT Ghichu FROM tblHang WHERE Machaucay =N'" + cboMachaucay.SelectedValue + "'";
              txtBH.Text = Functions.GetFieldValues(str);*/
        }

        private void btnInhoadon_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Cửa hàng bán chậu cây cảnh Hoàng Quy";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Vĩnh Yên - Vĩnh Phúc";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: 0123456789";
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //red
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.Mahoadon, a.Ngayban, b.Tenkhachhang, b.Diachi, b.Dienthoai, c.Tennhanvien FROM tblHoadon AS a, tblKhachhang AS b, tblNhanvien AS c WHERE a.Mahoadon = N'" + txtMaHDBan.Text + "' AND a.Makhachhang = b.Makhachhang AND a.Manhanvien = c.Manhanvien";
            tblThongtinHD = Functions.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT b.Tenhaucay, a.Soluong, b.Dongia, a.Giamgia " +
                  "FROM tblChitiethoadon AS a , tblChaucay AS b WHERE a.Mahoadon = N'" +
                  txtMaHDBan.Text + "' AND a.Machaucay = b.Machaucay";
            tblThongtinHang = Functions.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Giảm giá";
            for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblThongtinHang.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
                    if (cot == 3) exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString() + "%";
                }
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            // exRange.Range["A1:F1"].Value = "Bằng chữ: " + Functions.ChuyenSoSangChu(tblThongtinHD.Rows[0][2].ToString());
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }
    }
    
}
