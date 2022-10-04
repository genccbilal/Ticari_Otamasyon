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
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }

        sqlBaglanti bgl = new sqlBaglanti();

        void FaturaListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_FATURABILGI", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void Temizle()
        {
            txtId.Text = "";
            txtSeri.Text = "";
            txtSeriNo.Text = "";
            mskTarih.Text = "";
            mskSaat.Text = "";
            txtVergiDaire.Text = "";
            txtAlici.Text = "";

            txtUrunAd.Text = "";
            txtMiktar.Text = "";
            txtFiyat.Text = "";
            txtMarka.Text = "";
            txtTutar.Text = "";
            txtFaturaID.Text = "";
            cmbPersonel.Text = "";
            cmbPersonel2.Text = "";
            comboBox1.SelectedItem = null;
            lookUpEdit1.EditValue = null;
            lookUpEdit2.EditValue = null;
        }

        void PersonelListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT ID,(AD+' '+SOYAD) AS 'İSİM' FROM TBL_PERSONELLER", bgl.baglanti());
            da.Fill(dt);
            cmbPersonel.ValueMember = "ID";
            cmbPersonel.DisplayMember = "İSİM";
            cmbPersonel.DataSource = dt;

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT ID,(AD+' '+SOYAD) AS 'İSİM' FROM TBL_PERSONELLER", bgl.baglanti());
            da1.Fill(dt1);

            cmbPersonel2.ValueMember = "ID";
            cmbPersonel2.DisplayMember = "İSİM";
            cmbPersonel2.DataSource = dt1;

            bgl.baglanti().Close();
        }

        void FaturaDetay()
        {
            double miktar, fiyat, tutar;
            fiyat = Convert.ToDouble(txtFiyat.Text);
            miktar = Convert.ToDouble(txtMiktar.Text);
            tutar = fiyat * miktar;
            txtTutar.Text = tutar.ToString();
            SqlCommand save = new SqlCommand("INSERT INTO TBL_FATURADETAY (URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID,MARKA) VALUES (@s1,@s2,@s3,@s4,@s5,@s6)", bgl.baglanti());
            save.Parameters.AddWithValue("@s1", txtUrunAd.Text);
            save.Parameters.AddWithValue("@s2", txtMiktar.Text);
            save.Parameters.AddWithValue("@s3", decimal.Parse(txtFiyat.Text));
            save.Parameters.AddWithValue("@s4", decimal.Parse(txtTutar.Text));
            save.Parameters.AddWithValue("@s5", txtFaturaID.Text);
            save.Parameters.AddWithValue("@s6", txtMarka.Text);
            save.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        void UrunListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT ID,URUNAD,MARKA FROM TBL_URUNLER WHERE ADET>0 ", bgl.baglanti());
            da.Fill(dt);
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "ID";
            lookUpEdit1.Properties.DataSource = dt;
        }

        void FirmaListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT ID,AD FROM TBL_FIRMALAR", bgl.baglanti());
            da.Fill(dt);

            lookUpEdit2.Properties.ValueMember = "ID";
            lookUpEdit2.Properties.DisplayMember = "AD";
            lookUpEdit2.Properties.DataSource = dt;
        }

        void MusteriListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT ID,(AD+' '+SOYAD) AS 'AD' FROM TBL_MUSTERILER", bgl.baglanti());
            da.Fill(dt);
            lookUpEdit2.Properties.ValueMember = "ID";
            lookUpEdit2.Properties.DisplayMember = "AD";
            lookUpEdit2.Properties.DataSource = dt;
        }

        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            FaturaListesi();
            UrunListesi();
            PersonelListesi();
            Temizle();
        }

        private void btnBul_Click(object sender, EventArgs e)
        {

                SqlCommand komut = new SqlCommand("SELECT URUNAD,MARKA,SATISFIYAT FROM TBL_URUNLER WHERE ID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", lookUpEdit1.EditValue);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    txtUrunAd.Text = dr[0].ToString();
                    txtMarka.Text = dr[1].ToString();
                    txtFiyat.Text = dr[2].ToString();
                }
                bgl.baglanti().Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

            if (txtFaturaID.Text == "")
            {
                if (txtSeri.Text != "" && txtSeriNo.Text != "" && txtAlici.Text != "" && cmbPersonel.Text != "")
                {

                    SqlCommand save = new SqlCommand("INSERT INTO TBL_FATURABILGI (SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN) VALUES (@k1,@k2,@k3,@k4,@k5,@k6,@k7)", bgl.baglanti());
                    save.Parameters.AddWithValue("@k1", txtSeri.Text);
                    save.Parameters.AddWithValue("@k2", txtSeriNo.Text);
                    save.Parameters.AddWithValue("@k3", mskTarih.Text);
                    save.Parameters.AddWithValue("@k4", mskSaat.Text);
                    save.Parameters.AddWithValue("@k5", txtVergiDaire.Text);
                    save.Parameters.AddWithValue("@k6", txtAlici.Text);
                    save.Parameters.AddWithValue("@k7", cmbPersonel.Text);
                    save.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Fatura Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FaturaListesi();
                    Temizle();
                }
                else
                {
                    MessageBox.Show("Fatura Kaydedilemedi.\nBoş alanları doldurunuz!", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //Firma Çari
            if (txtFaturaID.Text != "" && comboBox1.Text == "Firma")
            {
                FaturaDetay();

                //Satış işlemin frimaHareketler tablosuna ekleme
                SqlCommand save2 = new SqlCommand("INSERT INTO TBL_FIRMAHAREKETLER (URUNID,ADET,PERSONEL,FIRMA,FIYAT,TOPLAM,FATURAID,MARKA) VALUES (@k1,@k2,@k3,@k4,@k5,@k6,@k7,@k8)", bgl.baglanti());
                save2.Parameters.AddWithValue("@k1", lookUpEdit1.EditValue);
                save2.Parameters.AddWithValue("@k2", txtMiktar.Text);
                save2.Parameters.AddWithValue("@k3", cmbPersonel2.SelectedValue);
                save2.Parameters.AddWithValue("@k4", lookUpEdit2.EditValue);
                save2.Parameters.AddWithValue("@k5", decimal.Parse(txtFiyat.Text));
                save2.Parameters.AddWithValue("@k6", decimal.Parse(txtTutar.Text));
                save2.Parameters.AddWithValue("@k7", txtFaturaID.Text);
                save2.Parameters.AddWithValue("@k8", lookUpEdit1.EditValue);
                save2.ExecuteNonQuery();
                bgl.baglanti().Close();

                //Stok Azaltma
                SqlCommand update = new SqlCommand("UPDATE TBL_URUNLER SET ADET=ADET-@p1 WHERE ID=@p2", bgl.baglanti());
                update.Parameters.AddWithValue("@p1", txtMiktar.Text);
                update.Parameters.AddWithValue("@p2", lookUpEdit1.EditValue);
                update.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura Ayit Ürün Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FaturaListesi();
                Temizle();
            }

            //Müşteri cari
            if (txtFaturaID.Text != "" && comboBox1.Text == "Müşteri")
            {
                FaturaDetay();

                //Satış işlemin MusteriHareketler tablosuna ekleme
                SqlCommand save2 = new SqlCommand("INSERT INTO TBL_MUSTERIHAREKETLER (URUNID,ADET,PERSONEL,MUSTERI,FIYAT,TOPLAM,FATURAID,MARKA) VALUES (@k1,@k2,@k3,@k4,@k5,@k6,@k7,@k8)", bgl.baglanti());
                save2.Parameters.AddWithValue("@k1", lookUpEdit1.EditValue);
                save2.Parameters.AddWithValue("@k2", txtMiktar.Text);
                save2.Parameters.AddWithValue("@k3", cmbPersonel2.SelectedValue);
                save2.Parameters.AddWithValue("@k4", lookUpEdit2.EditValue);
                save2.Parameters.AddWithValue("@k5", decimal.Parse(txtFiyat.Text));
                save2.Parameters.AddWithValue("@k6", decimal.Parse(txtTutar.Text));
                save2.Parameters.AddWithValue("@k7", txtFaturaID.Text);
                save2.Parameters.AddWithValue("@k8", lookUpEdit1.EditValue);
                save2.ExecuteNonQuery();
                bgl.baglanti().Close();

                //Stok Azaltma
                SqlCommand update = new SqlCommand("UPDATE TBL_URUNLER SET ADET=ADET-@p1 WHERE ID=@p2", bgl.baglanti());
                update.Parameters.AddWithValue("@p1", txtMiktar.Text);
                update.Parameters.AddWithValue("@p2", lookUpEdit1.EditValue);
                update.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura Ayit Ürün Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FaturaListesi();
                Temizle();
            }

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
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
                        SqlCommand Delete = new SqlCommand("DELETE FROM TBL_FATURABILGI WHERE FATURABILGIID=@d1", bgl.baglanti());
                        Delete.Parameters.AddWithValue("@d1", txtId.Text);
                        Delete.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        MessageBox.Show("Fatura Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FaturaListesi();
                        Temizle();
                    }
                    else
                    {
                        MessageBox.Show("Silme İşlemi İptal Edilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FaturaListesi();
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
                FaturaListesi();
            }
            else
            {
                MessageBox.Show("Lütfen Silmek Sitediğiniz Faturayı Seçiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtId.Text!="")
            {
                SqlCommand Update = new SqlCommand("UPDATE TBL_FATURABILGI SET SERI=@u1,SIRANO=@u2,TARIH=@u3,SAAT=@u4,VERGIDAIRE=@u5,ALICI=@u6,TESLIMEDEN=@u7 WHERE FATURABILGIID=@u9", bgl.baglanti());
                Update.Parameters.AddWithValue("@u1", txtSeri.Text);
                Update.Parameters.AddWithValue("@u2", txtSeriNo.Text);
                Update.Parameters.AddWithValue("@u3", mskTarih.Text);
                Update.Parameters.AddWithValue("@u4", mskSaat.Text);
                Update.Parameters.AddWithValue("@u5", txtVergiDaire.Text);
                Update.Parameters.AddWithValue("@u6", txtAlici.Text);
                Update.Parameters.AddWithValue("@u7", cmbPersonel.Text);
                Update.Parameters.AddWithValue("@u9", txtId.Text);
                Update.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FaturaListesi();
                Temizle();
            }
            else
            {
                MessageBox.Show("Lütfen Bir Fatura Seçiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }          

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Müşteri")
            {
                lookUpEdit2.EditValue = null;
                MusteriListesi();              
            }
            if (comboBox1.Text == "Firma")
            {
                lookUpEdit2.EditValue = null;
                FirmaListesi();             
            }
        }

        private void GridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtId.Text = dr["FATURABILGIID"].ToString();
            txtSeri.Text = dr["SERI"].ToString();
            txtSeriNo.Text = dr["SIRANO"].ToString();
            mskTarih.Text = dr["TARIH"].ToString();
            mskSaat.Text = dr["SAAT"].ToString();
            txtVergiDaire.Text = dr["VERGIDAIRE"].ToString();
            txtAlici.Text = dr["ALICI"].ToString();
            cmbPersonel.Text = dr["TESLIMEDEN"].ToString();
        }

        private void GridView1_DoubleClick_1(object sender, EventArgs e)
        {
            frmFaturaUrunler frm = new frmFaturaUrunler();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                frm.ID = dr["FATURABILGIID"].ToString();
            }
            frm.Show();
        }
    }
}
