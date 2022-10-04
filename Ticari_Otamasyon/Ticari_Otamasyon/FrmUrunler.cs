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
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }
        sqlBaglanti bgl = new sqlBaglanti();

        void Listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_URUNLER", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void Temizle()
        {
            txtId.Text = "";
            txtAd.Text = "";
            txtMarka.Text = "";
            txtModel.Text = "";
            mskYil.Text = "";
            nudAdet.Value = 0;
            txtAlisFiyat.Text = "";
            txtSatisFiyat.Text = "";
            rchtDetay.Text = "";
        }

        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            Listele();
            Temizle();

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtAd.Text!=""  && txtAlisFiyat.Text !="" && txtSatisFiyat.Text!="")
            {
                //Verileri kaydetme
                SqlCommand save = new SqlCommand("INSERT INTO TBL_URUNLER (URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY) VALUES (@k1,@k2,@k3,@k4,@k5,@k6,@k7,@k8)", bgl.baglanti());
                save.Parameters.AddWithValue("@k1", txtAd.Text); ;
                save.Parameters.AddWithValue("@k2", txtMarka.Text);
                save.Parameters.AddWithValue("@k3", txtModel.Text);
                save.Parameters.AddWithValue("@k4", mskYil.Text);
                save.Parameters.AddWithValue("@k5", int.Parse((nudAdet.Value).ToString()));
                save.Parameters.AddWithValue("@k6", decimal.Parse(txtAlisFiyat.Text));
                save.Parameters.AddWithValue("@k7", decimal.Parse(txtSatisFiyat.Text));
                save.Parameters.AddWithValue("@k8", rchtDetay.Text);
                save.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Ürün sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                Temizle();
            }
            else
            {
                MessageBox.Show("Ürünn Kaydedilemedi.\nBoş alanları doldurunuz!", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtId.Text!="")
            {
                try
                {
                    DialogResult secim = MessageBox.Show("Silmek İstediğinize Emin misiniz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (secim == DialogResult.Yes)
                    {
                        SqlCommand delete = new SqlCommand("DELETE FROM TBL_URUNLER WHERE ID=@s1", bgl.baglanti());
                        delete.Parameters.AddWithValue("@s1", txtId.Text);
                        delete.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        MessageBox.Show("Ürün silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Listele();
                        Temizle();
                    }
                    else
                    {
                        MessageBox.Show("Silme İşlemi İptal Edilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Listele();
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
                Listele();
            }
            else
            {
                MessageBox.Show("Lütfen Silmek Sitediğiniz Ürünü Seçiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtId.Text = dr["ID"].ToString();
            txtAd.Text = dr["URUNAD"].ToString();
            txtMarka.Text = dr["MARKA"].ToString();
            txtModel.Text = dr["MODEL"].ToString();
            mskYil.Text = dr["YIL"].ToString();
            nudAdet.Value = decimal.Parse(dr["ADET"].ToString());
            txtAlisFiyat.Text = dr["ALISFIYAT"].ToString();
            txtSatisFiyat.Text = dr["SATISFIYAT"].ToString();
            rchtDetay.Text = dr["DETAY"].ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtId.Text!="")
            {
                SqlCommand update = new SqlCommand("UPDATE TBL_URUNLER SET URUNAD=@u1,MARKA=@u2,MODEL=@u3,YIL=@u4,ADET=@u5,ALISFIYAT=@u6,SATISFIYAT=@u7,DETAY=@u8 WHERE ID=@u9", bgl.baglanti());
                update.Parameters.AddWithValue("@u1", txtAd.Text); ;
                update.Parameters.AddWithValue("@u2", txtMarka.Text);
                update.Parameters.AddWithValue("@u3", txtModel.Text);
                update.Parameters.AddWithValue("@u4", mskYil.Text);
                update.Parameters.AddWithValue("@u5", int.Parse((nudAdet.Value).ToString()));
                update.Parameters.AddWithValue("@u6", decimal.Parse(txtAlisFiyat.Text));
                update.Parameters.AddWithValue("@u7", decimal.Parse(txtSatisFiyat.Text));
                update.Parameters.AddWithValue("@u8", rchtDetay.Text);
                update.Parameters.AddWithValue("@u9", txtId.Text);
                update.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Ürün Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Listele();
                Temizle();
            }
            else
            {
                MessageBox.Show("Lütfen Bir Ürün Seçiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
