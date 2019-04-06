﻿using CourseProject_WPF_.Model;
using System;
using System.Data.Entity;
using System.Data.SqlClient;

namespace CourseProject_WPF_.DataBase
{
    public class EFDBContext: DbContext
    {
        public EFDBContext(string connectionString)
        {            
            Database.Connection.ConnectionString = connectionString;
        }
        
        public DbSet<User> Users { get; set; }

    }
}
