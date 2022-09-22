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
    public partial class frmAyarlar : Form
    {
        public frmAyarlar()
        {
            InitializeComponent();
        }

        sqlBaglanti bgl = new sqlBaglanti();

        void AdminListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_ADMIN  ORDER BY ID ASC", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }

        void Temizle()
        {
            txtEditKullaniciAd.Text = "";
            TxtSifre.Text = "";
            txtId.Text = "";
        }

        private void frmAyarlar_Load(object sender, EventArgs e)
        {
            AdminListesi();
            Temizle();
            btnSil.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (btnIslem.Text == "KAYDET")
            {
                SqlCommand save = new SqlCommand("INSERT INTO TBL_ADMIN (KULLANICIAD,SIFRE)VALUES(@s1,@s2)", bgl.baglanti());
                save.Parameters.AddWithValue("@s1", txtEditKullaniciAd.Text);
                save.Parameters.AddWithValue("@s2", TxtSifre.Text);
                save.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Yeni Admin Sisteme Kaydedildi", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AdminListesi();
                Temizle();
            }
            if (btnIslem.Text=="GUNCELLE")
            {
                SqlCommand update = new SqlCommand("UPDATE TBL_ADMIN SET KULLANICIAD=@u1,SIFRE=@u2 WHERE ID=@u3 ", bgl.baglanti());
                update.Parameters.AddWithValue("@u1", txtEditKullaniciAd.Text);
                update.Parameters.AddWithValue("@u2", TxtSifre.Text);
                update.Parameters.AddWithValue("@u3", txtId.Text);
                update.ExecuteNonQuery();
                MessageBox.Show("Kayıt Güncellendi", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AdminListesi();
                Temizle();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                txtId.Text =dr[0].ToString();
                txtId.Visible = false;
                txtEditKullaniciAd.Text = dr[1].ToString();
                TxtSifre.Text = dr[2].ToString();

                btnIslem.Text = "GUNCELLE";
                btnSil.Visible = true;
                this.gridView1.Columns["ID"].Visible = false;//GridView deki ilk sütun olan ıd gizliyoruz
            }          
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (txtEditKullaniciAd.Text=="")
            {
                btnIslem.Text = "KAYDET";
                btnSil.Visible = false;
                Temizle();               
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand Delete = new SqlCommand("DELETE FROM TBL_ADMIN WHERE ID=@d1", bgl.baglanti());
            Delete.Parameters.AddWithValue("@d1",txtId.Text);
            Delete.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            AdminListesi();
            Temizle();
        }
    }
}
