using CourseProject_WPF_.Model;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace CourseProject_WPF_.DataBase
{
    public class EFDBContext: DbContext
    {
        public EFDBContext() : base("DbConnectionString") 
        {            
        }


        public virtual DbSet<Announcement> Announcements { get; set; }
        //public virtual DbSet<TmpProduct> TmpProduct { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }
}
