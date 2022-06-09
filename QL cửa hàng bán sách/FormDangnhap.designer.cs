
namespace QL_cửa_hàng_bán_sách
{
    partial class fdangnhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fdangnhap));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txttaikhoan = new System.Windows.Forms.TextBox();
            this.txtmk = new System.Windows.Forms.TextBox();
            this.btDangnhap = new System.Windows.Forms.Button();
            this.btthoat = new System.Windows.Forms.Button();
            this.ckbHienmk = new System.Windows.Forms.CheckBox();
            this.title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tài khoản :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(66, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu :";
            // 
            // txttaikhoan
            // 
            this.txttaikhoan.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txttaikhoan.Location = new System.Drawing.Point(200, 68);
            this.txttaikhoan.Name = "txttaikhoan";
            this.txttaikhoan.Size = new System.Drawing.Size(247, 22);
            this.txttaikhoan.TabIndex = 1;
            // 
            // txtmk
            // 
            this.txtmk.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtmk.Location = new System.Drawing.Point(200, 129);
            this.txtmk.Name = "txtmk";
            this.txtmk.PasswordChar = '*';
            this.txtmk.Size = new System.Drawing.Size(247, 22);
            this.txtmk.TabIndex = 1;
            // 
            // btDangnhap
            // 
            this.btDangnhap.Location = new System.Drawing.Point(151, 228);
            this.btDangnhap.Name = "btDangnhap";
            this.btDangnhap.Size = new System.Drawing.Size(112, 40);
            this.btDangnhap.TabIndex = 2;
            this.btDangnhap.Text = "Đăng Nhập";
            this.btDangnhap.UseVisualStyleBackColor = true;
            this.btDangnhap.Click += new System.EventHandler(this.btDangnhap_Click);
            // 
            // btthoat
            // 
            this.btthoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btthoat.Location = new System.Drawing.Point(335, 228);
            this.btthoat.Name = "btthoat";
            this.btthoat.Size = new System.Drawing.Size(112, 40);
            this.btthoat.TabIndex = 2;
            this.btthoat.Text = "Thoát";
            this.btthoat.UseVisualStyleBackColor = true;
            this.btthoat.Click += new System.EventHandler(this.btthoat_Click);
            // 
            // ckbHienmk
            // 
            this.ckbHienmk.AutoSize = true;
            this.ckbHienmk.Location = new System.Drawing.Point(200, 183);
            this.ckbHienmk.Name = "ckbHienmk";
            this.ckbHienmk.Size = new System.Drawing.Size(140, 21);
            this.ckbHienmk.TabIndex = 1;
            this.ckbHienmk.Text = "Hiển thị mật khẩu";
            this.ckbHienmk.UseVisualStyleBackColor = true;
            this.ckbHienmk.CheckedChanged += new System.EventHandler(this.ckbHienmk_CheckedChanged);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(67, 20);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(398, 20);
            this.title.TabIndex = 7;
            this.title.Text = "PHẦN MỀM QUẢN LÝ CỬA HÀNG BÁN SÁCH";
            // 
            // fdangnhap
            // 
            this.AcceptButton = this.btDangnhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btthoat;
            this.ClientSize = new System.Drawing.Size(535, 311);
            this.Controls.Add(this.title);
            this.Controls.Add(this.ckbHienmk);
            this.Controls.Add(this.btthoat);
            this.Controls.Add(this.btDangnhap);
            this.Controls.Add(this.txtmk);
            this.Controls.Add(this.txttaikhoan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "fdangnhap";
            this.Text = "đăng nhập";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txttaikhoan;
        private System.Windows.Forms.TextBox txtmk;
        private System.Windows.Forms.Button btDangnhap;
        private System.Windows.Forms.Button btthoat;
        private System.Windows.Forms.CheckBox ckbHienmk;
        private System.Windows.Forms.Label title;
    }
}

