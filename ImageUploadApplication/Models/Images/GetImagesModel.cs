using ImageUploadApplication.DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ImageUploadApplication.Models.Images
{
    public class GetImagesModel
    {
        static string ConString = DBConfig.Connection();
        public DataTable GetImages(int id)
        {
            DataTable dt = new DataTable();
           
            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                string Query = "[dbo].[GETIMAGES]";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("id" , SqlDbType.Int).Value = id;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

    }
}