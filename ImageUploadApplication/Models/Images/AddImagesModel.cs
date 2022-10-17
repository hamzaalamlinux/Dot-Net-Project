using ImageUploadApplication.DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ImageUploadApplication.Models
{
    public class AddImagesModel
    {
        static string ConString = DBConfig.Connection();

        public int AddImages(string BaseUrl , int userid)
        {
            using (SqlConnection con = new SqlConnection(ConString))
            {

                string Query = "[dbo].[SaveUrl]";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@base_url", SqlDbType.VarChar).Value = BaseUrl;
                cmd.Parameters.Add("@userid", SqlDbType.VarChar).Value = userid;
                cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                string id = cmd.Parameters["@id"].Value.ToString();
                con.Close();
                con.Dispose();
                return Convert.ToInt32(id);
            }
        }
    }
}