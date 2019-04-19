namespace CourseProject_WPF_.Model
{
    using System;    

    public partial class TmpAnnouncement
    {
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<int> seller { get; set; }
        public string category { get; set; }
        public string about { get; set; }
        public Nullable<decimal> cost { get; set; }

        public virtual User User { get; set; }

        public TmpAnnouncement() { }

        public TmpAnnouncement(string name, int? seller, string category, string about, decimal? cost)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.seller = seller ?? throw new ArgumentNullException(nameof(seller));
            this.category = category ?? throw new ArgumentNullException(nameof(category));
            this.about = about ?? throw new ArgumentNullException(nameof(about));
            this.cost = cost ?? throw new ArgumentNullException(nameof(cost));
        }

        public override string ToString()
        {
            return $"{name}\n{seller}\n{about}\n{cost}\n";
        }
    }
}
