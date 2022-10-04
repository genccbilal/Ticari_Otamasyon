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
    public partial class frmFırmalar : Form
    {
        public frmFırmalar()
        {
            InitializeComponent();
        }

        sqlBaglanti bgl = new sqlBaglanti();

        void FirmaListele()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_FIRMALAR", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }

        void Temizle()
        {
            txtId.Text = "";
            txtAd.Text = "";
            txtSektor.Text = "";
            txtYetkili.Text = "";
            txtYGorev.Text = "";
            mskTc.Text = "";
            mskTelefon1.Text = "";
            mskTelefon2.Text = "";
            txtMail.Text = "";
            txtFax.Text = "";
            cmbIl.Text = "";
            cmbIlce.Text = "";
            txtVergiDairesi.Text = "";
            rchtAdres.Text = "";
            txtKod1.Text = "";
            txtKod2.Text = "";
            txtKod3.Text = "";

            this.ActiveControl = txtAd;
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

        void KodAciklama()
        {
            SqlCommand komut = new SqlCommand("Select FIRMAKOD1 from TBL_KODLAR", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                RchKod1.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();
        }

        private void frmFırmalar_Load(object sender, EventArgs e)
        {
            FirmaListele();
            Temizle();
            IlListesi();
            KodAciklama();

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtAd.Text !="" && txtSektor.Text != "" && txtYetkili.Text != "" && txtYGorev.Text != "" && mskTc.Text != "" && cmbIl.Text!="")
            {
                SqlCommand save = new SqlCommand("INSERT INTO TBL_FIRMALAR (AD,YETKILISTATU,YETKILIADSOYAD,YETKILITC,SEKTOR,TELEFON1,TELEFON2,MAIL,FAX,IL,ILCE,VERGIDAIRE,ADRES,OZELKOD1,OZELKOD2,OZELKOD3) VALUES (@s1,@s2,@s3,@s4,@s5,@s6,@s7,@s8,@s9,@s10,@s11,@s12,@s13,@s14,@s15,@s16)", bgl.baglanti());
                save.Parameters.AddWithValue("@s1", txtAd.Text);
                save.Parameters.AddWithValue("@s2", txtYGorev.Text);
                save.Parameters.AddWithValue("@s3", txtYetkili.Text);
                save.Parameters.AddWithValue("@s4", mskTc.Text);
                save.Parameters.AddWithValue("@s5", txtSektor.Text);
                save.Parameters.AddWithValue("@s6", mskTelefon1.Text);
                save.Parameters.AddWithValue("@s7", mskTelefon2.Text);
                save.Parameters.AddWithValue("@s8", txtMail.Text);
                save.Parameters.AddWithValue("@s9", txtFax.Text);
                save.Parameters.AddWithValue("@s10", cmbIl.Text);
                save.Parameters.AddWithValue("@s11", cmbIlce.Text);
                save.Parameters.AddWithValue("@s12", txtVergiDairesi.Text);
                save.Parameters.AddWithValue("@s13", rchtAdres.Text);
                save.Parameters.AddWithValue("@s14", txtKod1.Text);
                save.Parameters.AddWithValue("@s15", txtKod2.Text);
                save.Parameters.AddWithValue("@s16", txtKod3.Text);
                save.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Firma sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FirmaListele();
                Temizle();
            }
            else
            {
                MessageBox.Show("Firma Kaydedilemedi.\nBoş alanları doldurunuz!", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
     
        }

        private void cmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIlce.Properties.Items.Clear();
            cmbIlce.Text = "";
            SqlCommand komut2 = new SqlCommand("SELECT ILCE FROM TBL_ILCELER WHERE SEHIR=@p1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", cmbIl.SelectedIndex + 1);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbIlce.Properties.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtId.Text!="")
            {
                try
                {
                    DialogResult secim = MessageBox.Show("Silmek İstediğinize Emin misiniz ? ", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (secim == DialogResult.Yes)
                    {
                        SqlCommand Delete = new SqlCommand("DELETE FROM TBL_FIRMALAR WHERE ID=@d1", bgl.baglanti());
                        Delete.Parameters.AddWithValue("@d1", txtId.Text);
                        Delete.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        Temizle();
                    }
                    else
                    {
                        MessageBox.Show("Silme İşlemi İptal Edilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FirmaListele();
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
                FirmaListele();
            }
            else
            {
                MessageBox.Show("Lütfen Silmek Sitediğiniz Firmayı Seçiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtId.Text!="")
            {
                SqlCommand update = new SqlCommand("UPDATE TBL_FIRMALAR SET AD=@u1,YETKILISTATU=@u2,YETKILIADSOYAD=@u3,YETKILITC=@u4,SEKTOR=@u5,TELEFON1=@u6,TELEFON2=@u7,MAIL=@u8,FAX=@u9,IL=@u10,ILCE=@u11,VERGIDAIRE=@u12,ADRES=@u13,OZELKOD1=@u14,OZELKOD2=@u15,OZELKOD3=@u16 WHERE ID=@u17", bgl.baglanti());
                update.Parameters.AddWithValue("@u1", txtAd.Text); ;
                update.Parameters.AddWithValue("@u2", txtYGorev.Text);
                update.Parameters.AddWithValue("@u3", txtYetkili.Text);
                update.Parameters.AddWithValue("@u4", mskTc.Text);
                update.Parameters.AddWithValue("@u5", txtSektor.Text);
                update.Parameters.AddWithValue("@u6", mskTelefon1.Text);
                update.Parameters.AddWithValue("@u7", mskTelefon2.Text);
                update.Parameters.AddWithValue("@u8", txtMail.Text);
                update.Parameters.AddWithValue("@u9", txtFax.Text);
                update.Parameters.AddWithValue("@u10", cmbIl.Text);
                update.Parameters.AddWithValue("@u11", cmbIlce.Text);
                update.Parameters.AddWithValue("@u12", txtVergiDairesi.Text);
                update.Parameters.AddWithValue("@u13", rchtAdres.Text);
                update.Parameters.AddWithValue("@u14", txtKod1.Text);
                update.Parameters.AddWithValue("@u15", txtKod2.Text);
                update.Parameters.AddWithValue("@u16", txtKod3.Text);
                update.Parameters.AddWithValue("@u17", txtId.Text);
                update.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Firma Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FirmaListele();
                Temizle();
            }
            else
            {
                MessageBox.Show("Lütfen Bir Firma Seçiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void GridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtId.Text = dr["ID"].ToString();
            txtAd.Text = dr["AD"].ToString();
            txtYGorev.Text = dr["YETKILISTATU"].ToString();
            txtYetkili.Text = dr["YETKILIADSOYAD"].ToString();
            mskTc.Text = dr["YETKILITC"].ToString();
            txtSektor.Text = dr["SEKTOR"].ToString();
            mskTelefon1.Text = dr["TELEFON1"].ToString();
            mskTelefon2.Text = dr["TELEFON2"].ToString();
            txtMail.Text = dr["MAIL"].ToString();
            txtFax.Text = dr["FAX"].ToString();
            cmbIl.Text = dr["IL"].ToString();
            cmbIlce.Text = dr["ILCE"].ToString();
            txtVergiDairesi.Text = dr["VERGIDAIRE"].ToString();
            rchtAdres.Text = dr["ADRES"].ToString();
            txtKod1.Text = dr["OZELKOD1"].ToString();
            txtKod2.Text = dr["OZELKOD2"].ToString();
            txtKod3.Text = dr["OZELKOD3"].ToString();
        }
    }
}
