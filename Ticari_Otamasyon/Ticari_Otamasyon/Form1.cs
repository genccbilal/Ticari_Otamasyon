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
    }
}
