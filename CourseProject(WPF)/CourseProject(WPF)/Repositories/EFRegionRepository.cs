using CourseProject_WPF_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_WPF_.Repositories
{
    public class EFRegionRepository : IRegionRepository
    {
        private NewMarketPlaceEntities1 context;

        public EFRegionRepository()
        {
            context = new NewMarketPlaceEntities1();
        }

        public List<string> getRegions()
        {
            List<string> tmp = new List<string>();

            foreach (Region region in context.Regions)
                tmp.Add(region.region1);

            return tmp.Distinct().ToList();
        }

        public string getRegion(int index)
        {
            return context.Regions.FirstOrDefault(x=> x.id == index).region1;
        }

        public int getIdRegion(string region)
        {
            return context.Regions.FirstOrDefault(x => x.region1.Equals(region)).id;
        }
    }
}
