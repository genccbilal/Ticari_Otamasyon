﻿using System;
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
            txtTeslimEden.Text = "";
            txtTeslimAlan.Text = "";

            txtUrunID.Text = "";
            txtUrunAd.Text = "";
            txtMiktar.Text = "";
            txtFiyat.Text = "";
            txtTutar.Text = "";
            txtFaturaID.Text = "";

        }

        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            FaturaListesi();
            Temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtFaturaID.Text == "")
            {
                SqlCommand Kayit = new SqlCommand("INSERT INTO TBL_FATURABILGI (SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN) VALUES (@k1,@k2,@k3,@k4,@k5,@k6,@k7,@k8)", bgl.baglanti());
                Kayit.Parameters.AddWithValue("@k1", txtSeri.Text);
                Kayit.Parameters.AddWithValue("@k2", txtSeriNo.Text);
                Kayit.Parameters.AddWithValue("@k3", mskTarih.Text);
                Kayit.Parameters.AddWithValue("@k4", mskSaat.Text);
                Kayit.Parameters.AddWithValue("@k5", txtVergiDaire.Text);
                Kayit.Parameters.AddWithValue("@k6", txtAlici.Text);
                Kayit.Parameters.AddWithValue("@k7", txtTeslimEden.Text);
                Kayit.Parameters.AddWithValue("@k8", txtTeslimAlan.Text);
                Kayit.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FaturaListesi();
                Temizle();
            }
            if (txtFaturaID.Text != "")
            {
                double miktar, fiyat, tutar;
                fiyat = Convert.ToDouble(txtFiyat.Text);
                miktar = Convert.ToDouble(txtMiktar.Text);
                tutar = fiyat * miktar;
                txtTutar.Text = tutar.ToString();
                SqlCommand kayit2 = new SqlCommand("INSERT INTO TBL_FATURADETAY (URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID) VALUES (@s1,@s2,@s3,@s4,@s5)", bgl.baglanti());
                kayit2.Parameters.AddWithValue("@s1", txtUrunAd.Text);
                kayit2.Parameters.AddWithValue("@s2", txtMiktar.Text);
                kayit2.Parameters.AddWithValue("@s3", txtFiyat.Text);
                kayit2.Parameters.AddWithValue("@s4", txtTutar.Text);
                kayit2.Parameters.AddWithValue("@s5", txtFaturaID.Text);
                kayit2.ExecuteNonQuery();
                MessageBox.Show("Fatura Ayit Ürün Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FaturaListesi();
                Temizle();
            }

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtId.Text = dr["FATURABILGIID"].ToString();
            txtSeri.Text = dr["SERI"].ToString();
            txtSeriNo.Text = dr["SIRANO"].ToString();
            mskTarih.Text = dr["TARIH"].ToString();
            mskSaat.Text = dr["SAAT"].ToString();
            txtVergiDaire.Text = dr["VERGIDAIRE"].ToString();
            txtAlici.Text = dr["ALICI"].ToString();
            txtTeslimEden.Text = dr["TESLIMEDEN"].ToString();
            txtTeslimAlan.Text = dr["TESLIMALAN"].ToString();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand Delete = new SqlCommand("DELETE FROM TBL_FATURABILGI WHERE FATURABILGIID=@d1", bgl.baglanti());
            Delete.Parameters.AddWithValue("@d1", txtId.Text);
            Delete.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FaturaListesi();
            Temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand Update = new SqlCommand("UPDATE TBL_FATURABILGI SET SERI=@u1,SIRANO=@u2,TARIH=@u3,SAAT=@u4,VERGIDAIRE=@u5,ALICI=@u6,TESLIMEDEN=@u7,TESLIMALAN=@u8 WHERE FATURABILGIID=@u9", bgl.baglanti());
            Update.Parameters.AddWithValue("@u1", txtSeri.Text);
            Update.Parameters.AddWithValue("@u2", txtSeriNo.Text);
            Update.Parameters.AddWithValue("@u3", mskTarih.Text);
            Update.Parameters.AddWithValue("@u4", mskSaat.Text);
            Update.Parameters.AddWithValue("@u5", txtVergiDaire.Text);
            Update.Parameters.AddWithValue("@u6", txtAlici.Text);
            Update.Parameters.AddWithValue("@u7", txtTeslimEden.Text);
            Update.Parameters.AddWithValue("@u8", txtTeslimAlan.Text);
            Update.Parameters.AddWithValue("@u9", txtId.Text);
            Update.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            FaturaListesi();
            Temizle();

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            frmFaturaUrunler frm = new frmFaturaUrunler();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr !=null)
            {
                frm.ID = dr["FATURABILGIID"].ToString();
            }
            frm.Show();
           
        }
    }
}
