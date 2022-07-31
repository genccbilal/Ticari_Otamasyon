using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ticari_Otamasyon
{
    class sqlBaglanti
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-K84VPRL;Initial Catalog=TicariOtomasyon;Integrated Security=True");
            baglan.Open();
            return baglan;
        }

    }
}
