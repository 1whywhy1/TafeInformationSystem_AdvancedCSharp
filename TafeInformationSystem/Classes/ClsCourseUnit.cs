using DLLDatabase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TafeInformationSystem.Enums;

namespace TafeInformationSystem.Classes
{
    class ClsCourseUnit : INotifyPropertyChanged
    {
        #region Fields
        private ObservableCollection<string> _courseInfo;
        private ObservableCollection<int> _courseId;
        private ObservableCollection<string> _unitInfo;
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        public ObservableCollection<string> CourseInfo
        {
            get { return _courseInfo; }
            set
            {
                _courseInfo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CourseInfo"));
            }
        }


        public ObservableCollection<int> CourseId
        {
            get { return _courseId; }
            set
            {
                _courseId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CourseID"));
            }
        }
        public ObservableCollection<string> UnitInfo
        {
            get { return _unitInfo; }
            set
            {
                _unitInfo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UnitInfo"));
            }
        }
        #endregion

        #region Constructors
        public ClsCourseUnit()
        {
            CourseInfo = new ObservableCollection<string>();

            // Populate CourseInfo collection
            using (IDataReader dr = clsDatabase.ExecuteQuery("SELECT CourseID, Name FROM Course ORDER BY CourseID;"))
            {
                var ordinals = new
                {
                    courseID = dr.GetOrdinal("CourseID"),
                    courseName = dr.GetOrdinal("Name")
                };

                while (dr.Read())
                {
                    CourseInfo.Add(dr.GetInt32(ordinals.courseID).ToString()
                        + " - " + dr.GetString(ordinals.courseName));
//CourseId.Add(dr.GetInt32(ordinals.courseID));
                }
            }

            // Populate CourseInfo collection
            using (IDataReader dr = clsDatabase.ExecuteQuery("SELECT UnitID, Name FROM Unit ORDER BY UnitID;"))
            {
                var ordinals = new
                {
                    unitID = dr.GetOrdinal("UnitID"),
                    unitName = dr.GetOrdinal("Name")
                };

                //while (dr.Read())
                //{
                //    UnitInfo.Add(dr.GetInt32(ordinals.unitID).ToString()
                //        + " " + dr.GetString(ordinals.unitName));                   
                //}
            }
        }

        #endregion

        public static DataTable RetrieveUnits(SearchCriteria.UnitSearchBy searchBy)
        {
            string querie = null;
            switch (searchBy)
            {
                case SearchCriteria.UnitSearchBy.ID:
                    break;
                case SearchCriteria.UnitSearchBy.Name:
                    break;
                case SearchCriteria.UnitSearchBy.AllForCourse:
                    querie = "SELECT UnitID, Name FROM Unit WHERE UnitID in (SELECT UnitID FROM UnitCourse WHERE CourseID = ";
                    break;
                case SearchCriteria.UnitSearchBy.NotAllocated:
                    break;
                case SearchCriteria.UnitSearchBy.All:
                    querie = "SELECT UnitID, Name FROM Unit ORDER BY UnitID;";
                    break;
                default:
                    break;
            }

            return clsDatabase.ExecSPDataTable(querie);            
        }

        public static DataTable RefreshUnitsForCourse(string courseID)
        {
            return clsDatabase.ExecSPDataTable($"SELECT UnitID, Name FROM Unit WHERE UnitID in (SELECT UnitID FROM UnitCourse WHERE CourseID = {courseID});");
        }


        #region
        #endregion

    }
}
