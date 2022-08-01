using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Mail Göndermek işlemleri için bu iki kütüphaneyi ekledik
using System.Net;
using System.Net.Mail;

namespace Ticari_Otamasyon
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }
        public string Mail;
        private void FrmMail_Load(object sender, EventArgs e)
        {
            txtMailAdres.Text = Mail;
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {

        }
    }
}
