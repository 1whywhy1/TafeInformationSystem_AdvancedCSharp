using DLLDatabase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TafeInformationSystem.Classes;

namespace TafeInformationSystem.Enums
{
    class ClsCourseCollegeSemesterViewModel
    { 
        #region Fields

        private ObservableCollection<ClsSemester> _semestersInfo;
        private ObservableCollection<ClsCollege> _collegesInfo;
        private ObservableCollection<ClsCourse> _coursesInfo;
        private ObservableCollection<ClsCourseCollegeSemester> _ccsInfo;
        #endregion

        #region Properties
        public ObservableCollection<ClsSemester> SemestersInfo
        {
            get { return _semestersInfo; }
            set { _semestersInfo = value; }
        }

        public ObservableCollection <ClsCollege> CollegesInfo
        {
            get { return _collegesInfo; }
            set { _collegesInfo = value; }
        }
        public ObservableCollection<ClsCourse> CoursesInfo
        {
            get { return _coursesInfo; }
            set { _coursesInfo = value;}
        }

        public ObservableCollection<ClsCourseCollegeSemester> CourseCollegeSemesterInfo 
        { 
            get { return _ccsInfo; } 
            set { _ccsInfo = value; }        
        }


        #endregion

        #region Constructors
        public ClsCourseCollegeSemesterViewModel()
        {
            SetUp();
        }
        #endregion

        #region Add
        public virtual int Add(int semesterID, string semesterName, string collegeID, string collegeName, string courseID, string courseName)
        {
            ClsCourseCollegeSemester ccs = new ClsCourseCollegeSemester(Convert.ToInt32(semesterID), collegeID, courseID);
            ClsMessenger.ShowMessage($"{Convert.ToInt32(semesterID)}, {collegeID}, {courseID}");
            
            // Result is CCSID
            int result = ccs.Add();
             
            // if added successfully, add to Collection
            if(result > 0)
            {
                CourseCollegeSemesterInfo.Add(new ClsCourseCollegeSemester(result.ToString(), semesterID, semesterName,
                    collegeID, collegeName, courseID, courseName));                
            }

            // if result < 1 return error
            return result;
        }
        #endregion

        #region Delete
        public virtual int Delete(int semesterID, string collegeID, string courseID)
        {
            ClsCourseCollegeSemester css = new ClsCourseCollegeSemester(semesterID, collegeID, courseID);
            int result = css.Delete();

            if (result > 0)
            {
                // Search and remove deleted item from Collection
                foreach(ClsCourseCollegeSemester ccs in CourseCollegeSemesterInfo)
                {
                    if (ccs.CCSID == result.ToString())
                    {
                        CourseCollegeSemesterInfo.Remove(css);
                    }
                }
               
            }
            return result;
        }

        public virtual int Delete(ClsCourseCollegeSemester ccs)
        {           
            int result = ccs.Delete();

            if (result > 0)
            {
                // Search and remove deleted item from Collection                
                CourseCollegeSemesterInfo.Remove(ccs);
              
            }
            return result;
        }

        #endregion

        #region SetUp
        public virtual void SetUp()
        {
            SemestersInfo = new ObservableCollection<ClsSemester>();
            PopulateFromSQl(SemestersInfo, "SELECT SemesterID, SemesterName FROM Semester;");

            CollegesInfo = new ObservableCollection<ClsCollege>();
            PopulateFromSQl(CollegesInfo, "SELECT CollegeID, Name FROM College;");

            CoursesInfo = new ObservableCollection<ClsCourse>();
            PopulateFromSQl(CoursesInfo, "SELECT CourseID, Name FROM Course;");

            CourseCollegeSemesterInfo = new ObservableCollection<ClsCourseCollegeSemester>();
            PopulateFromSQl(CourseCollegeSemesterInfo, "EXEC spSelectAll_CourseCollegeSemesterWithNames;");
        }
        #endregion

        #region Populate Observable Collection From SQL
        public static void PopulateFromSQl(ObservableCollection<ClsSemester> collection, string querie)
        {
            using (IDataReader dr = clsDatabase.ExecuteQuery(querie))
            {

                var ordinals = new
                {
                    semesterID = dr.GetOrdinal("SemesterID"),
                    semesterName = dr.GetOrdinal("SemesterName")                    
                };

                while (dr.Read())
                {
                    collection.Add(new ClsSemester(dr.GetInt32(ordinals.semesterID),
                        dr.GetString(ordinals.semesterName)));
                }
            }
        }

        public static void PopulateFromSQl(ObservableCollection<ClsCollege> collection, string querie)
        {
            using (IDataReader dr = clsDatabase.ExecuteQuery(querie))
            {

                var ordinals = new
                {
                    collegeID = dr.GetOrdinal("CollegeID"),
                    collegeName = dr.GetOrdinal("Name")
                };

                while (dr.Read())
                {
                    collection.Add(new ClsCollege(dr.GetInt32(ordinals.collegeID),
                        dr.GetString(ordinals.collegeName)));
                }
            }
        }

        public static void PopulateFromSQl(ObservableCollection<ClsCourse> collection, string querie)
        {
            using (IDataReader dr = clsDatabase.ExecuteQuery(querie))
            {

                var ordinals = new
                {
                    courseID = dr.GetOrdinal("CourseID"),
                    courseName = dr.GetOrdinal("Name")
                };

                while (dr.Read())
                {
                    collection.Add(new ClsCourse(dr.GetInt32(ordinals.courseID),
                        dr.GetString(ordinals.courseName)));
                }
            }
        }

        public static void PopulateFromSQl(ObservableCollection<ClsCourseCollegeSemester> collection, string querie)
        {
            using (IDataReader dr = clsDatabase.ExecuteQuery(querie))
            {

                var ordinals = new
                {
                    ccsID = dr.GetOrdinal("CCSID"),
                    semesterID = dr.GetOrdinal("SemesterID"),
                    semesterName = dr.GetOrdinal("SemesterName"),
                    collegeID = dr.GetOrdinal("CollegeID"),
                    collegeName = dr.GetOrdinal("CollegeName"),
                    courseID = dr.GetOrdinal("CourseID"),
                    courseName = dr.GetOrdinal("CourseName")
                };

                while (dr.Read())
                {
                    // you need to match types from SQL to this constructor, then populate actual CCS table and test it
                    // then add filters on this collection based on selections in other list view, if there is no match
                    // offer to add combination
                    collection.Add(new ClsCourseCollegeSemester(dr.GetInt32(ordinals.ccsID).ToString(),
                        dr.GetInt32(ordinals.semesterID), dr.GetString(ordinals.semesterName),
                        dr.GetInt32(ordinals.collegeID).ToString(), dr.GetString(ordinals.collegeName),
                        dr.GetInt32(ordinals.courseID).ToString(), dr.GetString(ordinals.courseName)));
                }
            }
        }

        #endregion
    }
}
