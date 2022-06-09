using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_cửa_hàng_bán_sách
{
    public partial class form_quanly : Form
    {
        public form_quanly()
        {
            InitializeComponent();
        }

       
       

        private void btnqlPhieunhap_Click(object sender, EventArgs e)
        {
            QLphieuNhapSach qLphieuNhapSach = new QLphieuNhapSach();
            this.Hide();
            qLphieuNhapSach.ShowDialog();
            this.Show();
        }

       

        private void kháchHàngThânThiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLkhachhang qLkhachhang = new QLkhachhang();
            this.Hide();
            qLkhachhang.ShowDialog();
            this.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formQLNhanVien formQLNhanVien = new formQLNhanVien();
            this.Hide();
            formQLNhanVien.ShowDialog();
            this.Show();
        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLSachbao qLSachbao = new QLSachbao();
            this.Hide();
            qLSachbao.ShowDialog();
            this.Show();
        }

        private void tbnQLhoadon_Click(object sender, EventArgs e)
        {
            QLHoadonXuat qLHoadonXuat = new QLHoadonXuat();
            this.Hide();
            qLHoadonXuat.ShowDialog();
            this.Show();
        }

        private void btnDThu_ngay_Click(object sender, EventArgs e)
        {

        }
    }
}
