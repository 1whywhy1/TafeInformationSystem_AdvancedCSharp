using DLLDatabase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override int  Delete()
        {
            throw new Exception("You cannot delete Student record. Contact the System Admin");
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
        #endregion

        #region
        #endregion

    }
}
