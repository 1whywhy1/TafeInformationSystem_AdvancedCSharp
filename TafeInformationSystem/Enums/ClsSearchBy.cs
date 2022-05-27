using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeInformationSystem.Enums
{
    internal class ClsSearchBy
    {
        private Dictionary<SearchBy, string> _searchCriteria;

        public Dictionary<SearchBy, string> SearchCriteria
        {
            get { return _searchCriteria; }
        }

        public ClsSearchBy()
        {
            //_searchCriteria = new Dictionary<SearchBy, string>();
            //_searchCriteria.Add(SearchBy.StID,
            //_searchCriteria.Add(SearchBy.StFirstName,
            //_searchCriteria.Add(SearchBy.StLastName,
            //_searchCriteria.Add(SearchBy.StNotPaid,
            //_searchCriteria.Add(SearchBy.StFullTime,
            //_searchCriteria.Add(SearchBy.StPartTime,
            //_searchCriteria.Add(SearchBy.TchID,
            //_searchCriteria.Add(SearchBy.TchFirstName,
            //_searchCriteria.Add(SearchBy.TchLastName,
            //_searchCriteria.Add(SearchBy.TchLocation,
            //_searchCriteria.Add(SearchBy.CrsID, $"EXEC spSelectCourseByID_course @CourseID = {CourseID};");
            //_searchCriteria.Add(SearchBy.CrsName,
            //_searchCriteria.Add(SearchBy.CrsLocation,
            //_searchCriteria.Add(SearchBy.CrsTeacher,
            //_searchCriteria.Add(SearchBy.CrsNoLocation,
            //_searchCriteria.Add(SearchBy.UnID,
            //_searchCriteria.Add(SearchBy.UnName,
            //_searchCriteria.Add(SearchBy.UnAllForCourse,
            //_searchCriteria.Add(SearchBy.UnNotAllocated,
            //_searchCriteria.Add(SearchBy.EnrlID,
            //_searchCriteria.Add(SearchBy.EnrlStudentID,
        }
    }
}


internal enum SearchBy
{
    StID,
    StFirstName,
    StLastName,
    StNotPaid,
    StFullTime,
    StPartTime,
    TchID,
    TchFirstName,
    TchLastName,
    TchLocation,
    CrsID,
    CrsName,
    CrsLocation,
    CrsTeacher,
    CrsNoLocation,
    UnID,
    UnName,
    UnAllForCourse,
    UnNotAllocated,
    EnrlID,
    EnrlStudentID
}