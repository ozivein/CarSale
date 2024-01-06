using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ArabaSatis
{
    internal class sqlbaglanti
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-555KE9Q\\SQLEXPRESS;Initial Catalog=AracSatis;Integrated Security=True");
            baglan.Open();
            return baglan;
        }

    }
}
