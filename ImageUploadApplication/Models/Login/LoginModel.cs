using ImageUploadApplication.DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ImageUploadApplication.Models.Login
{
    public class LoginModel
    {
        static string ConString = DBConfig.Connection();

        public string Authentication(string email , string password)
        {
            using(SqlConnection con = new SqlConnection(ConString))
            {
                string Query = "[dbo].[login]";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
                cmd.Parameters.Add("@retValue", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                string status = cmd.Parameters["@retValue"].Value.ToString();
                con.Close();
                con.Dispose();
                return status;

            }
        }
    }
}