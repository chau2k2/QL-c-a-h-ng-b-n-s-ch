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
    public partial class formQLNhanVien : Form
    {
        public formQLNhanVien()
        {
            InitializeComponent();
        }

        //làm quản lý nhân viên 
        //load datagrid view 
        private void loadDSNV()
        {
            string contr = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;
             using(SqlConnection con = new SqlConnection(contr))
            {
                using (SqlCommand cmd = new SqlCommand("select iMaNV as [Mã nhân viên], sTenNV as[Tên nhân viên], sDiaChi as[Địa chỉ], sDienThoai as[SĐT], dNgaySinh as [Ngày sinh], dNgayVaoLam as [Ngày vào làm], fLuong as[Lương], fPhuCap as [Phụ Cấp] from tblNhanVien ", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using(SqlDataAdapter adt = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adt.Fill(dt);
                        dataGridViewNV.DataSource = dt;

                        
                    }
                }
            }
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            loadDSNV();
        }
        //xử lý cellclick 
        private void dataGridViewNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridViewNV.CurrentCell.RowIndex;
            txtMaNV.Text = dataGridViewNV.Rows[i].Cells[0].Value.ToString();
            txtTenNV.Text = dataGridViewNV.Rows[i].Cells[1].Value.ToString();
            txtDchiNV.Text = dataGridViewNV.Rows[i].Cells[2].Value.ToString();
            txtSDT.Text = dataGridViewNV.Rows[i].Cells[3].Value.ToString();
            DTPNgaysinhNV.Text = dataGridViewNV.Rows[i].Cells[4].Value.ToString();
            DTPNgayvaolamNV.Text = dataGridViewNV.Rows[i].Cells[5].Value.ToString();
            txtLuong.Text = dataGridViewNV.Rows[i].Cells[6].Value.ToString();
            txtPhuCap.Text = dataGridViewNV.Rows[i].Cells[7].Value.ToString();
        }


        //xử lý reset và ktra thông tin nhân viên
        public void resetNV()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtDchiNV.Text = "";
            txtSDT.Text = "";
            DTPNgaysinhNV.Text = "";
            DTPNgayvaolamNV.Text = "";
            txtLuong.Text = "";
            txtPhuCap.Text = "";
        }

        public bool ktrThongTinNV()
        {
            if(txtMaNV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Focus();
                return false;
            }
            if(txtTenNV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập họ tên nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNV.Focus();
                return false;
            }
            return true;
        }

        private void btnThemnv_Click(object sender, EventArgs e)
        {
            if (ktrThongTinNV())
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "pr_themNV";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@manv", txtMaNV.Text);
                    cmd.Parameters.AddWithValue("@tennv", txtTenNV.Text);
                    cmd.Parameters.AddWithValue("@diachi", txtDchiNV.Text);
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                    cmd.Parameters.AddWithValue("@ngaysinh", DTPNgaysinhNV.Value.Date);
                    cmd.Parameters.AddWithValue("@ngayvaolam", DTPNgayvaolamNV.Value.Date);
                    cmd.Parameters.AddWithValue("@luong", txtLuong.Text);
                    cmd.Parameters.AddWithValue("@phucap", txtPhuCap.Text);

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    loadDSNV();
                    resetNV();

                    MessageBox.Show("Đã thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            if(ktrThongTinNV ())
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "pr_suaNV";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@manv", txtMaNV.Text);
                    cmd.Parameters.AddWithValue("@tennv", txtTenNV.Text);
                    cmd.Parameters.AddWithValue("@diachi", txtDchiNV.Text);
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                    cmd.Parameters.AddWithValue("@ngaysinh", DTPNgaysinhNV.Value.Date);
                    cmd.Parameters.AddWithValue("@ngayvaolam", DTPNgayvaolamNV.Value.Date);
                    cmd.Parameters.AddWithValue("@luong", txtLuong.Text);
                    cmd.Parameters.AddWithValue("@phucap", txtPhuCap.Text);

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    loadDSNV();
                    resetNV();

                    MessageBox.Show("Đã sửa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }    
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            if (ktrThongTinNV())
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "pr_xoaNV";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@manv", txtMaNV.Text);
                   

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    loadDSNV();
                    resetNV();

                    MessageBox.Show("Đã xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnTimNV_Click(object sender, EventArgs e)
        {
            if (txttimNV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên cần tìm", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttimNV.Focus();
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;


                    string sqltk = "select * from tblNhanVien where LOWER(sTenNV) like N'%" + txttimNV.Text +"%'";
                    SqlCommand cmd = new SqlCommand(sqltk,con);

                   /* cmd.CommandText = "pr_timNV";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@tennv", txttimNV.Text);*/

                    SqlDataAdapter sql =new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sql.Fill(dt);
                    dataGridViewNV.DataSource = dt;
                   



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            loadDSNV();
            resetNV();
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

