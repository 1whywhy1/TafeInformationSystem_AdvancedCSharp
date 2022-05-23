using DLLDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeInformationSystem.Classes
{
    internal class ClsTeacher : ClsPerson
    {
        public override int Add()
        {
            try
            {
                int addressID = Address.Add();
                int id = clsDatabase.ExecInsertSP($"EXEC spInsert_Teacher  @FirstName = '{Fname}', " +
                    $"@LastName = '{Lname}', @DOB = '{Dob.ToString()}', @Email = '{Email}', " +
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
    }
}
