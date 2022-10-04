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
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
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
            if (cmbAy.Text == "" || cmbYil.Text == "" || txtSu.Text == "" || txtElektirik.Text == "" || txtDogalgaz.Text == "" || txtInternet.Text == "" || txtMaaslar.Text == "" || txtEkstra.Text == "")
            {
                MessageBox.Show("Gider Kaydedilemedi.\nBoş alanları doldurunuz!", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlCommand save = new SqlCommand("INSERT INTO TBL_GIDERLER (AY,YIL,ELEKTIRIK,SU,DOGALGAZ,INTERNET,MAASLAR,EKSTRA,NOTLAR) VALUES (@k1,@k2,@k3,@k4,@k5,@k6,@k7,@k8,@k9)", bgl.baglanti());
                save.Parameters.AddWithValue("@k1", cmbAy.Text);
                save.Parameters.AddWithValue("@k2", cmbYil.Text);
                save.Parameters.AddWithValue("@k3", decimal.Parse(txtElektirik.Text));
                save.Parameters.AddWithValue("@k4", decimal.Parse(txtSu.Text));
                save.Parameters.AddWithValue("@k5", decimal.Parse(txtDogalgaz.Text));
                save.Parameters.AddWithValue("@k6", decimal.Parse(txtInternet.Text));
                save.Parameters.AddWithValue("@k7", decimal.Parse(txtMaaslar.Text));
                save.Parameters.AddWithValue("@k8", decimal.Parse(txtEkstra.Text));
                save.Parameters.AddWithValue("@k9", rchtNotlar.Text);
                save.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Gider sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            GiderListesi();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtId.Text!="")
            {
                try
                {
                    DialogResult secim = MessageBox.Show("Silmek istediğinize Eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (secim == DialogResult.Yes)
                    {
                        SqlCommand delete = new SqlCommand("DELETE FROM TBL_GIDERLER WHERE ID=@s1", bgl.baglanti());
                        delete.Parameters.AddWithValue("@s1", txtId.Text);
                        delete.ExecuteNonQuery();
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
            else
            {
                MessageBox.Show("Lütfen Silmek Sitediğiniz Gideri Seçiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtId.Text!="")
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
            else
            {
                MessageBox.Show("Lütfen Bir Gider Seçiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void GridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
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
    }
}
