namespace CourseProject_WPF_.Model
{
    using System;
    using System.Collections.Generic;

    public partial class Region
    {
        public Region()
        {
            this.Announcements = new HashSet<Announcement>();
            this.TmpAnnouncements = new HashSet<TmpAnnouncement>();
        }

        public int id { get; set; }
        public string region1 { get; set; }


        public virtual ICollection<Announcement> Announcements { get; set; }
        public virtual ICollection<TmpAnnouncement> TmpAnnouncements { get; set; }
    }
}
