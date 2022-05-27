using DLLDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeInformationSystem.Classes
{
    internal class ClsTeacher : ClsPerson
    {
        #region Constructor
        public ClsTeacher() { }
        public ClsTeacher(string id)
        {
            ID = id;
            RetrieveUser();
        }
        #endregion
        #region DB funcitonality
        public override int Add()
        {
            try
            {
                int addressID = Address.Add();
                int id = clsDatabase.ExecInsertSP($"EXEC spInsert_Teacher  @FirstName = '{FName}', " +
                    $"@LastName = '{LName}', @DOB = '{Dob.ToString()}', @Email = '{Email}', " +
                    $"@MobilePhone = '{Mphone}', @HomePhone = '{Hphone}', @GenderID = '{Gender}', @AddressID = {Address};");

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

        public override int Delete()
        {
            throw new Exception("You cannot delete a teacher, contact your System Admin");            
        }

        public override void Update()
        {
            try
            {
                clsDatabase.ExecSP($"EXEC spUpdate_course  @TeacherID = {ID},  @FirstName = '{FName}', " +
                    $"@LastName = '{LName}', @DOB = '{Dob.ToString()}', @Email = '{Email}', " +
                    $"@MobilePhone = '{Mphone}', @HomePhone = '{Hphone}', @GenderID = '{Gender}', @AddressID = {Address};");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Search()
        {
            return 1;
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
    }
}
