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
    public partial class frmFaturaUrunDuzenleme : Form
    {
        public frmFaturaUrunDuzenleme()
        {
            InitializeComponent();
        }

        sqlBaglanti bgl = new sqlBaglanti();

        public string UrunID;


        void Listele()
        {
            SqlCommand komut = new SqlCommand("SELECT * FROM TBL_FATURADETAY WHERE FATURAURUNID='" + UrunID + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtFiyat.Text = dr[3].ToString();
                txtMiktar.Text = dr[2].ToString();
                txtTutar.Text = dr[4].ToString();
                txtUrunAd.Text = dr[1].ToString();
            }
            bgl.baglanti().Close();
        }

        private void frmFaturaUrunDuzenleme_Load(object sender, EventArgs e)
        {
            txtUrunID.Text = UrunID.ToString();
            Listele();
        }
        
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            double miktar, fiyat, tutar;
            fiyat = Convert.ToDouble(txtFiyat.Text);
            miktar = Convert.ToDouble(txtMiktar.Text);
            tutar = fiyat * miktar;
            txtTutar.Text = tutar.ToString();

            SqlCommand Update = new SqlCommand("UPDATE TBL_FATURADETAY SET URUNAD=@u1,MIKTAR=@u2,FIYAT=@u3,TUTAR=@u4 WHERE FATURAURUNID=@u5", bgl.baglanti());
            Update.Parameters.AddWithValue("@u1", txtUrunAd.Text);
            Update.Parameters.AddWithValue("@u2", txtMiktar.Text);
            Update.Parameters.AddWithValue("@u3", decimal.Parse(txtFiyat.Text));
            Update.Parameters.AddWithValue("@u4", decimal.Parse(txtTutar.Text));
            Update.Parameters.AddWithValue("@u5", txtUrunID.Text);
            Update.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Değişiklik Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand Delete = new SqlCommand("DELETE FROM TBL_FATURADETAY WHERE FATURAURUNID=@d1",bgl.baglanti());
            Delete.Parameters.AddWithValue("@d1", txtUrunID.Text);
            Delete.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}
