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
    public partial class frmRehber : Form
    {
        public frmRehber()
        {
            InitializeComponent();
        }

        sqlBaglanti bgl = new sqlBaglanti();

        void MusteriListesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT AD,SOYAD,TELEFON,TELEFON2,MAIL FROM TBL_MUSTERILER", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
         
        void FirmaListesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT AD,YETKILIADSOYAD,YETKILISTATU,TELEFON1,TELEFON2,MAIL,FAX FROM TBL_FIRMALAR ", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }

        private void frmRehber_Load(object sender, EventArgs e)
        {
            MusteriListesi();
            FirmaListesi();
        }

        private void GridView1_DoubleClick_1(object sender, EventArgs e)
        {
            FrmMail frm = new FrmMail();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                frm.Mail = dr["MAIL"].ToString();
            }
            frm.Show();
        }

        private void GridView2_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frm = new FrmMail();
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);

            if (dr != null)
            {
                frm.Mail = dr["MAIL"].ToString();
            }
            frm.Show();
        }
    }
}
