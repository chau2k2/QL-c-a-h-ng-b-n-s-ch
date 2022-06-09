
namespace QL_cửa_hàng_bán_sách
{
    partial class InHoaDon
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtInHDma = new System.Windows.Forms.TextBox();
            this.crystalReportViewerhd = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btninHD = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập mã hóa đơn cần in:";
            // 
            // txtInHDma
            // 
            this.txtInHDma.Location = new System.Drawing.Point(201, 6);
            this.txtInHDma.Name = "txtInHDma";
            this.txtInHDma.Size = new System.Drawing.Size(138, 22);
            this.txtInHDma.TabIndex = 1;
            // 
            // crystalReportViewerhd
            // 
            this.crystalReportViewerhd.ActiveViewIndex = -1;
            this.crystalReportViewerhd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerhd.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewerhd.Location = new System.Drawing.Point(2, 34);
            this.crystalReportViewerhd.Name = "crystalReportViewerhd";
            this.crystalReportViewerhd.Size = new System.Drawing.Size(1495, 570);
            this.crystalReportViewerhd.TabIndex = 2;
            // 
            // btninHD
            // 
            this.btninHD.Location = new System.Drawing.Point(373, 5);
            this.btninHD.Name = "btninHD";
            this.btninHD.Size = new System.Drawing.Size(75, 23);
            this.btninHD.TabIndex = 3;
            this.btninHD.Text = "In";
            this.btninHD.UseVisualStyleBackColor = true;
            this.btninHD.Click += new System.EventHandler(this.btninHD_Click);
            // 
            // InHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1498, 605);
            this.Controls.Add(this.btninHD);
            this.Controls.Add(this.crystalReportViewerhd);
            this.Controls.Add(this.txtInHDma);
            this.Controls.Add(this.label1);
            this.Name = "InHoaDon";
            this.Text = "InHoaDon";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInHDma;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerhd;
        private System.Windows.Forms.Button btninHD;
    }
}