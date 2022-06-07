using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TafeInformationSystem.Interfaces;
using TafeInformationSystem.Enums;
using DLLDatabase;
using System.Data;

namespace TafeInformationSystem.Classes
{
    class ClsCourse : IInfoInteractable
    {
        #region Fields
        private int _courseID;
        private string _name;
        private string _description;
        #endregion

        #region Constructors
        public ClsCourse() { }

        // Contructor to define Search criteria
        public ClsCourse(string value, SearchCriteria.CourseSearchBy unitSearchBy)
        {
            switch (unitSearchBy)
            {
                case SearchCriteria.CourseSearchBy.ID:
                    CourseID = value;
                    break;
                case SearchCriteria.CourseSearchBy.Name:
                    Name = value;
                    break;
                case SearchCriteria.CourseSearchBy.Location:
                    CourseID = value;
                    break;
                case SearchCriteria.CourseSearchBy.Teacher:
                    CourseID = value;
                    break;
                case SearchCriteria.CourseSearchBy.NoLocation:
                    // if courseID = 0 then search no location, it does not require ID
                    CourseID = "0";
                    break;
                default:
                    break;
            }
        }

        public ClsCourse(string name, string description)
        {
            Name = name;
            Description = description;          
        }

        public ClsCourse(string id, string name, string description)
        {
            CourseID = id;
            Name = name;
            Description = description;           
        }

        #endregion

        #region Properties
        public string CourseID
        {
            get
            {
                return _courseID.ToString();
            }

            set
            {
                // Add validation here
                _courseID = Convert.ToInt32(value);
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                // Add validation here
                _name = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                // Add validation here
                _description = value;
            }
        }


        #endregion

        public int Add()
        {
            try
            {             
                int id = clsDatabase.ExecInsertSP($"EXEC spInsert_course  @Name = '{Name}', @Description = '{Description}';");

                if (id > 0)
                {
                    CourseID = id.ToString();
                }
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Delete()
        {
            try
            {
                int rowsAffected = clsDatabase.ExecSP($"EXEC spDeleteCourseID_course @CourseID = {CourseID};");
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Search(SearchCriteria.CourseSearchBy courseSearchBy)
        {
            string querie = "";
            switch (courseSearchBy)
            {
                case SearchCriteria.CourseSearchBy.ID:
                    querie= $"EXEC spSelectCourseByID_course @CourseID = '{CourseID}';";
                    break;
                case SearchCriteria.CourseSearchBy.Name:
                    querie = $"EXEC spSelectCourseByName_course @Name = '{Name}';";
                    break;
                case SearchCriteria.CourseSearchBy.Location:
                    //dt = clsDatabase.ExecSPDataTable($"EXEC this shoould be All courses and locations and semesters for a teacher @CourseID = {CourseID};");
                    break;
                case SearchCriteria.CourseSearchBy.Teacher:
                    querie = $"EXEC spSelectAllPastCourseForTeacher_course @TeacherID = {CourseID};";
                    break;
                case SearchCriteria.CourseSearchBy.NoLocation:
                    querie = $"EXEC spSelectAllCourseNoCollege_course;";
                    break;
                case SearchCriteria.CourseSearchBy.All:
                    querie = $"SELECT CourseID, Name FROM Course ORDER BY CourseID;";
                    break;
                default:
                    return null;
            }
            DataTable dt = new DataTable();
            dt = clsDatabase.ExecSPDataTable(querie);

            if (dt != null && dt.Rows.Count > 0)
            {
                CourseID = dt.Rows[0]["CourseID"].ToString();
                Name = dt.Rows[0]["Name"].ToString();
                if(courseSearchBy != SearchCriteria.CourseSearchBy.Teacher)
                    Description = dt.Rows[0]["Description"].ToString();
            }
            return dt;
        }

        //public DataTable Search(ClsSearchBy searchBy)
        //{


        //}

        public void Update()
        {
            try
            {
                clsDatabase.ExecSP($"EXEC spUpdate_course  @CourseID = {CourseID}, @Name = '{Name}', @Description = '{Description}';");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
