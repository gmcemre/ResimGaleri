using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResimGaleri.ORM
{
    public class Tools
    {
        private static SqlConnection _Connection;

        public static SqlConnection Connection
        {
            get
            {
                _Connection = _Connection ?? new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
                return _Connection;
            }
        }

    }
}
