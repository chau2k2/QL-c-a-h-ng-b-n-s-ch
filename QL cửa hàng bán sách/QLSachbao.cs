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
    public partial class QLSachbao : Form
    {
        public QLSachbao()
        {
            InitializeComponent();
        }

        private void loadDSSB()
        {
            string contr = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;
            using (SqlConnection con = new SqlConnection(contr))
            {
                using (SqlCommand cmd = new SqlCommand("select iMaSach as[Mã sách],sTenSach as [Tên sách],sTacGia as[Tác giả],iMaNXB as [Mã Nhà xuất bản],sMaLoaiSach as[Mã loại sách], fSoLuong as[Số lượng],itongSLban as[Tổng số lượng bán được]  from tblSachBao ", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter adt = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adt.Fill(dt);
                        dataGridViewS.DataSource = dt;


                    }
                }
            }

        }

        private void QLSachbao_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bTL_SQLDataSet.tblLoaiSach' table. You can move, or remove it, as needed.
            this.tblLoaiSachTableAdapter.Fill(this.bTL_SQLDataSet.tblLoaiSach);
            loadDSSB();
        }
        //cell click
        private void dataGridViewS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridViewS.CurrentCell.RowIndex;
            txtMaS.Text = dataGridViewS.Rows[i].Cells[0].Value.ToString();
            txtTenS.Text = dataGridViewS.Rows[i].Cells[1].Value.ToString();
            txtTacgia.Text = dataGridViewS.Rows[i].Cells[2].Value.ToString();
            txtNXB.Text = dataGridViewS.Rows[i].Cells[3].Value.ToString();
            txtLoaiS.Text = dataGridViewS.Rows[i].Cells[4].Value.ToString();
            txtSluongS.Text = dataGridViewS.Rows[i].Cells[5].Value.ToString();
            txtSLbandc.Text = dataGridViewS.Rows[i].Cells[6].Value.ToString();
        }
        //button thêm
        public void resetS()
        {
            txtMaS.Text = "";
            txtTenS.Text = "";
            txtTacgia.Text = "";
            txtNXB.Text = "";
            txtLoaiS.Text = "";
            txtSluongS.Text = "";
            txtSLbandc.Text = "";

            
        }

        public bool ktrThongTinS()
        {
            if (txtMaS.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã Sách báo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaS.Focus();
                return false;
            }
            if (txtTenS.Text == "")
            {
                MessageBox.Show("Vui lòng nhập họ tên sách báo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenS.Focus();
                return false;
            }
            return true;
        }
        private void btnThemS_Click(object sender, EventArgs e)

        {
            int i;
            i = dataGridViewS.CurrentCell.RowIndex;
            if (txtMaS.Text == dataGridViewS.Rows[i].Cells[0].Value.ToString() && txtTenS.Text == dataGridViewS.Rows[i].Cells[1].Value.ToString() && ktrThongTinS())
            {
                MessageBox.Show("Mã và tên sách được thêm không được trùng với mã và tên sách đã có!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaS.Focus();
                txtTenS.Focus();
                    
                    }
            else 
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "pr_ThemSB";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@mas", txtMaS.Text);
                    cmd.Parameters.AddWithValue("@tens", txtTenS.Text);
                    cmd.Parameters.AddWithValue("@tacgia", txtTacgia.Text);
                    cmd.Parameters.AddWithValue("@maNXB", txtNXB.Text);
                    cmd.Parameters.AddWithValue("@maloais", txtLoaiS.Text);
                    cmd.Parameters.AddWithValue("@soluong", txtSluongS.Text);
                    cmd.Parameters.AddWithValue("@soluongban", txtSLbandc.Text);

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    loadDSSB();
                    resetS();

                    MessageBox.Show("Đã thêm Sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void btntimS_LS_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;


                string sqltk = " select iMaSach as[Mã sách],sTenSach as [Tên sách],sTacGia as[Tác giả],iMaNXB as [Mã Nhà xuất bản],sMaLoaiSach as[Mã thể loại], fSoLuong as[Số lượng],itongSLban as[Tổng số lượng bán được] from tblSachBao where sMaLoaiSach = ( select sMaLoaiSach from tblLoaiSach where sTenLoaiSach=N'" + ccbtimTenLS.Text + "')";
                SqlCommand cmd = new SqlCommand(sqltk, con);

                /* cmd.CommandText = "pr_timNV";
                 cmd.CommandType = CommandType.StoredProcedure;

                 cmd.Parameters.AddWithValue("@tennv", txttimNV.Text);*/

                SqlDataAdapter sql = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sql.Fill(dt);
                dataGridViewS.DataSource = dt;




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void btnTimS_Click(object sender, EventArgs e)
        {

            if (txttimS.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên sách cần tìm", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttimS.Focus();
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;


                    string sqltk = "select iMaSach as[Mã sách],sTenSach as [Tên sách],sTacGia as[Tác giả],iMaNXB as [Mã Nhà xuất bản],sMaLoaiSach as[Mã thể loại], fSoLuong as[Số lượng],itongSLban as[Tổng số lượng bán được] from tblSachBao where LOWER(sTenSach) like N'%" + txttimS.Text + "%'";
                    SqlCommand cmd = new SqlCommand(sqltk, con);

                    /* cmd.CommandText = "pr_timNV";
                     cmd.CommandType = CommandType.StoredProcedure;

                     cmd.Parameters.AddWithValue("@tennv", txttimNV.Text);*/

                    SqlDataAdapter sql = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sql.Fill(dt);
                    dataGridViewS.DataSource = dt;




                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnresetS_Click(object sender, EventArgs e)
        {
            loadDSSB();
            resetS();
        }

        private void btnSuaS_Click(object sender, EventArgs e)
        {
            if (ktrThongTinS())
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "pr_suaSB";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@mas", txtMaS.Text);
                    cmd.Parameters.AddWithValue("@tens", txtTenS.Text);
                    cmd.Parameters.AddWithValue("@tacgia", txtTacgia.Text);
                    cmd.Parameters.AddWithValue("@maNXB", txtNXB.Text);
                    cmd.Parameters.AddWithValue("@maloais", txtLoaiS.Text);
                    cmd.Parameters.AddWithValue("@soluong", txtSluongS.Text);
                    cmd.Parameters.AddWithValue("@soluongban", txtSLbandc.Text);

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    loadDSSB();
                    resetS();

                    MessageBox.Show("Đã sửa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnXoaS_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Không thể xóa sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            report rp = new report();
            this.Hide();
            rp.ShowDialog();
            this.Show();
        }
    }
}
