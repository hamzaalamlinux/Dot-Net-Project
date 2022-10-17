using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ImageUploadApplication.DbConnection
{
    public class DBConfig
    {
        public static string Connection()
        {

            string ConString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            return ConString;
        }
    }
}