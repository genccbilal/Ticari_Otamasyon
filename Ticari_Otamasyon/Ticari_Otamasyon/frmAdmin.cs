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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        sqlBaglanti bgl = new sqlBaglanti();

        private void btnGiriş_Click(object sender, EventArgs e)
        {

            if (TxtKullaniciAd.Text!= "")
            {
                if (TxtSifre.Text!="")
                {
                    SqlCommand komut = new SqlCommand("SELECT *FROM TBL_ADMIN WHERE KULLANICIAD=@k1 AND SIFRE=@k2", bgl.baglanti());
                    komut.Parameters.AddWithValue("@k1", TxtKullaniciAd.Text);
                    komut.Parameters.AddWithValue("@k2", TxtSifre.Text);
                    SqlDataReader da = komut.ExecuteReader();
                    if (da.Read())
                    {
                        Form1 frm = new Form1();
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre hatalı ", "Uyarı ", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Kullanıcı Şifresini giriniz", "Uyarı ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lütfen Kullanıcı Adını giriniz ", "Uyarı ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        private void PictureEdit1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
