using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TafeInformationSystem.Enums;
using TafeInformationSystem.Interfaces;

namespace TafeInformationSystem.Classes
{
    public class ClsAddress : IInfoInteractable
    {
        #region Fields
        private int _id;
        private string _streetAddress;
        private string _apt;
        private string _postcode;
        private string _city;
        private string _state;
        #endregion

        #region Constructors
        public ClsAddress() { }

        public ClsAddress(int id, string streedAddress, 
                        string apt, string postcode, 
                        string city, string state) 
        {
            _id = id;
            _streetAddress = streedAddress;
            _apt = apt;
            _postcode = postcode;
            _city = city;
            _state = state;
        }

        public ClsAddress(string streedAddress,
                       string apt, string postcode,
                       string city, string state)
        {
            _streetAddress = streedAddress;
            _apt = apt;
            _postcode = postcode;
            _city = city;
            _state = state;
        }

        #endregion

        #region Properties
        public int ID { get { return _id; } set { _id = value; } }

        public string StreetAddress { get { return _streetAddress; } set { _streetAddress = value; } }

        public string Apt { get { return _apt; } set { _apt = value; } }

        public string Postcode { get { return _postcode; } set { _postcode = value; } }

        public string City { get { return _city; } set { _city = value; } }

        public string State { get { return _state; } set { _state = value; } }


        #endregion

        #region Functionality
        public int Add()
        {
            throw new NotImplementedException();
        }

        public int Delete()
        {
            throw new NotImplementedException();
        }

        public DataTable Search(SearchCriteria.UnitSearchBy unitSearchBy)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
