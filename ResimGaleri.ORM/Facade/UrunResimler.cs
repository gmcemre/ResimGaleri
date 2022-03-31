using ResimGaleri.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResimGaleri.ORM.Facade
{
    public class UrunResimler
    {
        public static bool Ekle(UrunResim ur)
        {
            SqlCommand cmd = new SqlCommand("prc_ResimEkle", Tools.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pId", ur.UrunID);
            cmd.Parameters.AddWithValue("@resim", ur.Resim.Length).Value = ur.Resim;

            Tools.Connection.Open();

            int rowAffected = cmd.ExecuteNonQuery();
            if (rowAffected > 0)
            {
                Tools.Connection.Close();
                return true;
            }
            else
            {
                Tools.Connection.Close();
                return false;
            }

        }

        public static DataTable Listele(int id)
        {
            SqlDataAdapter adp = new SqlDataAdapter("prc_ResimGetir", Tools.Connection);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            adp.SelectCommand.Parameters.AddWithValue("@id", id);
            DataSet ds = new DataSet();
            adp.Fill(ds, "Resimler");
            return ds.Tables["Resimler"];

        }
    }
}
