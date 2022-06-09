
namespace QL_cửa_hàng_bán_sách
{
    partial class form_quanly
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_quanly));
            this.label1 = new System.Windows.Forms.Label();
            this.tbnQLhoadon = new System.Windows.Forms.Button();
            this.btnDThu_ngay = new System.Windows.Forms.Button();
            this.btnqlPhieunhap = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kháchHàngThânThiếtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDT_thang = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(205, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý cửa hàng bán sách";
            // 
            // tbnQLhoadon
            // 
            this.tbnQLhoadon.Location = new System.Drawing.Point(240, 82);
            this.tbnQLhoadon.Name = "tbnQLhoadon";
            this.tbnQLhoadon.Size = new System.Drawing.Size(179, 64);
            this.tbnQLhoadon.TabIndex = 2;
            this.tbnQLhoadon.Text = "Quản lý hóa đơn";
            this.tbnQLhoadon.UseVisualStyleBackColor = true;
            this.tbnQLhoadon.Click += new System.EventHandler(this.tbnQLhoadon_Click);
            // 
            // btnDThu_ngay
            // 
            this.btnDThu_ngay.Location = new System.Drawing.Point(23, 200);
            this.btnDThu_ngay.Name = "btnDThu_ngay";
            this.btnDThu_ngay.Size = new System.Drawing.Size(179, 64);
            this.btnDThu_ngay.TabIndex = 4;
            this.btnDThu_ngay.Text = "Tổng doanh thu bán được theo ngày";
            this.btnDThu_ngay.UseVisualStyleBackColor = true;
            this.btnDThu_ngay.Click += new System.EventHandler(this.btnDThu_ngay_Click);
            // 
            // btnqlPhieunhap
            // 
            this.btnqlPhieunhap.Location = new System.Drawing.Point(23, 82);
            this.btnqlPhieunhap.Name = "btnqlPhieunhap";
            this.btnqlPhieunhap.Size = new System.Drawing.Size(179, 64);
            this.btnqlPhieunhap.TabIndex = 6;
            this.btnqlPhieunhap.Text = "Quản lý phiếu nhập sách";
            this.btnqlPhieunhap.UseVisualStyleBackColor = true;
            this.btnqlPhieunhap.Click += new System.EventHandler(this.btnqlPhieunhap_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "In Báo cáo :";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhMụcToolStripMenuItem,
            this.tàiKhoảnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(681, 28);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sáchToolStripMenuItem,
            this.nhânViênToolStripMenuItem,
            this.kháchHàngThânThiếtToolStripMenuItem});
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.danhMụcToolStripMenuItem.Text = "Danh mục";
            // 
            // sáchToolStripMenuItem
            // 
            this.sáchToolStripMenuItem.Name = "sáchToolStripMenuItem";
            this.sáchToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.sáchToolStripMenuItem.Text = "Sách ";
            this.sáchToolStripMenuItem.Click += new System.EventHandler(this.sáchToolStripMenuItem_Click);
            // 
            // nhânViênToolStripMenuItem
            // 
            this.nhânViênToolStripMenuItem.Name = "nhânViênToolStripMenuItem";
            this.nhânViênToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.nhânViênToolStripMenuItem.Text = "Nhân Viên ";
            this.nhânViênToolStripMenuItem.Click += new System.EventHandler(this.nhânViênToolStripMenuItem_Click);
            // 
            // kháchHàngThânThiếtToolStripMenuItem
            // 
            this.kháchHàngThânThiếtToolStripMenuItem.Name = "kháchHàngThânThiếtToolStripMenuItem";
            this.kháchHàngThânThiếtToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.kháchHàngThânThiếtToolStripMenuItem.Text = "Khách hàng thân thiết";
            this.kháchHàngThânThiếtToolStripMenuItem.Click += new System.EventHandler(this.kháchHàngThânThiếtToolStripMenuItem_Click);
            // 
            // tàiKhoảnToolStripMenuItem
            // 
            this.tàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thoátToolStripMenuItem});
            this.tàiKhoảnToolStripMenuItem.Name = "tàiKhoảnToolStripMenuItem";
            this.tàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.tàiKhoảnToolStripMenuItem.Text = "Tài khoản";
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(130, 26);
            this.thoátToolStripMenuItem.Text = "Thoát";
            // 
            // btnDT_thang
            // 
            this.btnDT_thang.Location = new System.Drawing.Point(240, 200);
            this.btnDT_thang.Name = "btnDT_thang";
            this.btnDT_thang.Size = new System.Drawing.Size(179, 64);
            this.btnDT_thang.TabIndex = 12;
            this.btnDT_thang.Text = "Tổng doanh thu bán được theo tháng";
            this.btnDT_thang.UseVisualStyleBackColor = true;
            // 
            // form_quanly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(681, 332);
            this.Controls.Add(this.btnDT_thang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnqlPhieunhap);
            this.Controls.Add(this.btnDThu_ngay);
            this.Controls.Add(this.tbnQLhoadon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "form_quanly";
            this.Text = "Chương Trình quản lý cửa hàng bán sách";
            this.TransparencyKey = System.Drawing.SystemColors.GradientActiveCaption;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button tbnQLhoadon;
        private System.Windows.Forms.Button btnDThu_ngay;
        private System.Windows.Forms.Button btnqlPhieunhap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sáchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kháchHàngThânThiếtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.Button btnDT_thang;
    }
}