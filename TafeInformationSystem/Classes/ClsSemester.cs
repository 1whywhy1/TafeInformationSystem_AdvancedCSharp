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
    class ClsSemester : INotifyPropertyChanged
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

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors
        public ClsSemester() { }

        public ClsSemester(DateTime startDate, DateTime endDate) 
        { 

        }


        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public DateTime StartDate { get => _startDate; set => _startDate = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }
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
