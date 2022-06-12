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
    internal class ClsTeacher : ClsPerson
    {
        #region Constructors
        public ClsTeacher() { }
        public ClsTeacher(string id)
        {
            ID = id;
        }

        public ClsTeacher(string value, SearchCriteria.TeacherSearchBy searchBy) 
        {
            switch (searchBy)
            {
                case SearchCriteria.TeacherSearchBy.ID:
                    ID = value;
                    break;
                case SearchCriteria.TeacherSearchBy.FirstName:
                    FName = value;
                    break;
                case SearchCriteria.TeacherSearchBy.LastName:
                    LName = value;
                    break;
                case SearchCriteria.TeacherSearchBy.Location:
                    FName = value;
                    break;
                default:
                    break;
            }
        }

        public ClsTeacher(string fname, string lname, DateTime dob,
                  ClsAddress address, string email,
                  string hphone, string mphone, int gender)
                : base(fname, lname, dob, address, email, hphone, mphone, gender)
        { }

        #endregion

        #region DB funcitonality
        public override int Add()
        {
            try
            {
                // Push Teacher Address to SQL
                int addressID = clsDatabase.ExecInsertSP($"EXEC spInsert_TeacherAddress " +
                $"@StreetAddress = '{Address.StreetAddress}', " +
                $"@AptNumber = '{Address.Apt}', @Postcode = '{Address.Postcode}', " +
                $"@City = '{Address.City}', @State = '{Address.State}';");

                if (addressID > 0)
                {
                    Address.ID = addressID;
                }

                // Push Teacher Info to SQL
                int id = clsDatabase.ExecInsertSP($"EXEC spInsert_Teacher @FirstName = '{FName}', " +
                  $"@LastName = '{LName}', @DOB = '{Dob.ToString("yyyy-MM-dd")}', @Email = '{Email}', " +
                  $"@MobilePhone = '{Mphone}', @HomePhone = '{Hphone}', @GenderID = {Gender.ToString()}, " +
                  $"@AddressID = {Address.ID.ToString()};");

                if (id > 0)
                {
                    ID = id.ToString();
                }

                // Insert Teacher Login Info into DB
                AddLoginInfo();

                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override int Delete()
        {
            throw new Exception("You cannot delete a teacher, " +
                "contact your System Admin");            
        }

        public override void Update()
        {
            try
            {
                clsDatabase.ExecSP($"EXEC spUpdate_Teacher_TeacherAddress  @TeacherID = {ID},  @FirstName = '{FName}', " +
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

        public DataTable Search(SearchCriteria.TeacherSearchBy searchBy)
        {
            string querie = "";
            switch (searchBy)
            {
                case SearchCriteria.TeacherSearchBy.ID:
                    querie = $"EXEC spSelectAllByID_Teacher_address @TeacherID = '{ID}';";
                    break;
                case SearchCriteria.TeacherSearchBy.FirstName:
                    querie = $"EXEC spSelectAllByFName_Teacher_address @FirstName = '{FName}';";
                    break;
                case SearchCriteria.TeacherSearchBy.LastName:
                  //  querie = $"
                    break;
                case SearchCriteria.TeacherSearchBy.Location:
                    querie = $"EXEC spSelectAllTeachersByCollege_teacher_college @CollegeName = '{FName}';";
                    break;
                default:
                    return null;
            }

            DataTable dt = new DataTable();
            dt = clsDatabase.ExecSPDataTable(querie);

            if (dt != null && dt.Rows.Count > 0)
            {
                ID = dt.Rows[0]["TeacherID"].ToString();
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

        public override void RetrieveUser()
        {
            try
            {
                if (ID is not null)
                {
                    DataTable dt = clsDatabase.ExecSPDataTable($"EXEC spSelectAllByID_Teacher_address @TeacherID = {ID};");
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        ID = dt.Rows[0]["TeacherID"].ToString();
                        FName = dt.Rows[0]["FirstName"].ToString();
                        LName = dt.Rows[0]["LastName"].ToString();
                        Dob = (DateTime)dt.Rows[0]["DOB"];
                        Address = new ClsAddress(Convert.ToInt32(dt.Rows[0]["TeacherAddressID"]),
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

        #endregion

        #region Login
        public override bool Login(string login, string password)
        {
            return clsDatabase.Login(UserType.teacher, login, password);
        }
        #endregion

        #region Update Password
        public override void UpdatePassword(string oldPassword, string newPassword)
        {
            if (clsDatabase.Login(UserType.teacher, ID, oldPassword) && 
                oldPassword != "" && newPassword != "")
            {
                clsDatabase.ExecuteNonQuery($"UPDATE TeacherLogin " +
                $"SET Password = '{ClsUtils.HashPassword(newPassword)}' WHERE TeacherID = {ID};");
            }
        }
        #endregion
        public override void AddLoginInfo()
        {
            clsDatabase.ExecuteNonQuery($"INSERT INTO TeacherLogin(TeacherID) VALUES  ({ID});");
        }
    }
}
