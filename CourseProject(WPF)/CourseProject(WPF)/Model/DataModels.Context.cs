namespace CourseProject_WPF_.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MarketPlaceEntities : DbContext
    {
        public MarketPlaceEntities()
            : base("name=MarketPlaceEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<TmpProduct> TmpProducts { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
