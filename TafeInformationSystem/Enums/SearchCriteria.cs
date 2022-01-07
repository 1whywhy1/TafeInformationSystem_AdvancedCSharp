using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeInformationSystem.Enums
{
    class SearchCriteria
    {
        enum StudentSearchBy
        {
            ID,
            FirstName,
            LastName,
            NotPaid,
            FullTime,
            PartTime
        }
        enum TeacherSearchBy
        {
            ID,
            FirstName,
            LastName,
            Location
        }
        enum CourseSearchBy
        {
            ID,
            Name,
            Location,
            Teacher,
            NoLocation
        }
        enum UnitSearchBy
        {
            ID,
            Name,
            AllForCourse,
            NotAllocated            
        }
        enum EnrolmentSearchBy
        {
            ID,
            StudentID
        }
    }
}
