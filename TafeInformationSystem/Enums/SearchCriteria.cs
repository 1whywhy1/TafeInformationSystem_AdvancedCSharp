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
            NoLocation,
            All
        }
        public enum UnitSearchBy
        {
            ID,
            Name,
            AllForCourse,
            NotAllocated,
            All
        }
        public enum EnrolmentSearchBy
        {
            ID,
            StudentID
        }

        public enum CCSSearchBy
        {
            ID,
            CourseID,
            CollegeID,
            SemesterID,
            All
        }

        public enum SemesterSearchBy
        {
            ID,
            All
        }

    }
}
