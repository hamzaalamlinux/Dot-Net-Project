using ImageUploadApplication.DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ImageUploadApplication.Models.Users
{
    public class GetUsersModel
    {
        static string ConString = DBConfig.Connection();
        private object con;

        public static DataTable GetUser()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open(); 
                string Query = "[dbo].[GETUSERS]";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}