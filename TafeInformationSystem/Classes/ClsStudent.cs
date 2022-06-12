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
        #region Constructors
        public ClsStudent() { }
        public ClsStudent(string id)
        {
            ID = id;
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

        public ClsStudent(string fname, string lname, DateTime dob,
                        ClsAddress address, string email,
                        string hphone, string mphone, int gender)
            : base(fname, lname, dob, address, email,hphone,mphone, gender)
        { }
        #endregion

        // public ClsStudent(string fname, string lname, DateTime dob, string email, string mphone, string hphone,)
               
        #region Functionality
        public override int Add()
        {
            try
            {
                // Push Student Address to SQL
                int addressID = clsDatabase.ExecInsertSP($"EXEC spInsert_studentAddress " +
                $"@StreetAddress = '{Address.StreetAddress}', " +
                $"@AptNumber = '{Address.Apt}', @Postcode = '{Address.Postcode}', " +
                $"@City = '{Address.City}', @State = '{Address.State}';");

                if(addressID> 0)
                {
                    Address.ID = addressID;
                }

                // Push Student Info to SQL
                int id = clsDatabase.ExecInsertSP($"EXEC spInsert_student @FirstName = '{FName}', " +
                  $"@LastName = '{LName}', @DOB = '{Dob.ToString("yyyy-MM-dd")}', @Email = '{Email}', " +
                  $"@MobilePhone = '{Mphone}', @HomePhone = '{Hphone}', @GenderID = {Gender.ToString()}, " +
                  $"@AddressID = {Address.ID.ToString()};");

                if (id > 0)
                {
                    ID = id.ToString();
                }

                // Insert Student Login Info into DB
                AddLoginInfo();

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
                //int addressID = Address.Add();
                clsDatabase.ExecSP($"EXEC spUpdate_student_studentAddress  @StudentID = {ID},  @FirstName = '{FName}', " +
                   $"@LastName = '{LName}', @DOB = '{Dob.ToString("yyyy-MM-dd")}', @Email = '{Email}', " +
                   $"@MobilePhone = '{Mphone}', @HomePhone = '{Hphone}', @GenderID = '{Gender}', " +
                   $"@StreetAddress = '{Address.StreetAddress}', @AptNumber = '{Address.Apt}', " +
                   $"@Postcode = '{Address.Postcode}', @City = '{Address.City}', @State = '{Address.State}';");

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

        #region Login
        public override bool Login(string login, string password)
        {
            return clsDatabase.Login(UserType.student, login, password);
        }
        #endregion

        public override void UpdatePassword(string oldPassword, string newPassword)
        {
            if (clsDatabase.Login(UserType.student, ID, oldPassword) &&
                oldPassword != "" && newPassword != "")
            {
                ClsMessenger.ShowMessage($"SET Password = {ClsUtils.HashPassword(newPassword)} ");
                clsDatabase.ExecuteNonQuery($"UPDATE StudentLogin " +
                    $"SET Password = '{ClsUtils.HashPassword(newPassword)}' WHERE StudentID = {ID};");
            }
        }

        public override void AddLoginInfo()
        {
            clsDatabase.ExecuteNonQuery($"INSERT INTO StudentLogin(StudentID) VALUES ({ID});");
        }
    }
}
