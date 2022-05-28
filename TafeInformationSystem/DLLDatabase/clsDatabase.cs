using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using TafeInformationSystem.Classes;
using TafeInformationSystem.Enums;

namespace DLLDatabase
{
    public class clsDatabase
    {
        #region Variables
        public static SqlConnection objConnection;
        public static SqlCommand objCommand;

        #endregion

        #region ConnectToDB
        // Connecting to SQL DB on a local server.
        public static SqlConnection ConnectToDatabase()
        {
            //String machineName = Environment.MachineName;
            String serverName = Environment.MachineName + "\\THEGREATTEST";
            string connectionString = "server=" + serverName + ";database = TafeInformationSystem_IvanKaryakin;trusted_Connection=yes";
            try
            {
                objConnection = new SqlConnection(connectionString);//connecting to the database server
                objConnection.Open();//opening the connection
                return objConnection;
            }
            catch (SqlException ex)
            {               
                return null;
            }
        }

        #endregion

        #region Execute Non Querie Prepared Statement
        public static void ExecutePreparedStatementInsert(string tableNameAndColumns)
        {
            try
            {
                ConnectToDatabase();
                string query = "INSERT INTO @TableAndColumns VALUES(@Name, @Price, @Date)";

                objCommand = new SqlCommand(query, objConnection);

                objCommand.Parameters.AddWithValue("@TableAndColumns", tableNameAndColumns);
                objCommand.Parameters.AddWithValue("@Price", "$20");
                objCommand.Parameters.AddWithValue("@Date", "25 May 2017");
            }
            catch (SqlException ex)
            { 

            }
            finally
            {
                objConnection.Close();
            }

        }
        #endregion

        #region Insert

        // Checks Login and Password against stored in DB
        public static bool Login(UserType userType, string userID, string password)
        {
            ConnectToDatabase();
            string querie = null;
            switch (userType)
            {
                case UserType.student:
                    querie = "SELECT StudentID FROM StudentLogin WHERE StudentID = @userID AND Password = @password";

                    break;
                case UserType.teacher:
                    querie = "SELECT TeacherID FROM TeacherLogin WHERE TeacherID = @userID AND Password = @password";

                    break;
                default:
                    break;
            }
            objCommand = new SqlCommand(querie, objConnection);
            objCommand.Parameters.AddWithValue("@userID", userID);
            objCommand.Parameters.AddWithValue("@password", ClsUtils.HashPassword(password));

            var result = objCommand.ExecuteScalar();
            
            return (result != null) ? true : false;
        }

        //public static SetPassword()

        //redundant
        public static int InsertUnit(string name, string description, string pointValue, string price)
        {
            try
            {
                ConnectToDatabase();
                string query = $"EXEC spInsert_unit  @Name = '{name}', @Description = '{description}', @PointValue = {pointValue}, @Price = {price};";

                objCommand = new SqlCommand(query, objConnection);
            
                int id = (int)objCommand.ExecuteScalar();
                return id;
            }
            catch (SqlException ex)
            {
                AssessSqlError(ex);
                return -1;
            }
            finally
            {
                objConnection.Close();
            }
        }

        public static int ExecSP (string query)
        {
            try
            {
                ConnectToDatabase();

                objCommand = new SqlCommand(query, objConnection);
                return objCommand.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                AssessSqlError(ex);
                return ex.Number;
            }
            finally
            {
                objConnection.Close();
            }
        }

        public static DataTable ExecSPDataTable(string query)
        {
            try
            {
                ConnectToDatabase();

                using SqlDataAdapter objDataAdapter = new SqlDataAdapter(query, objConnection);//using sqldataadapter constructor
                DataTable objDataTable = new DataTable();//default constructor of datatable class
                objDataAdapter.Fill(objDataTable);
                return objDataTable;

            }
            catch (SqlException ex)
            {
                AssessSqlError(ex);
                return null;
            }
            finally
            {
                objConnection.Close();              
            }
        }
        public static DataSet ExecSPDataSet(string query)
        {
            try
            {
                ConnectToDatabase();


                SqlDataAdapter objDataAdapter = new SqlDataAdapter(query, objConnection);//using sqldataadapter constructor
                DataSet objDataSet = new DataSet();//default constructor of datatable class
                objDataAdapter.Fill(objDataSet);
                return objDataSet;

            }
            catch (SqlException ex)
            {
                AssessSqlError(ex);
                return null;
            }
            finally
            {
                objConnection.Close();
            }
        }


        public static int ExecInsertSP(string query)
        {
            try
            {
                ConnectToDatabase();
                
                objCommand = new SqlCommand(query, objConnection);

                int id = (int)objCommand.ExecuteScalar();
                return id;
            }
            catch (SqlException ex)
            {
                AssessSqlError(ex);
                return -1;
            }
            finally
            {
                objConnection.Close();
            }
        }

        #endregion

        #region ExecuteQuery
        public static SqlDataReader ExecuteQuery(string strSql)
        {
            try
            {
                ConnectToDatabase();//calling method within a method
                objCommand = new SqlCommand(strSql, objConnection);
                SqlDataReader objDataReader = objCommand.ExecuteReader();
                if (objDataReader.HasRows)
                {
                    return objDataReader;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException ex)
            {
                return null;
            }
        }

        #endregion

        #region ExecuteNonQuery
        public static void ExecuteNonQuery(string strSql)
        {
            try
            {
                ConnectToDatabase();
                objCommand = new SqlCommand(strSql, objConnection);
                objCommand.ExecuteNonQuery();
                
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    throw new ArgumentNullException("This record already exists");

                }
                else
                if (ex.Number == 547)
                {
                    if (ex.Message.Contains("teacher_course_fk"))
                    {
                        throw new ArgumentNullException("The teacher does not exist");
                    }
                    else
                    if (ex.Message.Contains("course_teacher_fk"))
                    {
                        throw new ArgumentNullException("The course does not exist");
                    }
                }
                else
                {
                    throw new ArgumentNullException(ex.Message);
                }
            }

        }

        #endregion

        #region CreateDataTable
        public static DataTable CreateDataTable(string tablename)
        {
            try
            {
                ConnectToDatabase();
                string strSql = "select * from " + tablename;
                SqlDataAdapter objDataAdapter = new SqlDataAdapter(strSql, objConnection);//using sqldataadapter constructor
                DataTable objDataTable = new DataTable();//default constructor of datatable class
                objDataAdapter.Fill(objDataTable);
                return objDataTable;
            }
            catch (SqlException ex)
            {
                return null;
            }
        }

        #endregion

        #region Error handling
        public static void AssessSqlError(SqlException ex)
        {
            if (ex.Number == 2627)
            {
                throw new ArgumentNullException("This course teacher already exists");

            }
            else
               if (ex.Number == 547)
            {
                if (ex.Message.Contains("teacher_course_fk"))
                {
                    throw new ArgumentNullException("The teacher does not exist");
                }
                else
                if (ex.Message.Contains("course_teacher_fk"))
                {
                    throw new ArgumentNullException("The course does not exist");
                }
                if (ex.Message.Contains("UnitCourse"))
                {
                    throw new ArgumentNullException("Delete reference between Unit and Course first!");
                }

            }
            else
            {
                throw new ArgumentNullException(ex.Message);
            }
        } 

        #endregion
    }
}

