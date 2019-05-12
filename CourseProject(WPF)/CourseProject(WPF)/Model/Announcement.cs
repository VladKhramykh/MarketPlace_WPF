namespace CourseProject_WPF_.Model{

    using System;    

    public partial class Announcement
    {
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<int> seller { get; set; }
        public string category { get; set; }
        public string about { get; set; }
        public Nullable<decimal> cost { get; set; }

        public virtual User User { get; set; }

        public Announcement() { }

        public Announcement(string name, string category, string about, decimal? cost)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.category = category ?? throw new ArgumentNullException(nameof(category));
            this.about = about ?? throw new ArgumentNullException(nameof(about));
            this.cost = cost ?? throw new ArgumentNullException(nameof(cost));
        }

        public Announcement(string name, int? seller, string category, string about, decimal? cost)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.seller = seller ?? throw new ArgumentNullException(nameof(seller));
            this.category = category ?? throw new ArgumentNullException(nameof(category));
            this.about = about ?? throw new ArgumentNullException(nameof(about));
            this.cost = cost ?? throw new ArgumentNullException(nameof(cost));
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }
        public string Category
        {
            get { return category; }
            set
            {
                category = value;
            }
        }        
        public string About
        {
            get { return about; }
            set
            {
                about = value;
            }
        }
        public decimal Cost
        {
            get { return Decimal.Round(cost.Value, 2); }
            set
            {
                cost = value;
            }
        }

        public override string ToString()
        {
            return $"Название {Name}\nКатегория -  {Category}\nЦена - {Cost}\n";
        }

        public string Info
        {
            get { return $"Название - {Name}\nКатегория -  {Category}\nЦена - {Cost}\n"; }
        }       
    }
}
