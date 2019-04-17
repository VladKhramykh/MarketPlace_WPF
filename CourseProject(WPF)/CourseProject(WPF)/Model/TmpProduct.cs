namespace CourseProject_WPF_
{
    using CourseProject_WPF_.Model;
    using System;
    using System.Collections.Generic;

    public partial class TmpProduct
    {
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<int> seller { get; set; }
        public string category { get; set; }
        public string about { get; set; }
        public Nullable<decimal> cost { get; set; }

        public virtual User User { get; set; }
    }
}