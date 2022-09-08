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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        sqlBaglanti bgl = new sqlBaglanti();

        private void btnGiriş_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT *FROM TBL_ADMIN WHERE KULLANICIAD=@k1 AND SIFRE=@k2", bgl.baglanti());
            komut.Parameters.AddWithValue("@k1", TxtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@k2", TxtSifre.Text);
            SqlDataReader da = komut.ExecuteReader();
            if (da.Read())
            {
                Form1 frm = new Form1();
                frm.Show();
            }

        }
    }
}
