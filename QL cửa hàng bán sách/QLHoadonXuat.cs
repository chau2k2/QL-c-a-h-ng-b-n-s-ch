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
    public partial class QLHoadonXuat : Form
    {
        public QLHoadonXuat()
        {
            InitializeComponent();
        }
        private void loadDSHD()
        {
            string contr = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;
            using (SqlConnection con = new SqlConnection(contr))
            {
                using (SqlCommand cmd = new SqlCommand("select iSoHDXuat as[Số hóa đơn xuất],iMaNV as[Mã Nhân viên], iMaKH as[mã khách hàng], dNgayMua as[Ngày mua], dNgayGiaoHang as[Ngày giao hàng], sDiaChiGiaoHang as[Địa chỉ giao hàng]  from tblHoaDonXuat ", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter adt = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adt.Fill(dt);
                        dataGridViewHD.DataSource = dt;


                    }
                }
            }
        }

        //xử lý load chi tiết phiếu nhập
        private void loadDSCTHD()
        {
            string contr = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;
            using (SqlConnection con = new SqlConnection(contr))
            {
                using (SqlCommand cmd = new SqlCommand("select iSoHDXuat as[số hóa đơn xuất], iMaSach as[Mã sách], fGiaBan as[Giá bán], fSoLuongMua as[Số lượng], fMucGiamGia as[Mức giảm giá] from tblChiTietHD", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter adt = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adt.Fill(dt);
                        dataGridViewCTHD.DataSource = dt;


                    }
                }
            }
        }


        private void btnInHD_Click(object sender, EventArgs e)
        {
            InHoaDon inHoaDon = new InHoaDon();
            this.Hide();
            inHoaDon.ShowDialog();
            this.Show();

        }
        public void resetHD()
        {
            txtMaHDX.Text = "";
            txtMaHDX_NV.Text = "";
            DTPNgaymua.Text = "";
            txtHDX_KH.Text = "";


            

        }

        public void resetCTHD()
        {
            txtSoCTHD.Text = "";
            txtcthd_maS.Text = "";
            txtgiaban.Text = "";
            soluong.Text = "";
            txtmucgiamgia.Text = "";

            dtpngaygiaohang.Text = "";

        }

        public bool ktrthongtinHD()
        {
            if (txtMaHDX.Text == "")
            {
                MessageBox.Show("vui lòng nhập mã hóa đơn xuất", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHDX.Focus();
                return false;

            }
            if (txtMaHDX_NV.Text == "")
            {
                MessageBox.Show("vui lòng nhập mã nhân viên", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHDX_NV.Focus();
                return false;

            }

            return true;
        }

        public bool ktrthongtinCTHD()
        {
            if (txtSoCTHD.Text == "")
            {
                MessageBox.Show("vui lòng nhập mã hóa đơn xuất", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoCTHD.Focus();
                return false;

            }
            if (txtcthd_maS.Text == "")
            {
                MessageBox.Show("vui lòng nhập mã sách", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHDX_NV.Focus();
                return false;

            }

            return true;
        }
        private void btnThemHD_Click(object sender, EventArgs e)
        {
            if (ktrthongtinHD() )
            {

            }
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;
                    // string contr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    // string commtext = "update tblNhanvien set iMaNV = @ma, sHoTenNV = @ten, sGioiTinh = @gtinh, dNgaysinh = @ngaysinh, sdienthoai = @sdt, sDiachi = @dchi, fluong = @luong";

                    cmd.CommandText = "pr_ThemHD";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@sohd", txtMaHDX.Text);
                    cmd.Parameters.AddWithValue("@manv", txtMaHDX_NV.Text);
                    cmd.Parameters.AddWithValue("@makh", txtHDX_KH.Text);
                    cmd.Parameters.AddWithValue("@ngaymua", DTPNgaymua.Value.Date);
                    cmd.Parameters.AddWithValue("@ngaygiaohang", DTPNgaymua.Value.Date);
                    cmd.Parameters.AddWithValue("@diachiGH", txtDCGiaohang.Text);

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    loadDSHD();
                    resetHD();

                    MessageBox.Show("đã thêm hóa đơn thành công!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void btnthemCTHD_Click(object sender, EventArgs e)
        {
            if (ktrthongtinCTHD() && int.Parse( soluong.Text) >10    )
            {
                MessageBox.Show("Không cho phép 1 người có thể mua nhiều hơn 10 cuốn sách của 1 đầu sách!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                soluong.Focus();
                
            }    else
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;
                    // string contr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    // string commtext = "update tblNhanvien set iMaNV = @ma, sHoTenNV = @ten, sGioiTinh = @gtinh, dNgaysinh = @ngaysinh, sdienthoai = @sdt, sDiachi = @dchi, fluong = @luong";

                    cmd.CommandText = "pr_themCTHD";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@sohd", txtSoCTHD.Text);
                    cmd.Parameters.AddWithValue("@mas", txtcthd_maS.Text);
                    cmd.Parameters.AddWithValue("@giaban", txtgiaban.Text);
                    cmd.Parameters.AddWithValue("@soluong", soluong.Text);
                    cmd.Parameters.AddWithValue("@mucgia", txtmucgiamgia.Text);

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    loadDSCTHD();
                    resetCTHD();

                    MessageBox.Show("đã thêm chi tiết hóa đơn thành công!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
               
            }
        }

        private void btnresetHD_Click(object sender, EventArgs e)
        {
            
            loadDSHD();
            resetHD();
        }

        private void btnresetCTHD_Click(object sender, EventArgs e)
        {
            loadDSCTHD();
            resetCTHD();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            fdangnhap dn = new fdangnhap();
            this.Hide();
            dn.ShowDialog();
            this.Show();

        }

        private void btnTimHD_Click(object sender, EventArgs e)
        {

            if (txttimHD_ma.Text == "")
            {
                MessageBox.Show("vui lòng mã hóa đơn cần tìm", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttimHD_ma.Focus();

            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;
                    string sqltk = "select * from tblHoaDonXuat where iSoHDXuat  = " + txttimHD_ma.Text;
                    SqlCommand cmd = new SqlCommand(sqltk, con);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);
                    dataGridViewHD.DataSource = dt;



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btntimCTHD_ma_Click(object sender, EventArgs e)
        {
            if (txtSoCTHD.Text == "")
            {
                MessageBox.Show("vui lòng mã hóa đơn cần tìm", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoCTHD.Focus();

            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;
                    string sqltk = "select * from tblChiTietHD where iSoHDXuat  = " + txttimCTHD_ma.Text;
                    SqlCommand cmd = new SqlCommand(sqltk, con);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);
                    dataGridViewCTHD.DataSource = dt;



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void QLHoadonXuat_Load(object sender, EventArgs e)
        {
            loadDSHD();
            loadDSCTHD();
        }

        private void dataGridViewHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;

            i = dataGridViewHD.CurrentCell.RowIndex;
            txtMaHDX.Text = dataGridViewHD.Rows[i].Cells[0].Value.ToString();
            txtMaHDX_NV.Text = dataGridViewHD.Rows[i].Cells[1].Value.ToString();
            txtHDX_KH.Text = dataGridViewHD.Rows[i].Cells[2].Value.ToString();
            DTPNgaymua.Text = dataGridViewHD.Rows[i].Cells[3].Value.ToString();
            dtpngaygiaohang.Text = dataGridViewHD.Rows[i].Cells[4].Value.ToString();
            txtDCGiaohang.Text = dataGridViewHD.Rows[i].Cells[5].Value.ToString();

            //if ((bool)(dataGridViewPN.Rows[i].Cells[0].Value = dataGridViewCTPN.Rows[j].Cells[0].Value))
            //  {
            try
            {

                //int j;
                //       j = dataGridViewCTPN.CurrentCell.RowIndex;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;
                string sqltk = "select iSoHDXuat as[số hóa đơn xuất], iMaSach as[Mã sách], fGiaBan as[Giá bán], fSoLuongMua as[Số lượng], fMucGiamGia as[Mức giảm giá] from tblChiTietHD where iSoHDXuat = " + int.Parse(dataGridViewHD.Rows[i].Cells[0].Value.ToString());
                SqlCommand cmd = new SqlCommand(sqltk, con);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                dataGridViewCTHD.DataSource = dt;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewCTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridViewCTHD.CurrentCell.RowIndex;
            txtSoCTHD.Text = dataGridViewCTHD.Rows[i].Cells[0].Value.ToString();
            txtcthd_maS.Text = dataGridViewCTHD.Rows[i].Cells[1].Value.ToString();
            txtgiaban.Text = dataGridViewCTHD.Rows[i].Cells[2].Value.ToString();
            soluong.Text = dataGridViewCTHD.Rows[i].Cells[3].Value.ToString();
            txtmucgiamgia.Text = dataGridViewCTHD.Rows[i].Cells[4].Value.ToString();
        }
    }
}
