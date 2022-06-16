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
        #region Fields
        private string _name;
        private int _id;
        DateTime _startDate;
        DateTime _endDate;

        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Constructors
        public ClsSemester() { }

        public ClsSemester(DateTime startDate, DateTime endDate) 
        { 
            StartDate = startDate;
            EndDate = endDate;
        }

        public ClsSemester(int id, string name)
        {
            SemesterID = id;
            SemesterName = name;
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
            set 
            { 
                _id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SemesterID"));
            }
        }

        public string SemesterName
        {
            get { return _name; }
            set 
            { 
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SemesterName"));
            }
        }
    
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StartDate"));
                }
            }
        }

        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EndDate"));
                }                   
            }
        }
        #endregion

            #region Functionality
        public int Add()
        {
            try
            {
                SqlDataReader dr = clsDatabase.ExecuteQuery($"SELECT COUNT(SemesterName) FROM Semester WHERE SemesterName like '{StartDate.ToString("yyyy")}%';");
                dr.Read();
                ClsMessenger.ShowMessage(dr[0].ToString());
            }
            catch (Exception ex)
            {
                ClsMessenger.ShowMessage(ex.Message);
            }
          
       
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
