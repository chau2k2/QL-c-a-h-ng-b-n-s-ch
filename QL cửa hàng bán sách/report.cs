using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.Configuration;

namespace QL_cửa_hàng_bán_sách
{
    public partial class report : Form
    {
        public report()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            string contr = ConfigurationManager.ConnectionStrings["QLBanSach"].ConnectionString;

            using (SqlConnection con = new SqlConnection(contr))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_sachbdlonhon5";



                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {

                        adapter.SelectCommand = cmd;
                        DataTable tb = new System.Data.DataTable();
                        adapter.Fill(tb);

                        CrystalReport3 rpt = new CrystalReport3();
                        rpt.SetDataSource(tb);
                        crystalReportViewer1.ReportSource = rpt;


                        crystalReportViewer1.Refresh();

                    }

                }
            }
        }
    }
}
