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
    public partial class frmMusteriler : Form
    {
        public frmMusteriler()
        {
            InitializeComponent();
        }

        sqlBaglanti bgl = new sqlBaglanti();

        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_MUSTERILER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void SehirListesi()
        {
            SqlCommand komut = new SqlCommand("SELECT SEHIR FROM TBL_ILLER ", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbIl.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        void Temizle()
        {
            txtId.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            mskTelefon1.Text = "";
            mskTelefon2.Text = "";
            mskTc.Text = "";
            txtMail.Text = "";
            cmbIl.Text = "";
            cmbIlce.Text = "";
            rchtAdres.Text = "";
            txtVergiDairesi.Text = "";
        }

        private void frmMusteriler_Load(object sender, EventArgs e)
        {
            Listele();
            SehirListesi();
            Temizle();
        }

        private void cmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIlce.Properties.Items.Clear();
            cmbIlce.Text = "";
            SqlCommand komut2 = new SqlCommand("SELECT ILCE FROM TBL_ILCELER WHERE SEHIR=@s1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@s1", cmbIl.SelectedIndex + 1);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbIlce.Properties.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand kayit = new SqlCommand("INSERT INTO TBL_MUSTERILER (AD,SOYAD,TELEFON,TELEFON2,TC,MAIL,IL,ILCE,ADRES,VERGIDAIRE) VALUES (@k1,@k2,@k3,@k4,@k5,@k6,@k7,@k8,@k9,@k10)", bgl.baglanti());
            kayit.Parameters.AddWithValue("@k1", txtAd.Text);
            kayit.Parameters.AddWithValue("@k2", txtSoyad.Text);
            kayit.Parameters.AddWithValue("@k3", mskTelefon1.Text);
            kayit.Parameters.AddWithValue("@k4", mskTelefon2.Text);
            kayit.Parameters.AddWithValue("@k5", mskTc.Text);
            kayit.Parameters.AddWithValue("@k6", txtMail.Text);
            kayit.Parameters.AddWithValue("@k7", cmbIl.Text);
            kayit.Parameters.AddWithValue("@k8", cmbIlce.Text);
            kayit.Parameters.AddWithValue("@k9", rchtAdres.Text);
            kayit.Parameters.AddWithValue("@k10", txtVergiDairesi.Text);
            kayit.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müsteri sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtId.Text = dr["ID"].ToString();
            txtAd.Text = dr["AD"].ToString();
            txtSoyad.Text = dr["SOYAD"].ToString();
            mskTelefon1.Text = dr["TELEFON"].ToString();
            mskTelefon2.Text = dr["TELEFON2"].ToString();
            mskTc.Text = dr["TC"].ToString();
            txtMail.Text = dr["MAIL"].ToString();
            cmbIl.Text = dr["IL"].ToString();
            cmbIlce.Text = dr["ILCE"].ToString();
            rchtAdres.Text = dr["ADRES"].ToString();
            txtVergiDairesi.Text = dr["VERGIDAIRE"].ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try // Çalışan Kod Satırı Buraya Yazın
            {
                DialogResult seçim = MessageBox.Show("Silmek İstediğinize Emin misiniz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (seçim == DialogResult.Yes)
                {
                    SqlCommand sil = new SqlCommand("DELETE FROM TBL_MUSTERILER WHERE ID=@s1", bgl.baglanti());
                    sil.Parameters.AddWithValue("@s1", txtId.Text);
                    sil.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Ürün silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Silme İşlemi İptal Edilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Listele();
                    Temizle();
                }
            }
            catch //Hata Alınırsa Gelicek Olan Cevap
            {
                MessageBox.Show("Bir Hata Meydana Geldi.Lütfen Silmek İstediğiniz Stüna İki Kere Tıklayarak Tekrar Deneyiniz.!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally // Gelen Hatadan Sonra Yapmak İstediğiniz İşlem
            {
                Temizle();
            }
            Listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand update = new SqlCommand("UPDATE TBL_MUSTERILER SET AD=@u1,SOYAD=@u2,TELEFON=@u3,TELEFON2=@u4,TC=@u5,MAIL=@u6,IL=@u7,ILCE=@u8,ADRES=@u9,VERGIDAIRE=@u10 WHERE ID=@u11", bgl.baglanti());
            update.Parameters.AddWithValue("@u1", txtAd.Text); ;
            update.Parameters.AddWithValue("@u2", txtSoyad.Text);
            update.Parameters.AddWithValue("@u3", mskTelefon1.Text);
            update.Parameters.AddWithValue("@u4", mskTelefon2.Text);
            update.Parameters.AddWithValue("@u5", mskTc.Text);
            update.Parameters.AddWithValue("@u6", txtMail.Text);
            update.Parameters.AddWithValue("@u7", cmbIl.Text);
            update.Parameters.AddWithValue("@u8", cmbIlce.Text);
            update.Parameters.AddWithValue("@u9", rchtAdres.Text);
            update.Parameters.AddWithValue("@u10", txtVergiDairesi.Text);
            update.Parameters.AddWithValue("@u11", txtId.Text); 
            update.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
            Temizle();
        }
    }
}
