using ImageUploadApplication.DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ImageUploadApplication.Models.Images
{
    public class GetFolder
    {
        static string ConString = DBConfig.Connection();
        public static DataTable GetFolders()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                string Query = "[dbo].[GETFOLDERS]";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }


    }
}