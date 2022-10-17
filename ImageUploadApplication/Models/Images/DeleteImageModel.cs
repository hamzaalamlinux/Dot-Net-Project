using ImageUploadApplication.DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ImageUploadApplication.Models.Images
{
    public class DeleteImageModel
    {
        static string ConString = DBConfig.Connection();

        public int Remove(int id)
        {
            using (SqlConnection con = new SqlConnection(ConString))
            {

                string Query = "[dbo].[REMOVEIMAGES]";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                con.Dispose();
                return 0;
            }
        }
    }
}