using DLLDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TafeInformationSystem.Enums;

namespace TafeInformationSystem.Classes
{
    class ClsStudent : ClsPerson
    {
        #region Fields
        #endregion

        #region Constructors
        public ClsStudent() { }
        public ClsStudent(string id)
        {
            ID = id;
            RetrieveUser();
        }

        public ClsStudent(string value, SearchCriteria.StudentSearchBy searchBy)
        {
            switch (searchBy)
            {
                case SearchCriteria.StudentSearchBy.ID:
                    ID = value;
                    break;
                case SearchCriteria.StudentSearchBy.FirstName:
                    FName = value;
                    break;
                case SearchCriteria.StudentSearchBy.LastName:
                    LName = value;
                    break;
                case SearchCriteria.StudentSearchBy.NotPaid:
                    // logic for finding students that have not paid the fees fully
                    break;              
                default:
                    break;
            }
        }
        #endregion

        #region Properties
        #endregion

        #region Functionality
        public override int Add()
        {
            try
            {
                int addressID = Address.Add();
                int id = clsDatabase.ExecInsertSP($"EXEC spInsert_student @FirstName = '{FName}', " +
                  $"@LastName = '{LName}', @DOB = '{Dob.ToString()}', @Email = '{Email}', " +
                  $"@MobilePhone = '{Mphone}', @HomePhone = '{Hphone}', @GenderID = '{Gender}', " +
                  $"@AddressID = {Address};");

                if (id > 0)
                {
                    ID = id.ToString();
                }

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override int  Delete()
        {
            throw new Exception("You cannot delete Student record. " +
                "Contact the System Admin");
        }

        public override void RetrieveUser()
        {
            try
            {
                if (ID is not null)
                {
                    DataTable dt = clsDatabase.ExecSPDataTable($"EXEC spSelectAllByID_student_address @StudentID = {ID};");
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        ID = dt.Rows[0]["StudentID"].ToString();
                        FName = dt.Rows[0]["FirstName"].ToString();
                        LName = dt.Rows[0]["LastName"].ToString();
                        Dob = (DateTime)dt.Rows[0]["DOB"];
                        Address = new ClsAddress(Convert.ToInt32(dt.Rows[0]["StudentAddressID"]),
                            dt.Rows[0]["StreetAddress"].ToString(),
                            dt.Rows[0]["AptNumber"].ToString(),
                            dt.Rows[0]["Postcode"].ToString(),
                            dt.Rows[0]["City"].ToString(),
                            dt.Rows[0]["State"].ToString());
                        Email = dt.Rows[0]["Email"].ToString();
                        Hphone = dt.Rows[0]["HomePhone"].ToString();
                        Mphone = dt.Rows[0]["MobilePhone"].ToString();
                        Gender = Convert.ToInt32(dt.Rows[0]["GenderID"]);
                    }
                }
            }
            catch (Exception ex)
            {
                // error handling here
                throw new Exception(ex.Message);
            }

        }

        public override void Update()
        {
            try
            {
                int addressID = Address.Add();
                int id = clsDatabase.ExecInsertSP($"EXEC spUpdate_student @StudentID = '{ID}', @FirstName = '{FName}', " +
                  $"@LastName = '{LName}', @DOB = '{Dob.ToString()}', @Email = '{Email}', " +
                  $"@MobilePhone = '{Mphone}', @HomePhone = '{Hphone}', @GenderID = '{Gender}', @AddressID = {Address};");

                if (id > 0)
                {
                    ID = id.ToString();
                }

               // return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable Search(SearchCriteria.StudentSearchBy searchBy)
        {
            string querie = "";
            switch (searchBy)
            {
                case SearchCriteria.StudentSearchBy.ID:
                    querie = $"EXEC spSelectAllByID_student_address @StudentID = {ID}";
                    break;
                case SearchCriteria.StudentSearchBy.FirstName:
                    querie = $"EXEC spSelectAllByFName_student_address @FirstName = {FName};";
                    break;
                case SearchCriteria.StudentSearchBy.LastName:
                    querie = $"EXEC spSelectAllByFName_student_address @LastName = {LName};";
                    break;
                case SearchCriteria.StudentSearchBy.NotPaid:
                    break;
                case SearchCriteria.StudentSearchBy.FullTime:
                    break;
                case SearchCriteria.StudentSearchBy.PartTime:
                    break;
                default:
                    return null;
            }
           
            DataTable dt = new DataTable();
            dt = clsDatabase.ExecSPDataTable(querie);

            if (dt != null && dt.Rows.Count > 0)
            {
                ID = dt.Rows[0]["StudentID"].ToString();
                FName = dt.Rows[0]["FirstName"].ToString();
                LName = dt.Rows[0]["LastName"].ToString();
                Dob = (DateTime)dt.Rows[0]["DOB"];
                Email = dt.Rows[0]["Email"].ToString();
                Hphone = dt.Rows[0]["HomePhone"].ToString();
                Mphone = dt.Rows[0]["MobilePhone"].ToString();
                Gender = (int)dt.Rows[0]["GenderID"];
                Address = new ClsAddress(dt.Rows[0]["StreetAddress"].ToString(),
                    dt.Rows[0]["AptNumber"].ToString(), dt.Rows[0]["Postcode"].ToString(),
                    dt.Rows[0]["City"].ToString(), dt.Rows[0]["State"].ToString());
            }
            return dt;
        }
        #endregion

        #region
        #endregion

    }
}
