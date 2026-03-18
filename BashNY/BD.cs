using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashNY
{
    static class BD
    {
        //public static SqlConnection conn = new SqlConnection("Data Source = 192.168.166.120\\sqlexpress; Initial Catalog = basa13; User ID = basa13; Password = basa13");
        public static SqlConnection conn = new SqlConnection(@"Server=localhost\sqlexpress;Database=Doyka;Integrated Security=True;");

        public static void openSQL()
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
        }

        public static void closeSQL()
        {
            if (conn.State == ConnectionState.Open) conn.Close();
        }

    }
}
