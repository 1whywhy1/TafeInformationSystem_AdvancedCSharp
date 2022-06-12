using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TafeInformationSystem.Enums;
using TafeInformationSystem.Interfaces;
using DLLDatabase;

namespace TafeInformationSystem.Classes
{
    public abstract class ClsPerson : IInfoInteractable
    {
        #region Fields
        private int _id;
        private string _fName;
        private string _lName;
        private DateTime _dob;
        private ClsAddress _address;
        private string _email;
        private string _hphone;
        private string _mphone;
        private int _gender;

        #endregion

        #region Constructors
        public ClsPerson() { }

        public ClsPerson(int id)
        {
            _id = id;
        }

        public ClsPerson(string fname, string lname, DateTime dob,
                        ClsAddress address, string email, 
                        string hphone, string mphone, int gender)
        {
            _fName = fname;
            _lName = lname;
            _dob = dob;
            _address = address;
            _email = email;
            _hphone = hphone;
            _mphone = mphone;
            _gender = gender;
        }

        #endregion

        #region Properties
        public string ID
        { 
            get { return _id.ToString(); } 

            set 
            {
                // Add validation here
                _id = Convert.ToInt32(value);
            }
        }

        public string FName { get { return _fName; } set { _fName = value; } }
        public string LName { get { return _lName; } set { _lName = value; } }
        public DateTime Dob { get { return _dob; } set { _dob = value;} }

        public ClsAddress Address { get { return _address; } set { _address = value;} }

        public string Email { get { return _email; } set { _email = value; } }

        public string Hphone { get { return _hphone; } set { _hphone = value; } }

        public string Mphone { get { return _mphone; } set { _mphone = value; } }

        public int Gender { get { return _gender; } set { _gender = value; } }


        #endregion

        #region Functions
        public abstract int Add();
        public abstract int Delete();
        public abstract void Update();

        public abstract void RetrieveUser();

        public abstract bool Login(string login, string password);

        public abstract void UpdatePassword(string oldPassword, string newPassword);

        public abstract void AddLoginInfo();
        #endregion
    }
}
