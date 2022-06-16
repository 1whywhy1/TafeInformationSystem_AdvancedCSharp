using DLLDatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeInformationSystem.Classes
{
    class ClsCourseCollegeSemester : INotifyPropertyChanged
    {
        #region Fields
        private string _ccsID;
        private ClsSemester _semester;
        private ClsCollege _college;
        private ClsCourse _course;

        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors

        public ClsCourseCollegeSemester() 
        {
            SetUp();
        }

        public ClsCourseCollegeSemester(int semesterID, string collegeID, string courseID)
        {
            SetUp();
            SemesterID = semesterID;
            CollegeID = collegeID;
            CourseID = courseID;
        }

        public ClsCourseCollegeSemester(int semesterID, string semesterName, 
            string collegeID, string collegeName, string courseID, string courseName)
        {
            SetUp();
            SemesterID = semesterID;
            SemesterName = semesterName;
            CollegeID = collegeID;
            CollegeName = collegeName;
            CourseID = courseID;
            CourseName = courseName;
        }
        public ClsCourseCollegeSemester(string ccsID, int semesterID, string semesterName,
          string collegeID, string collegeName, string courseID, string courseName)
        {
            SetUp();
            CCSID = ccsID;
            SemesterID = semesterID;
            SemesterName = semesterName;
            CollegeID = collegeID;
            CollegeName = collegeName;
            CourseID = courseID;
            CourseName = courseName;
        }

        #endregion

        #region Properties
        public string CCSID
        {
            get { return _ccsID; }
            set
            {
                if(_ccsID != value)
                {
                    _ccsID = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CCSID"));

                }
            }
        }
        public int SemesterID
        {
            get { return _semester.SemesterID; }
            set
            {
                if (_semester.SemesterID != value)
                {
                    _semester.SemesterID = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SemesterID"));
                }
            }
        }

        public string SemesterName
        {
            get { return _semester.SemesterName; }
            set
            {
                if (_semester.SemesterName != value)
                {
                    _semester.SemesterName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SemesterName"));
                }
            }
        }
     
        public string CollegeID
        {
            get { return _college.CollegeID; }
            set
            {
                if (_college.CollegeID != value)
                {
                    _college.CollegeID = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CollegeID"));
                }
            }
        }
        public string CollegeName
        {
            get { return _college.CollegeName; }
            set
            {
                if (_college.CollegeName != value)
                {
                    _college.CollegeName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CollegeName"));
                }
            }
        }
        public string CourseID
        {
            get { return _course.CourseID; }
            set
            {
                if (_course.CourseID != value)
                {
                    _course.CourseID = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CourseID"));
                }
            }
        }
        public string CourseName
        {
            get { return _course.Name; }
            set
            {
                if (_course.Name != value)
                {
                    _course.Name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CourseName"));
                }
            }
        }

        #endregion

        #region SetUp
        private void SetUp()
        {
            _college = new ClsCollege();
            _semester = new ClsSemester();
            _course = new ClsCourse();
        }
        #endregion

        #region Add
        public int Add()
        {
            int result = clsDatabase.ExecInsertSP($"EXEC spInsert_CourseCollegeSemester " +
                $"@CourseID = {CourseID}, @CollegeID = {CollegeID}, @SemesterID = {SemesterID};");
            if(result > 0)
            {
                CCSID = result.ToString();
            }

            return result;
        }
        #endregion

        #region Delete
        public int Delete()
        {
            return clsDatabase.ExecInsertSP($"EXEC spDelete_CourseCollegeSemesterByIndex " +
                $"@CourseID = {CourseID}, @CollegeID = {CollegeID}, @SemesterID = {SemesterID};");
        }
        #endregion


        public static int RetrieveCCSID(int semesterID, string collegeID, string courseID)
        {
            return clsDatabase.ExecSP($"SELECT CCSID FROM CourseCollegeCourse " +
                $"WHERE SemesterID = {semesterID}, CollegeID = {collegeID}, CourseID = {courseID};");
        }

        #region
        #endregion

    }
}
