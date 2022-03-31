using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResimGaleri.ORM.Facade
{
    public class Urunlers
    {
        public static DataTable Listele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("prc_Urunler_Select", Tools.Connection);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataSet ds = new DataSet();
            adp.Fill(ds, "Urunler");
            return ds.Tables["Urunler"];
        }
    }
}
