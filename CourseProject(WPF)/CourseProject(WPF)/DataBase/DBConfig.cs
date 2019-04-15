using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CourseProject_WPF_.DataBase
{

    public static class DBConfig
    {
        const string dbServerName = "LENOVOIDEAPAD51";
        const string dbConnUser = "CourseProject";
        const string dbPassword = "12345678";
        const string dbName = "MarketPlace";        

        public static string connectionString = $"Data Source={dbServerName};initial catalog={dbName};Persist Security Info=true;User ID={dbConnUser};Password={dbPassword}";

        public static SqlConnectionStringBuilder builder = getConn();

        private static SqlConnectionStringBuilder getConn()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder["Data Source"] = dbServerName;
            builder["integrated Security"] = true;
            builder["User ID"] = dbConnUser;
            builder["Password"] = dbPassword;
            builder["Initial Catalog"] = dbName;
            return builder;
        }

       
    }
}
