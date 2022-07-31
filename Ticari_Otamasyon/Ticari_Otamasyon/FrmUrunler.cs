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
            //Verileri kaydetme
            SqlCommand kayit = new SqlCommand("INSERT INTO TBL_URUNLER (URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY) VALUES (@k1,@k2,@k3,@k4,@k5,@k6,@k7,@k8)", bgl.baglanti());
            kayit.Parameters.AddWithValue("@k1", txtAd.Text); ;
            kayit.Parameters.AddWithValue("@k2", txtMarka.Text);
            kayit.Parameters.AddWithValue("@k3", txtModel.Text);
            kayit.Parameters.AddWithValue("@k4", mskYil.Text);
            kayit.Parameters.AddWithValue("@k5", int.Parse((nudAdet.Value).ToString()));
            kayit.Parameters.AddWithValue("@k6", decimal.Parse(txtAlisFiyat.Text));
            kayit.Parameters.AddWithValue("@k7", decimal.Parse(txtSatisFiyat.Text));
            kayit.Parameters.AddWithValue("@k8", rchtDetay.Text);
            kayit.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand sil = new SqlCommand("DELETE FROM TBL_URUNLER WHERE ID=@s1", bgl.baglanti());
            sil.Parameters.AddWithValue("@s1", txtId.Text);
            sil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtId.Text = dr["ID"].ToString();
            txtAd.Text = dr["URUNAD"].ToString();
            txtMarka.Text = dr["MARKA"].ToString();
            txtModel.Text = dr["MODEL"].ToString();
            mskYil.Text= dr["YIL"].ToString();
            nudAdet.Value=decimal.Parse( dr["ADET"].ToString());
            txtAlisFiyat.Text = dr["ALISFIYAT"].ToString();
            txtSatisFiyat.Text = dr["SATISFIYAT"].ToString();
            rchtDetay.Text = dr["DETAY"].ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
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
    }
}
