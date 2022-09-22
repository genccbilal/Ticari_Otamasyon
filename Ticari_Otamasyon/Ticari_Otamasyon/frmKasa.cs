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
using DevExpress.Charts;

namespace Ticari_Otamasyon
{
    public partial class frmKasa : Form
    {
        public frmKasa()
        {
            InitializeComponent();
        }

        sqlBaglanti bgl = new sqlBaglanti();

        void MusteriHareketleri()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("EXECUTE MusteriHareketler ", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void FirmaHareketleri()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("EXECUTE FirmaHareketler ", bgl.baglanti());
            da.Fill(dt);
            gridControl3.DataSource = dt;
        }

        void Giderler()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TBL_GIDERLER ORDER BY ID ASC ", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }

        private void frmKasa_Load(object sender, EventArgs e)
        {
            MusteriHareketleri();
            FirmaHareketleri();
            Giderler();


            //toplam tutar
            SqlCommand komut1 = new SqlCommand("SELECT SUM(TUTAR) FROM TBL_FATURADETAY", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblKasaToplam.Text = dr1[0].ToString() + " TL";
            }
            bgl.baglanti().Close();

            //Son ayın fatura toplamı
            SqlCommand komut2 = new SqlCommand("Select (ELEKTIRIK+SU+DOGALGAZ+INTERNET+EKSTRA) from TBL_GIDERLER order by ID desc", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblOdemeler.Text = dr2[0].ToString() + " TL";
            }
            bgl.baglanti().Close();

            //Son ayda ödenen personel maaşı
            SqlCommand komut3 = new SqlCommand("SELECT (MAASLAR) FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblPersonelMaaslari.Text = dr3[0].ToString() + " TL";
            }
            bgl.baglanti().Close();

            //Toplam müşteri sayısı
            SqlCommand komut4 = new SqlCommand("SELECT COUNT(*) FROM TBL_MUSTERILER", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblMusteriSayisi.Text = dr4[0].ToString();
            }
            bgl.baglanti().Close();

            //Toplam firma sayısı
            SqlCommand komut5 = new SqlCommand("SELECT COUNT(*) FROM TBL_FIRMALAR", bgl.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblFirmaSayisi.Text = dr5[0].ToString();
            }
            bgl.baglanti().Close();

            //Firmaların Şehir Sayısı
            SqlCommand komut6 = new SqlCommand("SELECT COUNT(DISTINCT(IL)) FROM TBL_FIRMALAR ", bgl.baglanti());
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblSehirSayisi.Text = dr6[0].ToString();
            }
            bgl.baglanti().Close();

            //Müşterilerin Şehir Sayısı
            SqlCommand komut7 = new SqlCommand("SELECT COUNT(DISTINCT(IL)) FROM TBL_MUSTERILER", bgl.baglanti());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                lblMuSehirSayisi.Text = dr7[0].ToString();
            }
            bgl.baglanti().Close();

            //Toplam personel sayısı
            SqlCommand komut8 = new SqlCommand("SELECT COUNT(*) FROM TBL_PERSONELLER", bgl.baglanti());
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                lblPersonelSayisi.Text = dr8[0].ToString();
            }
            bgl.baglanti().Close();

            //Toplam Ürün Sayısı
            SqlCommand komut9 = new SqlCommand("SELECT SUM(ADET) FROM TBL_URUNLER", bgl.baglanti());
            SqlDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {
                lblStokSayisi.Text = dr9[0].ToString();
            }
            bgl.baglanti().Close();


        }
        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;

            //Elektirik
            if (sayac > 0 && sayac <= 10)
            {
                groupControl10.Text = "Elektrik";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut1 = new SqlCommand("SELECT TOP 4 AY,ELEKTIRIK FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr1 = komut1.ExecuteReader();
                while (dr1.Read())
                {

                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr1[0], dr1[1]));
                }
                bgl.baglanti().Close();
            }
            //Su
            if (sayac >= 10 && sayac <= 20)
            {
                groupControl10.Text = "SU";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut1 = new SqlCommand("SELECT TOP 4 AY,SU FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr1 = komut1.ExecuteReader();
                while (dr1.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr1[0], dr1[1]));
                }
                bgl.baglanti().Close();
            }
            //Doğalgaz
            if (sayac >= 20 && sayac <= 30)
            {
                groupControl10.Text = "DOĞALGAZ";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut1 = new SqlCommand("SELECT TOP 4 AY,DOGALGAZ FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr1 = komut1.ExecuteReader();
                while (dr1.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr1[0], dr1[1]));
                }
                bgl.baglanti().Close();
            }
            //İnternet
            if (sayac >= 30 && sayac <= 40)
            {
                groupControl10.Text = "İNTERNET";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut1 = new SqlCommand("SELECT TOP 4 AY,INTERNET FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr1 = komut1.ExecuteReader();
                while (dr1.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr1[0], dr1[1]));
                }
                bgl.baglanti().Close();
            }
            //Ekstralar
            if (sayac >= 40 && sayac <= 50)
            {
                groupControl10.Text = "EKSTRALAR";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut1 = new SqlCommand("SELECT TOP 4 AY,EKSTRA FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr1 = komut1.ExecuteReader();
                while (dr1.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr1[0], dr1[1]));
                }
                bgl.baglanti().Close();
            }

            if (sayac >= 50)
            {
                sayac = 0;
            }
        }
        int sayac2 = 0;
        private void timer2_Tick_1(object sender, EventArgs e)
        {
            sayac2++;

            //Elektirik
            if (sayac2 > 0 && sayac2 <= 15)
            {
                groupControl11.Text = "Elektrik";
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut1 = new SqlCommand("SELECT TOP 4 AY,ELEKTIRIK FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr1 = komut1.ExecuteReader();
                while (dr1.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr1[0], dr1[1]));
                }
                bgl.baglanti().Close();
            }
            //Su
            if (sayac2 >= 15 && sayac2 <= 30)
            {
                groupControl11.Text = "SU";
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut1 = new SqlCommand("SELECT TOP 4 AY,SU FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr1 = komut1.ExecuteReader();
                while (dr1.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr1[0], dr1[1]));
                }
                bgl.baglanti().Close();
            }
            //Doğalgaz
            if (sayac2 >= 30 && sayac2 <= 45)
            {
                groupControl11.Text = "DOĞALGAZ";
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut1 = new SqlCommand("SELECT TOP 4 AY,DOGALGAZ FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr1 = komut1.ExecuteReader();
                while (dr1.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr1[0], dr1[1]));
                }
                bgl.baglanti().Close();
            }
            //İnternet
            if (sayac2 >= 45 && sayac2 <= 60)
            {
                groupControl11.Text = "İNTERNET";
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut1 = new SqlCommand("SELECT TOP 4 AY,INTERNET FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr1 = komut1.ExecuteReader();
                while (dr1.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr1[0], dr1[1]));
                }
                bgl.baglanti().Close();
            }
            //Ekstralar
            if (sayac2 >= 60 && sayac2 <= 75)
            {
                groupControl11.Text = "EKSTRALAR";
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut1 = new SqlCommand("SELECT TOP 4 AY,EKSTRA FROM TBL_GIDERLER ORDER BY ID DESC", bgl.baglanti());
                SqlDataReader dr1 = komut1.ExecuteReader();
                while (dr1.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr1[0], dr1[1]));
                }
                bgl.baglanti().Close();
            }

            if (sayac2 >= 75)
            {
                sayac = 0;
            }
        }
    }
}
