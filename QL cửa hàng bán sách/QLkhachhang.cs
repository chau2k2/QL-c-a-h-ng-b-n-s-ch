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
    public partial class QLkhachhang : Form
    {
        public QLkhachhang()
        {
            InitializeComponent();
        }
        //xử lý loaddata
        private void loadDSKH()
        {
            string contr = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;
            using (SqlConnection con = new SqlConnection(contr))
            {
                using (SqlCommand cmd = new SqlCommand("select iMaKH as [Mã khách hàng], sTenKH as[Tên khách hàng], sGioiTinh as[Giới tính], sDiaChi as[Địa chỉ], sDienThoai as[SĐT] from tblKhachHang ", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter adt = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adt.Fill(dt);
                        dataGridViewKH.DataSource = dt;


                    }
                }
            }

        }
        private void QLkhachhang_Load(object sender, EventArgs e)
        {
            loadDSKH();
        }
        //xử lý cellclick 
        private void dataGridViewKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridViewKH.CurrentCell.RowIndex;
            txtMaKH.Text = dataGridViewKH.Rows[i].Cells[0].Value.ToString();
            txtTenKH.Text = dataGridViewKH.Rows[i].Cells[1].Value.ToString();
            txtDchiKH.Text = dataGridViewKH.Rows[i].Cells[3].Value.ToString();
            txtSDTKH.Text = dataGridViewKH.Rows[i].Cells[4].Value.ToString();

            if (this.dataGridViewKH.Rows[i].Cells[2].Value.Equals("NAM"))
            {
                rdbtnNamKH.Checked = true;
            }
            else rdbtnNuKH.Checked = true;
            
        }


        //xử lý reset và ktra thông tin khách hàng
        public void resetKH()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtDchiKH.Text = "";
            txtSDTKH.Text = "";
            rdbtnNamKH.Checked = false;
            rdbtnNuKH.Checked = false;
        }

        public bool ktrThongTinKH()
        {
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKH.Focus();
                return false;
            }
            if (txtTenKH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập họ tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKH.Focus();
                return false;
            }
            return true;
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            if (ktrThongTinKH())
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "pr_themKH";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@makh", txtMaKH.Text);
                    cmd.Parameters.AddWithValue("@tenkh", txtTenKH.Text);
                    cmd.Parameters.AddWithValue("@diachi", txtDchiKH.Text);
                    cmd.Parameters.AddWithValue("@SDT", txtSDTKH.Text);
                    if (rdbtnNamKH.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@gioitinh", "NAM");
                    }
                    else
                        cmd.Parameters.AddWithValue("@gioitinh", "NỮ");

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    loadDSKH();
                    resetKH();

                    MessageBox.Show("Đã thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            if (ktrThongTinKH())
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "pr_suaKH";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@manv", txtMaKH.Text);
                    cmd.Parameters.AddWithValue("@tennv", txtTenKH.Text);
                    cmd.Parameters.AddWithValue("@diachi", txtDchiKH.Text);
                    cmd.Parameters.AddWithValue("@SDT", txtSDTKH.Text);

                    if (rdbtnNamKH.Checked == true)
                    {
                        cmd.Parameters.AddWithValue("@gioitinh", "NAM");
                    }
                    else
                        cmd.Parameters.AddWithValue("@gioitinh", "NỮ");
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    loadDSKH();
                    resetKH();

                    MessageBox.Show("Đã sửa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            if (ktrThongTinKH())
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "pr_xoaKH";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@makh", txtMaKH.Text);


                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    loadDSKH();
                    resetKH();

                    MessageBox.Show("Đã xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnTimKH_Click(object sender, EventArgs e)
        {
            if (txttimKH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng cần tìm", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttimKH.Focus();
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;


                    string sqltk = "select * from tblKhachHang where LOWER(sTenKH) like N'%" + txttimKH.Text + "%'";
                    SqlCommand cmd = new SqlCommand(sqltk, con);

                    /* cmd.CommandText = "pr_timNV";
                     cmd.CommandType = CommandType.StoredProcedure;

                     cmd.Parameters.AddWithValue("@tennv", txttimNV.Text);*/

                    SqlDataAdapter sql = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sql.Fill(dt);
                    dataGridViewKH.DataSource = dt;




                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnresetKH_Click(object sender, EventArgs e)
        {
            loadDSKH();
            resetKH();
        }

        private void btnThoat_Click(object sender, EventArgs e)
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
