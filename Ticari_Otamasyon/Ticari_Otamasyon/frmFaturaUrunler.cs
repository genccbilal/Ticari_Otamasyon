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

namespace Ticari_Otamasyon
{
    public partial class frmFaturaUrunler : Form
    {
        public frmFaturaUrunler()
        {
            InitializeComponent();
        }

        sqlBaglanti bgl = new sqlBaglanti();

        public string ID;

        public void Listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_FATURADETAY WHERE FATURAID='" + ID + "'", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void frmFaturaUrunler_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void frmFaturaUrunler_Activated(object sender, EventArgs e)
        {
            Listele();
        }

        private void GridView1_DoubleClick_1(object sender, EventArgs e)
        {
            frmFaturaUrunDuzenleme frm = new frmFaturaUrunDuzenleme();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                frm.UrunID = dr["FATURAURUNID"].ToString();
            }
            frm.Show();
        }
    }
}
