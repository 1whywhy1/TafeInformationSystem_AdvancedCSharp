using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeInformationSystem.Enums
{
    class SearchCriteria
    {
        internal enum StudentSearchBy
        {
            ID,
            FirstName,
            LastName,
            NotPaid,
            FullTime,
            PartTime
        }
        internal enum TeacherSearchBy
        {
            ID,
            FirstName,
            LastName,
            Location
        }
        internal enum CourseSearchBy
        {
            ID,
            Name,
            Location,
            Teacher,
            NoLocation
        }
        internal enum UnitSearchBy
        {
            ID,
            Name,
            AllForCourse,
            NotAllocated            
        }
        internal enum EnrolmentSearchBy
        {
            ID,
            StudentID
        }
    }
}
