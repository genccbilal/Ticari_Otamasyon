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
    public partial class frmNotlar : Form
    {
        public frmNotlar()
        {
            InitializeComponent();
        }

        sqlBaglanti bgl = new sqlBaglanti();

        void NotListele()
        {
            DataTable dt = new DataTable();
          //SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_NOTLAR WHERE DURUM='"+false+"'",bgl.baglanti()); SQL Kodunu procedur oluşturarak çağırdım
            SqlDataAdapter da = new SqlDataAdapter("EXECUTE NotDurum", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void Temizle()
        {
            txtId.Text = "";
            mskSaat.Text = "";
            mskTarih.Text = "";
            txtBaslık.Text = "";
            txtHitap.Text = "";
            txtOlusturan.Text = "";
            rchtDetay.Text = "";
        }

        private void frmNotlar_Load(object sender, EventArgs e)
        {
            NotListele();
            Temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand save = new SqlCommand("INSERT INTO TBL_NOTLAR (TARIH,SAAT,BASLIK,DETAY,OLUSTURAN,HITAP) VALUES (@s1,@s2,@s3,@s4,@s5,@s6)", bgl.baglanti());
            save.Parameters.AddWithValue("@s1",mskTarih.Text);
            save.Parameters.AddWithValue("@s2",mskSaat.Text);
            save.Parameters.AddWithValue("@s3",txtBaslık.Text);
            save.Parameters.AddWithValue("@s4",rchtDetay.Text);
            save.Parameters.AddWithValue("@s5",txtOlusturan.Text);
            save.Parameters.AddWithValue("@s6",txtHitap.Text);
            save.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            NotListele();
            Temizle();

        }


        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult secim = MessageBox.Show("Silmek İstediğinize Emin misiniz ? ", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (secim == DialogResult.Yes)
                {
                    SqlCommand Delet = new SqlCommand("DELETE FROM TBL_NOTLAR WHERE NOTID=@d1", bgl.baglanti());
                    Delet.Parameters.AddWithValue("@d1", txtId.Text);
                    Delet.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    Temizle();
                }
                else
                {
                    MessageBox.Show("Silme İşlemi İptal Edilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NotListele();
                    Temizle();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Meydana Geldi.Lütfen Silmek İstediğiniz Stüna İki Kere Tıklayarak Tekrar Deneyiniz.!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Temizle();
            }
            NotListele();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();                  
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand Update = new SqlCommand("UPDATE TBL_NOTLAR SET TARIH=@u1,SAAT=@u2,OLUSTURAN=@u3,HITAP=@u4,BASLIK=@u5,DETAY=@u6 WHERE NOTID=@u7", bgl.baglanti());
            Update.Parameters.AddWithValue("@u1",mskTarih.Text);
            Update.Parameters.AddWithValue("@u2",mskSaat.Text);
            Update.Parameters.AddWithValue("@u3",txtOlusturan.Text);
            Update.Parameters.AddWithValue("@u4",txtHitap.Text);
            Update.Parameters.AddWithValue("@u5",txtBaslık.Text);
            Update.Parameters.AddWithValue("@u6",rchtDetay.Text);
            Update.Parameters.AddWithValue("@u7", txtId.Text);
            Update.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            NotListele();
            Temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtId.Text = dr["NOTID"].ToString();
            mskTarih.Text = dr["TARIH"].ToString();
            mskSaat.Text = dr["TARIH"].ToString();
            txtOlusturan.Text = dr["OLUSTURAN"].ToString();
            txtHitap.Text = dr["HITAP"].ToString();
            txtBaslık.Text = dr["BASLIK"].ToString();
            rchtDetay.Text = dr["DETAY"].ToString();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //mesajı ayrı ekranda görüntüleme ve durumu okundu yapma 

            frmNotDetay frm = new frmNotDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                frm.metin = dr["DETAY"].ToString();
                string ID = dr["NOTID"].ToString();
                SqlCommand cmd = new SqlCommand("Update TBL_NOTLAR SET DURUM=@DURUM WHERE NOTID=@ID", bgl.baglanti());
                cmd.Parameters.AddWithValue("@ID", txtId.Text);
                cmd.Parameters.AddWithValue("@DURUM", true);
                cmd.ExecuteNonQuery();
                bgl.baglanti().Close();
            }
            frm.Show();
        }

        private void frmNotlar_MouseHover(object sender, EventArgs e)
        {
            NotListele();
            Temizle();
        }
    }
}
