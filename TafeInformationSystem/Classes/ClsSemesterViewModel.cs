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

namespace TafeInformationSystem.Classes
{
    class ClsSemesterViewModel : INotifyPropertyChanged
    {
        #region Fields
        private ObservableCollection<ClsSemester> _semestersInfo;
        private ClsSemester _semester;

        #endregion

        #region Constructors
        public ClsSemesterViewModel() 
        {
            RefreshCollection();
        }

        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

      

        #region Properties
        public ObservableCollection<ClsSemester> SemestersInfo
        {
            get { return _semestersInfo; }
            set 
            {                 
                _semestersInfo = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SemesterInfo"));
                RaisePropertyChanged("SemesterInfo");
              
            }
        }

        public ClsSemester Semester
        {
            get { return _semester; }
            set { _semester = value;}
        }

        #endregion

        #region RaisePropertyChanged
        // Modify PropertyChanged for performance 
        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
            
        #region Add
        public int Add(DateTime startDate, DateTime endDate)
        {

            SqlDataReader dr = clsDatabase.ExecuteQuery($"SELECT COUNT(SemesterName) FROM Semester WHERE SemesterName like '{startDate.ToString("yyyy")}%';");
            dr.Read();

            int nameint = (int)dr[0];
            string semesterName = "";

            if (nameint >= 0 &&  nameint < 2)
            {
                semesterName = startDate.ToString("yyyy") + "-" + (nameint + 1).ToString();
            }
            else if (nameint >= 2)
            {
                ClsMessenger.ShowMessage("Maximum number of Semesters in selected year has been reached");
            }

            int result = clsDatabase.ExecInsertSP($"EXEC spInsert_semester @SemesterName = '{semesterName}', " +
                $"@StartDate = '{startDate.ToString("yyyy-MM-dd")}', " +
                $"@EndDate = '{endDate.ToString("yyyy-MM-dd")}';");          
            RefreshCollection();
            //ClsMessenger.ShowMessage(dr[0].ToString());

            return result;
        }
        #endregion

        #region Update
        public void Update(string semesterName, DateTime startDate, DateTime endDate)
        {
            try
            {
                clsDatabase.ExecuteNonQuery($"EXEC spUpdate_semester @SemesterName = '{semesterName}', " +
                $"@StartDate = '{startDate.ToString("yyyy-MM-dd")}', " +
                $"@EndDate = '{endDate.ToString("yyyy-MM-dd")}';");
            }
            catch (Exception ex)
            {
                ClsMessenger.ShowMessage(ex.Message);
            }  

            RefreshCollection();
        }
        #endregion

        #region Refresh Collection
        // refreshes collection
        public void RefreshCollection()
        {
            SemestersInfo = new ObservableCollection<ClsSemester>();
            PopulateFromSQl(SemestersInfo, "SELECT * FROM Semester;");
        }
        #endregion

        #region Populate Observable Collection From SQL
        public static void PopulateFromSQl(ObservableCollection<ClsSemester> collection, string querie)
        {
            using (IDataReader dr = clsDatabase.ExecuteQuery(querie))
            {

                var ordinals = new
                {
                    semesterID = dr.GetOrdinal("SemesterID"),
                    semesterName = dr.GetOrdinal("SemesterName"),
                    startDate = dr.GetOrdinal("StartDate"),
                    endDate = dr.GetOrdinal("EndDate"),

                };

                while (dr.Read())
                {
                    collection.Add(new ClsSemester(dr.GetInt32(ordinals.semesterID), 
                        dr.GetString(ordinals.semesterName), dr.GetDateTime(ordinals.startDate), 
                        dr.GetDateTime(ordinals.endDate)));
                }
            }
        }
        #endregion


    }
}
