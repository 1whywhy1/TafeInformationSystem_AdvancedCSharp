using DLLDatabase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TafeInformationSystem.Enums;

namespace TafeInformationSystem.Classes
{
    class ClsTeacherCourseViewModel : ClsCourseCollegeSemesterViewModel
    {
        #region Fields
        private ObservableCollection<ClsTeacher> _teachersInfo;
        private ObservableCollection<ClsTeacherCourse> _teacherCourseInfo;
        #endregion

        #region Constructors
        public ClsTeacherCourseViewModel()
        {
            SetUp();
        }

        #endregion

        #region Properties
        public ObservableCollection<ClsTeacher> TeachersInfo
        {
            get { return _teachersInfo; }
            set { _teachersInfo = value; }
        }

        public ObservableCollection<ClsTeacherCourse> TeacherCourseInfo
        {
            get { return _teacherCourseInfo; }
            set { _teacherCourseInfo = value; }
        }

        #endregion

        #region Add
        public int Add(string teacherID, string semesterID, string collegeID, string courseID)
        {

            try
            {
                int ccsID = ClsTeacherCourse.RetrieveCCSID(semesterID, collegeID, courseID);
                ClsTeacherCourse tc = new ClsTeacherCourse(teacherID, ccsID.ToString());
                return tc.Add();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }  
        }



        #endregion

        #region Delete
        public int Delete (string teacherID, string ccsID)
        {
            ClsTeacherCourse tc = new ClsTeacherCourse(teacherID, ccsID);
            int result = tc.Delete();
            foreach (ClsTeacherCourse tcrs in TeacherCourseInfo)
            {
                if(tcrs.TeacherID == tc.TeacherID && tcrs.CCSID == tc.CCSID)
                {
                    TeacherCourseInfo.Remove(tcrs);
                }
            }

            return result;
        }

        #endregion

        #region SetUp
        public override void SetUp()
        {
            base.SetUp();
            TeachersInfo = new ObservableCollection<ClsTeacher>();
            PopulateFromSQl(TeachersInfo, "SELECT TeacherID, FirstName, LastName FROM Teacher;");

            TeacherCourseInfo = new ObservableCollection<ClsTeacherCourse>();
            PopulateFromSQl(TeacherCourseInfo, "EXEC spSelectAllInfo_TeacherCourse;");
        }

        #endregion

        #region Populate Observable Collection From SQL
        public static void PopulateFromSQl(ObservableCollection<ClsTeacher> collection, string querie)
        {
            using (IDataReader dr = clsDatabase.ExecuteQuery(querie))
            {

                var ordinals = new
                {
                    teacherID = dr.GetOrdinal("TeacherID"),
                    teacherName = dr.GetOrdinal("FirstName"),
                    teacherSurname = dr.GetOrdinal("LastName")
                };

                while (dr.Read())
                {
                    collection.Add(new ClsTeacher(dr.GetInt32(ordinals.teacherID).ToString(),
                        dr.GetString(ordinals.teacherName), dr.GetString(ordinals.teacherSurname)));
                }
            }
        }

        public static void PopulateFromSQl(ObservableCollection<ClsTeacherCourse> collection, string querie)
        {
            using (IDataReader dr = clsDatabase.ExecuteQuery(querie))
            {

                var ordinals = new
                {
                    teacherID = dr.GetOrdinal("TeacherID"),
                    teacherName = dr.GetOrdinal("FirstName"),
                    teacherSurname = dr.GetOrdinal("LastName"),
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
                    collection.Add(new ClsTeacherCourse(dr.GetInt32(ordinals.teacherID).ToString(),
                        dr.GetString(ordinals.teacherName), dr.GetString(ordinals.teacherSurname),
                        dr.GetInt32(ordinals.ccsID).ToString(),dr.GetInt32(ordinals.semesterID), 
                        dr.GetString(ordinals.semesterName), dr.GetInt32(ordinals.collegeID).ToString(), 
                        dr.GetString(ordinals.collegeName), dr.GetInt32(ordinals.courseID).ToString(), 
                        dr.GetString(ordinals.courseName)));
                }
            }
        }
        #endregion


        #region
        #endregion

    }
}
