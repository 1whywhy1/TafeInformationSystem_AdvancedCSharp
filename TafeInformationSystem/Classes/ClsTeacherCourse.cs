using DLLDatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeInformationSystem.Classes
{
    class ClsTeacherCourse : INotifyPropertyChanged
    {
        #region Fields
        private ClsTeacher _teacher;
        private ClsCourseCollegeSemester _courseCollegeSemester;

        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Constructors
        public ClsTeacherCourse()
        {
            SetUp();
        }

        public ClsTeacherCourse(string teacherID, string ccsID)
        {
            SetUp();
            TeacherID = teacherID;
            CourseCollegeSemester.CCSID = ccsID;
        }

        public ClsTeacherCourse(string teacherID, string fname, string lname, string ccsID, int semesterID, string semesterName,
          string collegeID, string collegeName, string courseID, string courseName)
        {
            SetUp();
            TeacherID = teacherID;
            Teacher.FName = fname;
            Teacher.LName = lname;
            CCSID = ccsID;
            SemesterID = semesterID;
            SemesterName = semesterName;
            CourseCollegeSemester.CollegeID = collegeID;
            CourseCollegeSemester.CollegeName = collegeName;
            CourseCollegeSemester.CourseID = courseID;
            CourseCollegeSemester.CourseName = courseName;
        }

        #endregion

        #region Properties
        public string TeacherID
        {
            get { return _teacher.ID; }
            set
            {
                _teacher.ID = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TeacherID"));
            }
        }
        public string TeacherFName
        {
            get { return _teacher.FName; }
            set
            {
                _teacher.FName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TeacherFName"));
            }
        }
        public string TeacherLName
        {
            get { return _teacher.LName; }
            set
            {
                _teacher.LName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TeacherLName"));
            }
        }

        public string CCSID
        {
            get { return CourseCollegeSemester.CCSID; }
            set
            {
                if (CourseCollegeSemester.CCSID != value)
                {
                    CourseCollegeSemester.CCSID = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CCSID"));

                }
            }
        }
        public int SemesterID
        {
            get { return CourseCollegeSemester.SemesterID; }
            set
            {
                if (CourseCollegeSemester.SemesterID != value)
                {
                    CourseCollegeSemester.SemesterID = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SemesterID"));
                }
            }
        }

        public string SemesterName
        {
            get { return CourseCollegeSemester.SemesterName; }
            set
            {
                if (CourseCollegeSemester.SemesterName != value)
                {
                    CourseCollegeSemester.SemesterName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SemesterName"));
                }
            }
        }

        public string CollegeID
        {
            get { return CourseCollegeSemester.CollegeID; }
            set
            {
                if (CourseCollegeSemester.CollegeID != value)
                {
                    CourseCollegeSemester.CollegeID = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CollegeID"));
                }
            }
        }
        public string CollegeName
        {
            get { return CourseCollegeSemester.CollegeName; }
            set
            {
                if (CourseCollegeSemester.CollegeName != value)
                {
                    CourseCollegeSemester.CollegeName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CollegeName"));
                }
            }
        }
        public string CourseID
        {
            get { return CourseCollegeSemester.CourseID; }
            set
            {
                if (CourseCollegeSemester.CourseID != value)
                {
                    CourseCollegeSemester.CourseID = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CourseID"));
                }
            }
        }
        public string CourseName
        {
            get { return CourseCollegeSemester.CourseName; }
            set
            {
                if (CourseCollegeSemester.CourseName != value)
                {
                    CourseCollegeSemester.CourseName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CourseName"));
                }
            }
        }


        public ClsTeacher Teacher
        {
            get { return _teacher; }
            set
            {
                if(_teacher != value)
                {
                    _teacher = value;
                }
            }
        }

        public ClsCourseCollegeSemester CourseCollegeSemester
        {
            get { return _courseCollegeSemester; }
            set 
            { 
                if (_courseCollegeSemester != value)
                {
                    _courseCollegeSemester = value;
                }
            }
        }        

        #endregion

        #region Add
        public int Add()
        {
            try
            {
                clsDatabase.ExecuteNonQuery($"EXEC spInsert_TeacherCourse " +
                     $"@TeacherID = {TeacherID}, @CCSID = {CCSID};");
            }  
            catch  (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return 1;
        }

        #endregion

        #region Delete
        public int Delete()
        {
            clsDatabase.ExecuteNonQuery($"EXEC spDelete_TeacherCourse " +
                 $"@TeacherID = {TeacherID}, @CCSID = {CCSID};");
            return 1;
        }

        #endregion
        public static int RetrieveCCSID(string semesterID, string collegeID, string courseID)
        {           
            int result = clsDatabase.ExecInsertSP($"EXEC spSelectCCSIDbyIndex_courseCollegeSemester " +
                $"@CourseID = {courseID}, @CollegeID = {collegeID}, @SemesterID = {semesterID};");         
            return result;
        }
        #region


        #endregion

        #region SetUp
        public void SetUp()
        {
            _teacher = new ClsTeacher();
            _courseCollegeSemester = new ClsCourseCollegeSemester();
        }
        #endregion

    }
}
