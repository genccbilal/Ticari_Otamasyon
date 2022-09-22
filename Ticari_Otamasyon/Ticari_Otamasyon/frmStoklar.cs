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
using DevExpress.Charts;


namespace Ticari_Otamasyon
{
    public partial class frmStoklar : Form
    {
        public frmStoklar()
        {
            InitializeComponent();
        }

        sqlBaglanti bgl = new sqlBaglanti();

        private void frmStoklar_Load(object sender, EventArgs e)
        {

            SqlDataAdapter da = new SqlDataAdapter("SELECT URUNAD,SUM(ADET) AS'MİKTAR' FROM TBL_URUNLER GROUP BY URUNAD ORDER BY MİKTAR ASC", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

            //Charta Stok Miktarı Listeleme

            SqlCommand komut = new SqlCommand("SELECT URUNAD,SUM(ADET) FROM TBL_URUNLER GROUP BY URUNAD", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {                
                chartControl1.Series["Series 1"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString())));
            }
            bgl.baglanti().Close();

            chartControl2.Series["Series 1"].LegendTextPattern = "{A}";
            SqlCommand komut2 = new SqlCommand("SELECT IL,COUNT(*) FROM TBL_FIRMALAR GROUP BY IL", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chartControl2.Series["Series 1"].Points.Add(new DevExpress.XtraCharts.SeriesPoint( Convert.ToString(dr2[0]), int.Parse(dr2[1].ToString())));
            }
            bgl.baglanti().Close();

            chartControl2.Series["Series 1"].LegendTextPattern = "{A}";
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            frmStokDetay frm = new frmStokDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                frm.ad = dr["URUNAD"].ToString();
                frm.Show();
            }
            
        }
    }
}
