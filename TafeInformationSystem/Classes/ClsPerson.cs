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
    class ClsPerson : IInfoInteractable
    {
        #region Fields
        private int _id;
        private string _fname;
        private string _lname;
        private DateTime _dob;
        private ClsAddress _address;
        private string _email;
        private string _hphone;
        private string _mphone;
        private int _gender;

        #endregion

        #region Constructors
        public ClsPerson() { }

        public ClsPerson(string fname, string lname, DateTime dob,
                        ClsAddress address, string email, 
                        string hphone, string mphone, int gender)
        {
            _fname = fname;
            _lname = lname;
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
        public string Fname { get { return _fname; } set { _fname = value; } }
        public string Lname { get { return _lname; } set { _lname = value; } }
        public DateTime Dob { get { return _dob; } set { _dob = value;} }

        public ClsAddress Address { get { return _address; } set { _address = value;} }

        public string Email { get { return _email; } set { _email = value; } }

        public string Hphone { get { return _hphone; } set { _hphone = value; } }

        public string Mphone { get { return _mphone; } set { _mphone = value; } }

        public int Gender { get { return _gender; } set { _gender = value; } }


        #endregion

        #region Functions
        public virtual int Add()
        {
            throw new NotImplementedException();
        }

        public virtual int Delete()
        {
            throw new NotImplementedException();
        }

        public virtual DataTable Search(SearchCriteria.UnitSearchBy unitSearchBy)
        {
            throw new NotImplementedException();
        }

        public virtual void Update()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
