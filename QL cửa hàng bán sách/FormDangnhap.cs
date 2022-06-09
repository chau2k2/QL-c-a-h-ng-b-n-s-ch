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
    public partial class fdangnhap : Form
    {
        public fdangnhap()
        {
            InitializeComponent();
        }

        private void btDangnhap_Click(object sender, EventArgs e)
        {
             
             try
             {
                string name = txttaikhoan.Text;
               string mk = txtmk.Text;


                if (name == "Châu" )
                {
                    if (mk == "123456")
                    {
                    form_quanly form_Quanly = new form_quanly();
                    this.Hide();
                    form_Quanly.ShowDialog();
                    this.Show();
                    }
                    
                  }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

             }
             catch (Exception ex)

             {
                 MessageBox.Show(ex.Message);
             }
            
           
            
        }
      //  bool login(string username, string password)
      //  {


       //     return taikhoan.Instance.login(username, password);
       // }
        private void btthoat_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("bạn có muốn thoát?", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dg == DialogResult.OK)
            {
                Application.Exit();

            }
        }

        private void ckbHienmk_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbHienmk.Checked)
            {
                txtmk.PasswordChar = (char)0;
            }
            else
            {
                txtmk.PasswordChar = '*';
            }
        }
    }
}
