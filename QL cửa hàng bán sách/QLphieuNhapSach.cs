using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace QL_cửa_hàng_bán_sách
{
    public partial class QLphieuNhapSach : Form
    {
        public QLphieuNhapSach()
        {
            InitializeComponent();
        }
        //load form quản lý phiếu nhập
        private void loadDSPN()
        {
            string contr = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;
            using (SqlConnection con = new SqlConnection(contr))
            {
                using (SqlCommand cmd = new SqlCommand("select iSoHDNhap as [Số hóa đơn nhập], iMaNV as[Mã nhân viên],dNgayNhap as [Ngày nhập] from tblHoaDonNhap ", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter adt = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adt.Fill(dt);
                        dataGridViewPN.DataSource = dt;


                    }
                }
            }
        }

        //xử lý load chi tiết phiếu nhập
        private void loadDSCTPN()
        {
            string contr = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;
            using (SqlConnection con = new SqlConnection(contr))
            {
                using (SqlCommand cmd = new SqlCommand("select iSoHDNhap as [Số hóa đơn nhập], iMaSach as[Mã sách],fGiaNhap as[Giá nhập], fSoLuongNhap as[Số lượng nhập] from tblChiTietNhap ", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter adt = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adt.Fill(dt);
                        dataGridViewCTPN.DataSource = dt;


                    }
                }
            }
        }
        //gọi sự kiện load lên form
        private void QLphieuNhapSach_Load(object sender, EventArgs e)
        {
            loadDSPN();
            loadDSCTPN();
        }

        //tìm phiếu nhập qua mã
        private void btnTimPN_Click(object sender, EventArgs e)
        {
            if (txttimMaPN.Text == "")
            {
                MessageBox.Show("vui lòng mã phiếu nhập cần tìm", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttimMaPN.Focus();

            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;
                    string sqltk = "select * from tblHoaDonNhap where iSoHDNhap  = " + txttimMaPN.Text;
                    SqlCommand cmd = new SqlCommand(sqltk, con);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);
                    dataGridViewPN.DataSource = dt;



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //cellclick phiếu nhập
        private void dataGridViewPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            int i;

            i = dataGridViewPN.CurrentCell.RowIndex;
            txtMaPN.Text = dataGridViewPN.Rows[i].Cells[0].Value.ToString();
            txtMaPN_NV.Text = dataGridViewPN.Rows[i].Cells[1].Value.ToString();
            DTPNgaynhap.Text = dataGridViewPN.Rows[i].Cells[2].Value.ToString();
            //if ((bool)(dataGridViewPN.Rows[i].Cells[0].Value = dataGridViewCTPN.Rows[j].Cells[0].Value))
            //  {
            try
            {

                //int j;
                //       j = dataGridViewCTPN.CurrentCell.RowIndex;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;
                string sqltk = "select iSoHDNhap as [Số Hóa đơn nhập],iMaSach as[Mã sách], fGiaNhap as[Giá nhập], fSoLuongNhap as[Số lượng nhập]  from tblChiTietNhap where iSoHDNhap = " + int.Parse(dataGridViewPN.Rows[i].Cells[0].Value.ToString());
                
                SqlCommand cmd = new SqlCommand(sqltk, con);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                dataGridViewCTPN.DataSource = dt;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //  }
            // for(int j=0; i = dataGridViewPN.cu )
        }

        public void resetPN()
        {
            txtMaPN.Text = "";
            txtMaPN_NV.Text = "";

            DTPNgaynhap.Text = "";

        }
        public bool ktrthongtinPN()
        {
            if (txtMaPN.Text == "")
            {
                MessageBox.Show("vui lòng nhập mã phiếu nhập", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaPN.Focus();
                return false;

            }
            if (txtMaPN_NV.Text == "")
            {
                MessageBox.Show("vui lòng nhập mã nhân viên", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaPN_NV.Focus();
                return false;

            }

            return true;
        }
        //xử lý button thêm cho phiếu nhập
        private void btnThemPN_Click(object sender, EventArgs e)
        {
            if (ktrthongtinPN())
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;
                    // string contr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    // string commtext = "update tblNhanvien set iMaNV = @ma, sHoTenNV = @ten, sGioiTinh = @gtinh, dNgaysinh = @ngaysinh, sdienthoai = @sdt, sDiachi = @dchi, fluong = @luong";

                    cmd.CommandText = "pr_themPN";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@mapn", txtMaPN.Text);
                    cmd.Parameters.AddWithValue("@manv", txtMaPN_NV.Text);
                    cmd.Parameters.AddWithValue("@ngaynhap", DTPNgaynhap.Value.Date);


                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    loadDSPN();
                    resetPN();

                    MessageBox.Show("đã thêm phiếu nhập thành công!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }

        }


        //button sửa phiếu nhập
        private void btnSuaPN_Click(object sender, EventArgs e)
        {
            MessageBox.Show("không được phép sửa hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        //reset phiếu nhập
        private void btnresetPN_Click(object sender, EventArgs e)
        {
            loadDSPN();
            resetPN();
        }
        //cellclick cho chi tiết phiếu nhập
        private void dataGridViewCTPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridViewCTPN.CurrentCell.RowIndex;
            txtmaCTPN.Text = dataGridViewCTPN.Rows[i].Cells[0].Value.ToString();
            txtPN_MaS.Text = dataGridViewCTPN.Rows[i].Cells[1].Value.ToString();
            txtCTPN_Gianhap.Text = dataGridViewCTPN.Rows[i].Cells[2].Value.ToString();
            txtSoLuongNhap.Text = dataGridViewCTPN.Rows[i].Cells[3].Value.ToString();
        }
        //reset và ktra thông tin chi tiết phiếu nhâp
        public void resetCTPN()
        {
            txtmaCTPN.Text = "";
            txtPN_MaS.Text = "";
            txtCTPN_Gianhap.Text = "";
            txtSoLuongNhap.Text = "";
        }
        public bool ktrthongtinCTPN()
        {
            if (txtmaCTPN.Text == "")
            {
                MessageBox.Show("vui lòng nhập mã phiếu nhập", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmaCTPN.Focus();
                return false;

            }
            if (txtPN_MaS.Text == "")
            {
                MessageBox.Show("vui lòng nhập mã sách", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPN_MaS.Focus();
                return false;

            }
            if (txtCTPN_Gianhap.Text == "")
            {
                MessageBox.Show("vui lòng nhập Giá nhập sách", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCTPN_Gianhap.Focus();
                return false;

            }
            if (txtSoLuongNhap.Text == "")
            {
                MessageBox.Show("vui lòng nhập Số lượng sách ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuongNhap.Focus();
                return false;

            }
            return true;
        }

        private void btnthemCTPN_Click(object sender, EventArgs e)
        {
            if (ktrthongtinCTPN())
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;
                    // string contr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    // string commtext = "update tblNhanvien set iMaNV = @ma, sHoTenNV = @ten, sGioiTinh = @gtinh, dNgaysinh = @ngaysinh, sdienthoai = @sdt, sDiachi = @dchi, fluong = @luong";

                    cmd.CommandText = "pr_themCTPN";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@mapn", txtmaCTPN.Text);
                    cmd.Parameters.AddWithValue("@mas", txtPN_MaS.Text);
                    cmd.Parameters.AddWithValue("@gianhap", txtCTPN_Gianhap.Text);
                    cmd.Parameters.AddWithValue("@soluong", txtSoLuongNhap.Text);

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    loadDSCTPN();
                    resetCTPN();

                    MessageBox.Show("đã thêm chi tiết phiếu nhập thành công!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void btnSuaCTPN_Click(object sender, EventArgs e)
        {
            MessageBox.Show("không được phép sửa hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnResetCTPN_Click(object sender, EventArgs e)
        {
            loadDSCTPN();
            resetCTPN();
        }

        private void btnTimCTPN_Click(object sender, EventArgs e)
        {
            if (txtTimCTPN.Text == "")
            {
                MessageBox.Show("vui lòng mã phiếu nhập cần tìm", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTimCTPN.Focus();

            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;
                    string sqltk = "select * from tblChiTietNhap where iSoHDNhap  = " + txtTimCTPN.Text;
                    SqlCommand cmd = new SqlCommand(sqltk, con);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);
                    dataGridViewCTPN.DataSource = dt;



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnThoatPN_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát?", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dg == DialogResult.OK)
            {
                fdangnhap fdangnhap = new fdangnhap();
                this.Hide();
                fdangnhap.ShowDialog();
                this.Show();

            }

        }

    }    
}
