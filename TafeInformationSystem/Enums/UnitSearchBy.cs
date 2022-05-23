using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeInformationSystem.Enums
{
    internal class UnitSearchBy : SearchCriteria
    {
        public enum SearchBy
        {
            ID,
            Name,
            AllForCourse,
            NotAllocated
        }
    }
}
