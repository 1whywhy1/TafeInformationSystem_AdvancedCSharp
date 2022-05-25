using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeInformationSystem.Enums
{
    internal class TeacherSearchBy : SearchCriteria
    {        
        internal enum SearchBy
        {
            ID,
            FirstName,
            LastName,
            Location
        }
    }
}
