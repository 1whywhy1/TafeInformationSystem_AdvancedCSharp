using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeInformationSystem.Enums
{
    internal class CourseSearchBy : SearchCriteria
    {
        internal enum SearchBy
        {
            ID,
            Name,
            Location,
            Teacher,
            NoLocation
        }
    }
}
