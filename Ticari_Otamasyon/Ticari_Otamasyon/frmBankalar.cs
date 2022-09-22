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
    public partial class frmBankalar : Form
    {
        public frmBankalar()
        {
            InitializeComponent();
        }

        sqlBaglanti bgl = new sqlBaglanti();

        void BankaListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("EXECUTE BankaBilgi", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void Temizle()
        {
            txtId.Text = "";
            txtBankaAd.Text = "";
            cmbIl.Text = "";
            cmbIlce.Text = "";
            txtSube.Text = "";
            mskIban.Text = "";
            txtHesapNo.Text = "";
            txtYetkili.Text = "";
            mskTelefon.Text = "";
            mskTarih.Text = "";
            txtHesapNo.Text = "";
            lookUpEdit1.EditValue = null;
            txtHesapTuru.Text = "";
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

        void FirmaListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT ID,AD FROM TBL_FIRMALAR", bgl.baglanti());
            da.Fill(dt);
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "AD";
            lookUpEdit1.Properties.DataSource = dt;
        }

        private void frmBankalar_Load(object sender, EventArgs e)
        {
            BankaListesi();
            Temizle();
            SehirListesi();
            FirmaListesi();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand save = new SqlCommand("INSERT INTO TBL_BANKALAR (BANKAADI,IL,ILCE,SUBE,IBAN,HESAPNO,YETKILI,TELEFON,TARIH,HESAPTURU,FIRMAID) VALUES (@k1,@k2,@k3,@k4,@k5,@k6,@k7,@k8,@k9,@k10,@k11)", bgl.baglanti());
            save.Parameters.AddWithValue("@k1", txtBankaAd.Text);
            save.Parameters.AddWithValue("@k2", cmbIl.Text);
            save.Parameters.AddWithValue("@k3", cmbIlce.Text);
            save.Parameters.AddWithValue("@k4", txtSube.Text);
            save.Parameters.AddWithValue("@k5", mskIban.Text);
            save.Parameters.AddWithValue("@k6", txtHesapNo.Text);
            save.Parameters.AddWithValue("@k7", txtYetkili.Text);
            save.Parameters.AddWithValue("@k8", mskTelefon.Text);
            save.Parameters.AddWithValue("@k9", mskTarih.Text);
            save.Parameters.AddWithValue("@k10", txtHesapTuru.Text);
            save.Parameters.AddWithValue("@k11", lookUpEdit1.EditValue);
            save.ExecuteNonQuery();
            bgl.baglanti().Close();
            BankaListesi();
            Temizle();
            MessageBox.Show("Banka Bilgisi Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Secim = MessageBox.Show("Silmek İstediğinize Eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (Secim == DialogResult.Yes)
                {
                    SqlCommand delete = new SqlCommand("DELETE FROM TBL_BANKALAR WHERE ID=@s1", bgl.baglanti());
                    delete.Parameters.AddWithValue("@s1", txtId.Text);
                    delete.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Banka silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Silme İşlemi İptal Edilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BankaListesi();
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
            BankaListesi();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtId.Text = dr["ID"].ToString();
            txtBankaAd.Text = dr["BANKAADI"].ToString();
            cmbIl.Text = dr["IL"].ToString();
            cmbIlce.Text = dr["ILCE"].ToString();
            txtSube.Text = dr["SUBE"].ToString();
            mskIban.Text = dr["IBAN"].ToString();
            txtHesapNo.Text = dr["HESAPNO"].ToString();
            txtYetkili.Text = dr["YETKILI"].ToString();
            mskTelefon.Text = dr["TELEFON"].ToString();
            mskTarih.Text = dr["TARIH"].ToString();
            txtHesapTuru.Text = dr["HESAPTURU"].ToString();
            lookUpEdit1.EditValue = lookUpEdit1.Properties.GetKeyValueByDisplayText(dr["FIRMA AD"].ToString());
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void cmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIlce.Properties.Items.Clear();
            cmbIlce.Text = "";
            SqlCommand komut1 = new SqlCommand("SELECT ILCE FROM TBL_ILCELER WHERE SEHIR=@s1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@s1", cmbIl.SelectedIndex + 1);
            SqlDataReader dr2 = komut1.ExecuteReader();
            while (dr2.Read())
            {
                cmbIlce.Properties.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand update = new SqlCommand("UPDATE TBL_BANKALAR SET BANKAADI=@u1,IL=@u2,ILCE=@u3,SUBE=@u4,IBAN=@u5,HESAPNO=@u6,YETKILI=@u7,TELEFON=@u8,TARIH=@u9,HESAPTURU=@u10,FIRMAID=@u11 WHERE ID=@u12", bgl.baglanti());
            update.Parameters.AddWithValue("@u1", txtBankaAd.Text); ;
            update.Parameters.AddWithValue("@u2", cmbIl.Text);
            update.Parameters.AddWithValue("@u3", cmbIlce.Text);
            update.Parameters.AddWithValue("@u4", txtSube.Text);
            update.Parameters.AddWithValue("@u5", mskIban.Text);
            update.Parameters.AddWithValue("@u6", txtHesapNo.Text);
            update.Parameters.AddWithValue("@u7", txtYetkili.Text);
            update.Parameters.AddWithValue("@u8", mskTelefon.Text);
            update.Parameters.AddWithValue("@u9", mskTarih.Text);
            update.Parameters.AddWithValue("@u10", txtHesapTuru.Text);
            update.Parameters.AddWithValue("@u11", lookUpEdit1.EditValue);
            update.Parameters.AddWithValue("@u12", txtId.Text);
            update.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            BankaListesi();
            Temizle();
        }
    }
}
