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
            NotPaid
        }
        enum TeacherSearchBy
        {
            ID,
            FirstName,
            LastName,
            Location,
        }
        enum CourseSearchBy
        {
            ID,
            Name,
            Location,
            NoLocation,
            Teacher
        }
        enum UnitSearchBy
        {
            ID,
            Name,
            NotAllocated,
            AllForCourse
        }
        enum EnrolmentSearchBy
        {
            ID,
            StudentID,
        }
    }
}
