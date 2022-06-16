using DLLDatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeInformationSystem.Classes
{
    class ClsCollege : INotifyPropertyChanged
    {
        #region Fields
        private ClsAddress _address;
        private string _collegeName;
        private int _collegeID;
        private string _phoneNumber;
        #endregion

        #region Constructors
        public ClsCollege() 
        {
            Address = new ClsAddress();
        }

        public ClsCollege(int id)
        {
            CollegeID = id.ToString();
            Address = new ClsAddress();
        }
        public ClsCollege(string collegeName)
        {
            CollegeName = collegeName;
            Address = new ClsAddress();
        }
        public ClsCollege(int id, string collegeName)
        {
            CollegeID = id.ToString();
            CollegeName = collegeName;
            Address = new ClsAddress();
        }

        public ClsCollege(string collegeName, string phoneNumber, string streetAddress, string postcode, string city, string state)
        {
            Address = new ClsAddress();
            CollegeName = collegeName;
            PhoneNumber = phoneNumber;
            StreetAddress = streetAddress;
            Postcode = postcode;
            City = city;
            State = state;
        }
        public ClsCollege(string collegeID, string collegeName, string phoneNumber, string streetAddress, string postcode, string city, string state)
        {
            Address = new ClsAddress();
            CollegeID = collegeID;
            CollegeName = collegeName;
            PhoneNumber = phoneNumber;
            StreetAddress = streetAddress;
            Postcode = postcode;
            City = city;
            State = state;
        }
        public ClsCollege(string collegeID, string collegeName, string phoneNumber, int addressID, string streetAddress, string postcode, string city, string state)
        {
            Address = new ClsAddress();
            CollegeID = collegeID;
            CollegeName = collegeName;
            PhoneNumber = phoneNumber;
            AddressID = addressID;
            StreetAddress = streetAddress;
            Postcode = postcode;
            City = city;
            State = state;
        }

        #endregion

        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties
        public ClsAddress Address 
        { 
            get { return _address; } 
            set 
            { 
                if (_address != value)
                {
                    _address = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Address"));
                } 
            } 
        }

        public string CollegeName 
        { 
            get { return _collegeName; } 
            set 
            { 
                if(_collegeName != value)
                {
                    _collegeName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CollegeName"));
                }
               
            } 
        }

        public string CollegeID 
        { 
            get { return _collegeID.ToString(); } 
            set 
            {
                int buf = Convert.ToInt32(value);
                if (_collegeID != buf)
                {
                    _collegeID = buf;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CollegeID"));
                }
            } 
        }

        public string PhoneNumber 
        { 
            get { return _phoneNumber; } 
            set 
            { 
                if (_phoneNumber != value)
                {
                    _phoneNumber = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PhoneNumber"));
                }
            } 
        }

        //public int CollegeAddressID
        //{
        //    get { return Address.ID; }
        //    set
        //    {
        //        if (Address.ID != value)
        //        {
        //            Address.ID = value;
        //            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CollegeAddressID"));
        //        }
        //    }
        //}

        public int AddressID
        {
            get { return Address.ID; }
            set
            {
                if (Address.ID != value)
                {
                    Address.ID = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AddressID"));
                }
            }
        }


        public String StreetAddress
        {
            get { return Address.StreetAddress;}
            set
            {
                if (Address.StreetAddress != value)
                {
                    Address.StreetAddress = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StreetAddress"));
                }
            }
        }

        public String Apt
        {
            get { return Address.Apt; }
            set
            {
                if (Address.Apt != value)
                {
                    Address.Apt = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Apt"));
                }
            }
        }  

        public string Postcode 
        { 
            get { return Address.Postcode; } 
            set 
            {
                if(Address.Postcode != value)
                {
                    Address.Postcode = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Postcode"));
                }              
            } 
        }

        public string City 
        { 
            get { return Address.City; } 
            set 
            {
                if (Address.City != value)
                {
                    Address.City = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("City"));
                }
            } 
        }

        public string State 
        { 
            get { return Address.State; }
            set
            {
                if (Address.State != value)
                {
                    Address.State = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("State"));
                }
            }
        }

        #endregion

        #region Add
        public int Add()
        {
            int result = clsDatabase.ExecInsertSP($"EXEC spInsert_college_address " +
                $"@StreetAddress = '{StreetAddress}', @Postcode = {Postcode}, " +
                $"@City = '{City}', @State = '{State}';");
            if(result > 0)
            {
                AddressID = result;
            }

            result = clsDatabase.ExecInsertSP($"EXEC spInsert_college " +
                $"@Name = '{CollegeName}', @Phone = '{PhoneNumber}', " +
                $"@AddressID = {AddressID};");
            if(result > 0)
            {
                CollegeID = result.ToString();
            }

            return result;
        }

        #endregion

        #region Update
        public int Update() 
        {
            int result = clsDatabase.ExecSP($"EXEC spUpdate_college_collegeAddress " +
                $"@CollegeID = {CollegeID}, @Name = '{CollegeName}', @Phone = '{PhoneNumber}', " +
                $"@StreetAddress = '{StreetAddress}', @Postcode = '{Postcode}', " +
                $"@City = '{City}', @State = '{State}';") ;
            return result;
        }

        public int Delete(string collegeID)
        {
            return clsDatabase.ExecInsertSP($"EXEC spDelete_college @CollegeID = {collegeID};");
        }

        #endregion

    }
}
