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

        public void Add()
        {
            try
            {             
                int id = clsDatabase.ExecInsertSP($"EXEC spInsert_course  @Name = '{Name}', @Description = '{Description}';");

                if (id > 0)
                {
                    CourseID = id.ToString();
                }
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
                int rowsAffected = clsDatabase.ExecSP($"EXEC spDeleteCourseID_course @UnitID = {CourseID};");
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Search(SearchCriteria.CourseSearchBy courseSearchBy)
        {
            DataTable dt = new DataTable();
            switch (courseSearchBy)
            {
                case SearchCriteria.CourseSearchBy.ID:
                    dt = clsDatabase.ExecSPDataTable($"EXEC spSelectCourseByID_course @CourseID = {CourseID};");
                    break;
                case SearchCriteria.CourseSearchBy.Name:
                    dt = clsDatabase.ExecSPDataTable($"EXEC spSelectCourseByName_course @Name = {Name};");
                    break;
                case SearchCriteria.CourseSearchBy.Location:
                    dt = clsDatabase.ExecSPDataTable($"EXEC spSelectAllForCourse_unit @CourseID = {CourseID};");
                    break;
                case SearchCriteria.CourseSearchBy.Teacher:   
                    dt = clsDatabase.ExecSPDataTable($"EXEC spSelectAllPastCourseForTeacher_course @TeacherID = {CourseID};");
                    break;
                case SearchCriteria.CourseSearchBy.NoLocation:
                    dt = clsDatabase.ExecSPDataTable($"EXEC spSelectAllCourseNoCollege_course;");
                    break;
                default:
                    return null;
                    break;
            }


            if (dt != null && dt.Rows.Count > 0)
            {
                CourseID = dt.Rows[0]["CourseID"].ToString();
                Name = dt.Rows[0]["Name"].ToString();
                if(courseSearchBy != SearchCriteria.CourseSearchBy.Teacher)
                    Description = dt.Rows[0]["Description"].ToString();
            }
            return dt;
        }

        public DataTable Search(SearchCriteria.UnitSearchBy unitSearchBy)
        {
            throw new NotImplementedException();
        }

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

        #endregion


    }
}
