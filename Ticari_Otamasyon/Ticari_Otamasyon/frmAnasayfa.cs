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
using System.Xml;


namespace Ticari_Otamasyon
{
    public partial class frmAnasayfa : Form
    {
        public frmAnasayfa()
        {
            InitializeComponent();
        }

        sqlBaglanti bgl = new sqlBaglanti();

        void AzlStok()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT URUNAD,SUM(ADET)AS 'ADET' FROM TBL_URUNLER GROUP BY URUNAD HAVING SUM(ADET)<=20 ORDER BY ADET",bgl.baglanti());
            da.Fill(dt);
            gridControlStoklar.DataSource = dt;
        }

        void Ajanda()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP 10 TARIH,SAAT,BASLIK FROM TBL_NOTLAR WHERE DURUM='FALSE' ORDER BY NOTID DESC", bgl.baglanti());
            da.Fill(dt);
            gridControlAjanda.DataSource = dt;
        }

        void FirmaSonOn()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("EXECUTE Firmason10H", bgl.baglanti());
            da.Fill(dt);
            gridControlFirmaHareket.DataSource = dt;
        }

        void MusteriSonOn()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("EXECUTE MusteriSonOn", bgl.baglanti());
            da.Fill(dt);
            gridControlFirmaHareket.DataSource = dt;
        }

        void Fihrist()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT AD,TELEFON1 FROM TBL_FIRMALAR ORDER BY ID DESC", bgl.baglanti());
            da.Fill(dt);
            gridControlFihrist.DataSource = dt;
        }
        
        void Haberler()
        {
            XmlTextReader xmlOku = new XmlTextReader("https://www.hurriyet.com.tr/rss/anasayfa");

            while (xmlOku.Read())
            {
                if (xmlOku.Name=="title")
                {
                    listBox1.Items.Add(xmlOku.ReadString());
                }
            }
        }

        private void frmAnasayfa_Load(object sender, EventArgs e)
        {
            AzlStok();
            Ajanda();
            FirmaSonOn();
            Fihrist();

            Haberler();

            webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/today.xml ");
        }

        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            if (sayac >= 0 && sayac <= 20)
            {
                groupControl3.Text = "FİRMA SON 10 HAREKETLERİ";
                FirmaSonOn();
            }
            if (sayac >= 20 && sayac <= 40)
            {
                groupControl3.Text = "MUSTERİ SON 10 HAREKETLERİ";
                MusteriSonOn();
            }
            if (sayac >= 40)
            {
                sayac = 0;
            }
        }
    }
}
