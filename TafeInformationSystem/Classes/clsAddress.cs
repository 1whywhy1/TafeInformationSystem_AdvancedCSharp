using DLLDatabase;
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
            int result = clsDatabase.ExecInsertSP($"EXEC spInsert_studentAddress " +
                $"@StreetAddress = '{StreetAddress}', " +
                $"@AptNumber = '{Apt}', @Postcode = '{Postcode}', " +
                $"@City = '{City}', @State = '{State}';");
            if (result > 0)
            {
                ID = result;
            }
            return result;
        }

        public int Delete()
        {
            ClsMessenger.ShowMessage("You cannot delete address. If required, consult with your system administrator.");
            return 1;
        }

     
        public void Update()
        {
            // Update is done through ClsStudent
            throw new NotImplementedException();
        }

        #endregion
    }
}
