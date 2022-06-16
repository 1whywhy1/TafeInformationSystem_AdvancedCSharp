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
        private ObservableCollection<string> _courseId;
        private ObservableCollection<ClsUnit> _unitCourseInfo;
        private ObservableCollection<ClsUnit> _originalCourseUnit;
        private ObservableCollection<ClsUnit> _unitInfo;
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


        public ObservableCollection<string> CourseId
        {
            get { return _courseId; }
            set
            {
                _courseId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CourseID"));
            }
        }

        public ObservableCollection<ClsUnit> OriginalCourseUnit
        { get; set; }

        public ObservableCollection<ClsUnit> UnitCourseInfo
        {
            get { return _unitCourseInfo; }
            set
            {
                _unitCourseInfo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UnitCourseInfo"));
            }
        }
        public ObservableCollection<ClsUnit> UnitInfo
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
            PopulateFromSQl(CourseInfo, "SELECT CourseID, Name FROM Course ORDER BY CourseID;");


            UnitInfo = new ObservableCollection<ClsUnit>();
            PopulateFromSQl(UnitInfo, "SELECT UnitID, Name FROM Unit ORDER BY UnitID;");

        }

        #endregion

        #region Populate Collection from SQL table
        public static void PopulateFromSQl(ObservableCollection<ClsUnit> collection, string querie)
        {
            using (IDataReader dr = clsDatabase.ExecuteQuery(querie))
            {

                var ordinals = new
                {
                    unitID = dr.GetOrdinal("UnitID"),
                    unitName = dr.GetOrdinal("Name")
                };

                while (dr.Read())
                {
                    //UnitInfo.Add(dr.GetInt32(ordinals.unitID).ToString()
                    //    + " " + dr.GetString(ordinals.unitName));

                    collection.Add(new ClsUnit(dr.GetInt32(ordinals.unitID).ToString(), dr.GetString(ordinals.unitName)));
                }
            }
        }
        public static void PopulateFromSQl(ObservableCollection<string> collection, string querie)
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
                    collection.Add(dr.GetInt32(ordinals.courseID).ToString()
                        + " - " + dr.GetString(ordinals.courseName));
                }
            }
        }

        #endregion

        #region RetrieveUnitsForCourseSQL
        public void RetrieveUnitsForCourse(string courseID)
        {
            UnitCourseInfo = new ObservableCollection<ClsUnit>();            
            PopulateFromSQl(UnitCourseInfo, $"SELECT UnitID, Name FROM Unit WHERE UnitID in (SELECT UnitID FROM UnitCourse WHERE CourseID = {courseID});");
            
        }
        #endregion

        #region Updage
        public int UpdateUnitCourse(string courseID)
        {
            string insertQuerie = "";
            string deleteQuerie = "";

            // Compare what was deleted from OriginalCourseUnit and write appropriate querie
            IEnumerable<ClsUnit> units = OriginalCourseUnit.Except(UnitCourseInfo);
            foreach (ClsUnit unit in units)
            {
                deleteQuerie += $"DELETE FROM UnitCourse WHERE CourseID = {courseID} AND UnitID ={unit.UnitID};";
            }


            // Compare what was added to CourseUnit and write appropriate querie
            units = UnitCourseInfo.Except(OriginalCourseUnit);
            foreach (ClsUnit unit in units)
            {
                insertQuerie += $"INSERT INTO UnitCourse VALUES ({courseID}, {unit.UnitID});";
            }

            // Run queries to update
            if (insertQuerie != "" || deleteQuerie != "")
            {               
                clsDatabase.ExecuteNonQuery(deleteQuerie + insertQuerie);
            }

            RetrieveUnitsForCourse(courseID);

            return 1;
        }
        #endregion

        public void DiscardEdit()
        {
            UnitCourseInfo = new ObservableCollection<ClsUnit>(OriginalCourseUnit);
        }

        public void PrepareEdit()
        {
            OriginalCourseUnit = new ObservableCollection<ClsUnit>(UnitCourseInfo);
        }
        #region
        #endregion

    }
}
