using ImageUploadApplication.DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ImageUploadApplication.Models.Users
{
    public class UsersModel
    {
        static string ConString = DBConfig.Connection();
        private object con;

        public int AddUsers(string username , string email , string password)
        {
            using (SqlConnection con = new SqlConnection(ConString))
            {

                string Query = "[dbo].[SaveUser]";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
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