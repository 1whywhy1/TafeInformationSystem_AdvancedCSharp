using DLLDatabase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeInformationSystem.Classes
{
    class ClsSemester 
    {
        enum Semester
        {
            S1,
            S2,
            DEFAULT
        }

        #region Fields
        private Semester _semester;
        private string _name;
        private int _id;
        DateTime _startDate;
        DateTime _endDate;

        private ObservableCollection<ClsSemester> semesterInfo;
        #endregion                

        #region Constructors
        public ClsSemester() { }

        public ClsSemester(DateTime startDate, DateTime endDate) 
        { 
            StartDate = startDate;
            EndDate = endDate;
        }

        public ClsSemester(int id, string name, DateTime startDate, DateTime endDate)
        {
            SemesterID = id;
            SemesterName = name;
            StartDate = startDate;
            EndDate = endDate;
        }

        #endregion

        #region Properties
        public int SemesterID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string SemesterName
        {
            get { return _name; }
            set { _name = value; }
        }
    
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                if (_startDate != value)
                    _startDate = value;
            }
        }
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                if (_endDate != value)
                    _endDate = value;
            }
        }
        #endregion

            #region Functionality
        public int Add()
        {
            SqlDataReader dr = clsDatabase.ExecuteQuery($"SELECT COUNT(SemesterName) FROM Semester WHERE SemesterName like '{StartDate.ToString("yyyy")}%';");
            dr.Read();
            ClsMessenger.ShowMessage(dr[0].ToString());
            //int id = clsDatabase.ExecInsertSP($"INSERT INTO Semester(SemesterName, StartDate, EndDate)" +
            //    $"VALUES ({Name}, {StartDate}, {EndDate}");
            //if (id > 0)
            //{
            //    ID = id;
            //}

            return 1;
        }

        #endregion

        #region
        #endregion

        #region
        #endregion

        #region
        #endregion

    }
}
