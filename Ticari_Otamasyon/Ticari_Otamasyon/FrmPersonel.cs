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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }

        sqlBaglanti bgl = new sqlBaglanti();

        void personelListesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_PERSONELLER", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void Temizle()
        {
            txtId.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            mskTelefon1.Text = "";
            mskTc.Text = "";
            txtMail.Text = "";
            cmbIl.Text = "";
            cmbIlce.Text = "";
            rchtAdres.Text = "";
            txtGörev.Text = "";
        }

        void IlListesi()
        {
            SqlCommand komut = new SqlCommand("SELECT SEHIR FROM TBL_ILLER ", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbIl.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            personelListesi();
            Temizle();
            IlListesi();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();        
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtAd.Text !="" && txtSoyad.Text != "" && mskTc.Text != "")
            {
                SqlCommand save = new SqlCommand("INSERT INTO TBL_PERSONELLER (AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,ADRES,GOREV) VALUES (@k1,@k2,@k3,@k4,@k5,@k6,@k7,@k8,@k9)", bgl.baglanti());
                save.Parameters.AddWithValue("@k1", txtAd.Text);
                save.Parameters.AddWithValue("@k2", txtSoyad.Text);
                save.Parameters.AddWithValue("@k3", mskTelefon1.Text);
                save.Parameters.AddWithValue("@k4", mskTc.Text);
                save.Parameters.AddWithValue("@k5", txtMail.Text);
                save.Parameters.AddWithValue("@k6", cmbIl.Text);
                save.Parameters.AddWithValue("@k7", cmbIlce.Text);
                save.Parameters.AddWithValue("@k8", rchtAdres.Text);
                save.Parameters.AddWithValue("@k9", txtGörev.Text);
                save.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Personel sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                personelListesi();
                Temizle();
            }
            else
            {
                MessageBox.Show("Müşteri Kaydedilemedi.\nBoş alanları doldurunuz!", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtId.Text!="")
            {
                try
                {
                    DialogResult secim = MessageBox.Show("Silmek İstediğinize Eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (secim == DialogResult.Yes)
                    {
                        SqlCommand delete = new SqlCommand("DELETE FROM TBL_PERSONELLER WHERE ID=@s1", bgl.baglanti());
                        delete.Parameters.AddWithValue("@s1", txtId.Text);
                        delete.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        MessageBox.Show("Personel silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Silme İşlemi İptal Edilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        personelListesi();
                        Temizle();
                    }
                }
                catch
                {
                    MessageBox.Show("Bir Hata Meydana Geldi.Lütfen Silmek İstediğiniz Stüna İki Kere Tıklayarak Tekrar Deneyiniz.!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Temizle();
                }
                personelListesi();
            }
            else
            {
                MessageBox.Show("Lütfen Silmek Sitediğiniz Personeli Seçiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtId.Text!="")
            {
                SqlCommand update = new SqlCommand("UPDATE TBL_PERSONELLER SET  AD=@u1,SOYAD=@u2,TELEFON=@u3,TC=@u4,MAIL=@u5,IL=@u6,ILCE=@u7,ADRES=@u8,GOREV=@u9 WHERE ID=@u10", bgl.baglanti());
                update.Parameters.AddWithValue("@u1", txtAd.Text);
                update.Parameters.AddWithValue("@u2", txtSoyad.Text);
                update.Parameters.AddWithValue("@u3", mskTelefon1.Text);
                update.Parameters.AddWithValue("@u4", mskTc.Text);
                update.Parameters.AddWithValue("@u5", txtMail.Text);
                update.Parameters.AddWithValue("@u6", cmbIl.Text);
                update.Parameters.AddWithValue("@u7", cmbIlce.Text);
                update.Parameters.AddWithValue("@u8", rchtAdres.Text);
                update.Parameters.AddWithValue("@u9", txtGörev.Text);
                update.Parameters.AddWithValue("@u10", txtId.Text);
                update.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Personel Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                personelListesi();
                Temizle();
            }
            else
            {
                MessageBox.Show("Lütfen Bir Personel Seçiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
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

        private void GridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtId.Text = dr["ID"].ToString();
            txtAd.Text = dr["AD"].ToString();
            txtSoyad.Text = dr["SOYAD"].ToString();
            mskTelefon1.Text = dr["TELEFON"].ToString();
            mskTc.Text = dr["TC"].ToString();
            txtMail.Text = dr["MAIL"].ToString();
            cmbIl.Text = dr["IL"].ToString();
            cmbIlce.Text = dr["ILCE"].ToString();
            rchtAdres.Text = dr["ADRES"].ToString();
            txtGörev.Text = dr["GOREV"].ToString();
        }
    }
}
