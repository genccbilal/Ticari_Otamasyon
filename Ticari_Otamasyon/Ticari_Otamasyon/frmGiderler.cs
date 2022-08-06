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
    public partial class frmGiderler : Form
    {
        public frmGiderler()
        {
            InitializeComponent();
        }


        sqlBaglanti bgl = new sqlBaglanti();
        void GiderListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_GIDERLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void Temizle()
        {
            txtId.Text = "";
            cmbAy.Text = "";
            cmbYil.Text = "";
            txtElektirik.Text = "";
            txtSu.Text = "";
            txtDogalgaz.Text = "";
            txtInternet.Text = "";
            txtMaaslar.Text = "";
            txtEkstra.Text = "";
            rchtNotlar.Text = "";
        }

        private void frmGiderler_Load(object sender, EventArgs e)
        {
            GiderListesi();
            Temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtSu.Text == "" || txtElektirik.Text == "" || txtDogalgaz.Text == "" || txtInternet.Text == "" || txtInternet.Text == "" || txtEkstra.Text == "")
            {
                MessageBox.Show("Gider Kaydedilemedi.\nBoş alanları doldurunuz!", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlCommand komut = new SqlCommand("INSERT INTO TBL_GIDERLER (AY,YIL,ELEKTIRIK,SU,DOGALGAZ,INTERNET,MAASLAR,EKSTRA,NOTLAR) VALUES (@k1,@k2,@k3,@k4,@k5,@k6,@k7,@k8,@k9)", bgl.baglanti());
                komut.Parameters.AddWithValue("@k1", cmbAy.Text);
                komut.Parameters.AddWithValue("@k2", cmbYil.Text);
                komut.Parameters.AddWithValue("@k3", decimal.Parse(txtElektirik.Text));
                komut.Parameters.AddWithValue("@k4", decimal.Parse(txtSu.Text));
                komut.Parameters.AddWithValue("@k5", decimal.Parse(txtDogalgaz.Text));
                komut.Parameters.AddWithValue("@k6", decimal.Parse(txtInternet.Text));
                komut.Parameters.AddWithValue("@k7", decimal.Parse(txtMaaslar.Text));
                komut.Parameters.AddWithValue("@k8", decimal.Parse(txtEkstra.Text));
                komut.Parameters.AddWithValue("@k9", rchtNotlar.Text);
                komut.ExecuteNonQuery(); 
                bgl.baglanti().Close();
                MessageBox.Show("Gider sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            GiderListesi();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult secim = MessageBox.Show("Silmek istediğinize Eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (secim == DialogResult.Yes)
                {
                    SqlCommand sil = new SqlCommand("DELETE FROM TBL_GIDERLER WHERE ID=@s1", bgl.baglanti());
                    sil.Parameters.AddWithValue("@s1", txtId.Text);
                    sil.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Gider silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    MessageBox.Show("Silme İşlemi İptal Edilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GiderListesi();
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
            GiderListesi();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtId.Text = dr["ID"].ToString();
            cmbAy.Text = dr["AY"].ToString();
            cmbYil.Text = dr["YIL"].ToString();
            txtElektirik.Text = dr["ELEKTIRIK"].ToString();
            txtDogalgaz.Text = dr["DOGALGAZ"].ToString();
            txtSu.Text = dr["SU"].ToString();
            txtInternet.Text = dr["INTERNET"].ToString();
            txtMaaslar.Text = dr["MAASLAR"].ToString();
            txtEkstra.Text = dr["EKSTRA"].ToString();
            rchtNotlar.Text = dr["NOTLAR"].ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand update = new SqlCommand("UPDATE TBL_GIDERLER SET  AY=@u1,YIL=@u2,ELEKTIRIK=@u3,DOGALGAZ=@u4,SU=@u5,INTERNET=@u6,MAASLAR=@u7,EKSTRA=@u8,NOTLAR=@u9 WHERE ID=@u10", bgl.baglanti());
            update.Parameters.AddWithValue("@u1", cmbAy.Text);
            update.Parameters.AddWithValue("@u2", cmbYil.Text);
            update.Parameters.AddWithValue("@u3", decimal.Parse(txtElektirik.Text));
            update.Parameters.AddWithValue("@u4", decimal.Parse(txtDogalgaz.Text));
            update.Parameters.AddWithValue("@u5", decimal.Parse(txtSu.Text));
            update.Parameters.AddWithValue("@u6", decimal.Parse(txtInternet.Text));
            update.Parameters.AddWithValue("@u7", decimal.Parse(txtMaaslar.Text));
            update.Parameters.AddWithValue("@u8", decimal.Parse(txtEkstra.Text));
            update.Parameters.AddWithValue("@u9", rchtNotlar.Text);
            update.Parameters.AddWithValue("@u10", txtId.Text);
            update.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            GiderListesi();
            Temizle();
        }
    }
}
