using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeInformationSystem.Enums
{
    public class SearchCriteria
    {
        public enum StudentSearchBy
        {
            ID,
            FirstName,
            LastName,
            NotPaid,
            FullTime,
            PartTime
        }
        public enum TeacherSearchBy
        {
            ID,
            FirstName,
            LastName,
            Location
        }
        public enum CourseSearchBy
        {
            ID,
            Name,
            Location,
            Teacher,
            NoLocation
        }
        public enum UnitSearchBy
        {
            ID,
            Name,
            AllForCourse,
            NotAllocated            
        }
        public enum EnrolmentSearchBy
        {
            ID,
            StudentID
        }
    }
}
