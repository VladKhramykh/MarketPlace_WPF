using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_WPF_.Repositories
{
    public interface IRegionRepository
    {
        List<string> getRegions();
        string getRegion(int index);
        int getIdRegion(string region);
    }
}
