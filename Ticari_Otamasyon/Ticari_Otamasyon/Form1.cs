using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otamasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        FrmUrunler frm;
        private void btnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (frm==null || frm.IsDisposed)//frmUrunler sürekli açmasını engelleriz (frm.IsDisposed): ürünler formunu scrolla kapattıktan sonra tekrar açılması için kullanırız
            {
                frm = new FrmUrunler();
                frm.MdiParent = this;
                frm.Show();
            }
            

        }
        frmMusteriler frm2;
        private void btnMusteri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm2 == null || frm2.IsDisposed)
            {
                frm2 = new frmMusteriler();
                frm2.MdiParent = this;
                frm2.Show();
            }
          
        }

        frmFırmalar frm3;
        private void btnFırmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm3== null || frm3.IsDisposed)
            {
                frm3 = new frmFırmalar();
                frm3.MdiParent = this;
                frm3.Show();
            }
        }

        FrmPersonel frm4;
        private void btnPersonel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm4== null || frm4.IsDisposed)
            {
                frm4 = new FrmPersonel();
                frm4.MdiParent = this;
                frm4.Show();
            }
        }

        frmRehber frm5;
        private void btnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm5== null || frm5.IsDisposed)
            {
                frm5 = new frmRehber();
                frm5.MdiParent = this;
                frm5.Show();
            }
        }
        frmGiderler frm6;
        private void btnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm6==null || frm6.IsDisposed)
            {
                frm6 = new frmGiderler();
                frm6.MdiParent = this;
                frm6.Show();
            }
        }

        frmBankalar frm7;
        private void btnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm7==null || frm7.IsDisposed)
            {
                frm7 = new frmBankalar();
                frm7.MdiParent = this;
                frm7.Show();
            }
        }
        FrmFaturalar frm8;
        private void btnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm8 == null || frm8.IsDisposed)
            {
                frm8 = new FrmFaturalar();
                frm8.MdiParent = this;
                frm8.Show();
            }
        }

        private void btnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           frmNotlar frmnotlar = (frmNotlar)Application.OpenForms["frmNotlar"];

            if (frmnotlar != null)
            {
                frmnotlar.Focus();
                return;
            }

            frmnotlar = new frmNotlar();
            frmnotlar.MdiParent = this;
            frmnotlar.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmHareketler frmHareket = (frmHareketler)Application.OpenForms["frmHareket"];

            if (frmHareket!=null)
            {
                frmHareket.Focus();
                return;
            }

            frmHareket = new frmHareketler();
            frmHareket.MdiParent = this;
            frmHareket.Show();
        }
    }
}
