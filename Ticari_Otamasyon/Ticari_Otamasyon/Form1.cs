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
            frmAnasayfa frmA = (frmAnasayfa)Application.OpenForms["frmAnasayfa"];

            if (frmA !=null)
            {
                frmA.Focus();
                return;     
            }

            frmA = new frmAnasayfa();
            frmA.MdiParent=this;
            frmA.Show();
        }
       
        private void btnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            FrmUrunler frmUrun = (FrmUrunler)Application.OpenForms["FrmUrunler"];

            if (frmUrun!=null)
            {
                frmUrun.Focus();
                return;
            }

            frmUrun = new FrmUrunler();
            frmUrun.MdiParent = this;
            frmUrun.Show();  

        }
        
        private void btnMusteri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmMusteriler frmMstr = (frmMusteriler)Application.OpenForms["frmMusteriler"];

            if (frmMstr!=null)
            {
                frmMstr.Focus();
                return;
            }
            frmMstr = new frmMusteriler();
            frmMstr.MdiParent = this;
            frmMstr.Show();
        }

        private void btnFırmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmFırmalar frmFrm = (frmFırmalar)Application.OpenForms["frmFırmalar"];

            if (frmFrm !=null)
            {
                frmFrm.Focus();
                return;
            }

            frmFrm = new frmFırmalar();
            frmFrm.MdiParent = this;
            frmFrm.Show();
        }

        
        private void btnPersonel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmPersonel frmPrs = (FrmPersonel)Application.OpenForms["FrmPersonel"];

            if (frmPrs != null)
            {
                frmPrs.Focus();
                return;
            }

            frmPrs = new FrmPersonel();
            frmPrs.MdiParent = this;
            frmPrs.Show();
        }

        
        private void btnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmRehber frmRhb = (frmRehber)Application.OpenForms["frmRehber"];

            if (frmRhb != null)
            {
                frmRhb.Focus();
                return;
            }

            frmRhb = new frmRehber();
            frmRhb.MdiParent = this;
            frmRhb.Show();
        }
        
        private void btnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmGiderler frmGdr = (frmGiderler)Application.OpenForms["frmGiderler"];

            if (frmGdr != null)
            {
                frmGdr.Focus();
                return;
            }

            frmGdr = new frmGiderler();
            frmGdr.MdiParent = this;
            frmGdr.Show();
        }

        private void btnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBankalar frmBnk = (frmBankalar)Application.OpenForms["frmBankalar"];

            if (frmBnk != null)
            {
                frmBnk.Focus();
                return;
            }

            frmBnk = new frmBankalar();
            frmBnk.MdiParent = this;
            frmBnk.Show();
        }
        
        private void btnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmFaturalar frmFtr = (FrmFaturalar)Application.OpenForms["FrmFaturalar"];

            if (frmFtr != null)
            {
                frmFtr.Focus();
                return;
            }

            frmFtr = new FrmFaturalar();
            frmFtr.MdiParent = this;
            frmFtr.Show();
        }

        private void btnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           frmNotlar frmNot = (frmNotlar)Application.OpenForms["frmNotlar"];

            if (frmNot != null)
            {
                frmNot.Focus();
                return;
            }

            frmNot = new frmNotlar();
            frmNot.MdiParent = this;
            frmNot.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmHareketler frmHareket = (frmHareketler)Application.OpenForms["frmHareketler"];

            if (frmHareket !=null)
            {
                frmHareket.Focus();
                return;
            }

            frmHareket = new frmHareketler();
            frmHareket.MdiParent = this;
            frmHareket.Show();
        }

        
        private void btnRaporlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmRaporlar frmRpr = (frmRaporlar)Application.OpenForms["frmRaporlar"];

            if (frmRpr != null)
            {
                frmRpr.Focus();
                return;
            }

            frmRpr = new frmRaporlar();
            frmRpr.MdiParent = this;
            frmRpr.Show();
        }

        private void btnStoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmStoklar frmStok = (frmStoklar)Application.OpenForms["frmStoklar"];

            if (frmStok!=null)
            {
                frmStok.Focus();
                return;
            }

            frmStok = new frmStoklar();
            frmStok.MdiParent = this;
            frmStok.Show();
        }

        private void btnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmAyarlar frmAyar = (frmAyarlar)Application.OpenForms["frmAyarlar"];

            if (frmAyar != null)
            {
                frmAyar.Focus();
                return;
            }
            frmAyar = new frmAyarlar();
            frmAyar.Show();
        }

        private void btnKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmKasa frmK = (frmKasa)Application.OpenForms["frmKasa"];

            if (frmK!=null)
            {
                frmK.Focus();
                return;
            }
            frmK = new frmKasa();
            frmK.MdiParent = this;
            frmK.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frmAnasayfa frmA = (frmAnasayfa)Application.OpenForms["frmAnasayfa"];

            if (frmA != null)
            {
                frmA.Focus();
                return;
            }

            frmA = new frmAnasayfa();
            frmA.MdiParent = this;
            frmA.Show();
        }
    }
}
