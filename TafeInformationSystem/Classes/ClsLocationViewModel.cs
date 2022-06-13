using DLLDatabase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TafeInformationSystem.Classes
{
    class ClsLocationViewModel
    {
        #region Fields
        private ObservableCollection<ClsCollege> _collegesInfo;
        #endregion

        #region Properties
        public ObservableCollection<ClsCollege> CollegesInfo
        {
            get { return _collegesInfo; }
            set { _collegesInfo = value; }
        }
        #endregion

        #region Constructors
        public ClsLocationViewModel()
        {
            CollegesInfo = new ObservableCollection<ClsCollege>();
            PopulateFromSQl(CollegesInfo, "EXEC spSelect_all_college_collegeAddress;");
        }
        #endregion

        #region Command
        private ICommand mUpdater;
        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater();
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }

        private class Updater : ICommand
        {
            #region ICommand Members  

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {

            }

            #endregion


        }

        #endregion

        #region Add 
        public void Add(string collegeName,
            string phoneNumber, string streetAddress, string postcode,
            string city, string state)
        {
            ClsCollege col = new ClsCollege(collegeName,
                phoneNumber, streetAddress, postcode, city, state);
            if (col.Add() > 0)
            {
                CollegesInfo.Add(col);
            }

            CollegesInfo.Add(col);
        }

        #endregion

        #region Update 
        public void Update(string collegeID, string collegeName, 
            string phoneNumber, string streetAddress, string postcode, 
            string city, string state)
        {
            ClsCollege col = new ClsCollege(collegeID, collegeName, 
                phoneNumber, streetAddress, postcode, city, state);
            if (col.Update() > 0)
            {
                foreach (ClsCollege college in CollegesInfo)
                {
                    if (college.CollegeID == collegeID)
                    {
                        college.CollegeName = collegeName;
                        college.PhoneNumber = phoneNumber;
                        college.StreetAddress = streetAddress;
                        college.Postcode = postcode;
                        college.City = city;
                        college.State = state;
                    }
                }

                ClsMessenger.ShowMessage($"College {collegeName} information has been updated!");
            }        
           
        }

        #endregion

        #region Delete
        public int Delete (string collegeID)
        {
            ClsCollege col = new ClsCollege(Convert.ToInt32(collegeID));
            return col.Delete(collegeID);
        }

        #endregion

        #region Populate Observable Collection From SQL
        public static void PopulateFromSQl(ObservableCollection<ClsCollege> collection, string querie)
        {
            using (IDataReader dr = clsDatabase.ExecuteQuery(querie))
            {

                var ordinals = new
                {
                    collegeID = dr.GetOrdinal("CollegeID"),
                    collegeName = dr.GetOrdinal("Name"),
                    phoneNumber = dr.GetOrdinal("Phone"),
                    addressID = dr.GetOrdinal("CollegeAddressID"),
                    streetAddress = dr.GetOrdinal("StreetAddress"),
                    postcode = dr.GetOrdinal("Postcode"),
                    city = dr.GetOrdinal("City"),
                    state = dr.GetOrdinal("State"),

                };

                while (dr.Read())
                {
                    collection.Add(new ClsCollege(dr.GetInt32(ordinals.collegeID).ToString(),
                        dr.GetString(ordinals.collegeName), dr.GetString(ordinals.phoneNumber),
                        dr.GetInt32(ordinals.addressID), dr.GetString(ordinals.streetAddress),
                        dr.GetInt32(ordinals.postcode).ToString(), dr.GetString(ordinals.city),
                        dr.GetString(ordinals.state)));
                }
            }
        }

        #endregion
    }
}
