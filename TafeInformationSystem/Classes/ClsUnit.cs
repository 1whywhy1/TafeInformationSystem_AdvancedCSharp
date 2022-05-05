using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TafeInformationSystem.Interfaces;
using TafeInformationSystem.Enums;
using DLLDatabase;
using System.Data;

namespace TafeInformationSystem.Classes
{
    class ClsUnit : IInfoInteractable
    {
        #region Fields
        private int _unitID;
        private string _name;
        private string _description;
        private int _pointValue;
        private double _price;
        #endregion

        #region Constructors
        public ClsUnit() { }

        // Contructor to define Search criteria
        public ClsUnit(string value, SearchCriteria.UnitSearchBy unitSearchBy)
        {
            switch (unitSearchBy)
            {
                case SearchCriteria.UnitSearchBy.ID:
                    UnitID = value;
                    break;
                case SearchCriteria.UnitSearchBy.Name:
                    Name = value;
                    break;
                case SearchCriteria.UnitSearchBy.AllForCourse:
                    UnitID = value;
                    break;
                case SearchCriteria.UnitSearchBy.NotAllocated:

                    break;
                default:
                    break;
            }
        }

        public ClsUnit(string name, string description, string pointValue, string price)
        {
            Name = name;
            Description = description;
            PointValue = pointValue;
            Price = price;
        }

        public ClsUnit(string id, string name, string description, string pointValue, string price)
        {
            UnitID = id;
            Name = name;
            Description = description;
            PointValue = pointValue;
            Price = price;
        }


        #endregion

        #region Properties
        public string UnitID
        {
            get
            {
                return _unitID.ToString();
            }

            set
            {
                // Add validation here
                _unitID = Convert.ToInt32(value);
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                // Add validation here
                _name = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                // Add validation here
                _description = value;
            }
        }

        public string PointValue
        {
            get
            {
                return _pointValue.ToString();
            }

            set
            {
                // Add validation here
                _pointValue = Convert.ToInt32(value);
            }
        }

        public string Price
        {
            get
            {
                return _price.ToString();
            }

            set
            {
                // Add validation here
                _price = Convert.ToDouble(value);
            }
        }

        #endregion

        public void Add()
        {
            try
            {
                //int id = clsDatabase.InsertUnit(Name, Description, PointValue.ToString(), Price.ToString());
                int id = clsDatabase.ExecInsertSP($"EXEC spInsert_unit  @Name = '{Name}', @Description = '{Description}', @PointValue = {PointValue}, @Price = {Price};");

                if (id > 0)
                {
                    UnitID = id.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Delete()
        {
            try
            {
                int rowsAffected = clsDatabase.ExecSP($"EXEC spDeleteUnitID_unit @UnitID = {UnitID};");
                return rowsAffected;
            } catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable Search(SearchCriteria.UnitSearchBy unitSearchBy)
        {
            DataTable dt = new DataTable();
            switch (unitSearchBy)
            {
                case SearchCriteria.UnitSearchBy.ID:
                    dt = clsDatabase.ExecSPDataTable($"EXEC spSelectID_unit @UnitID = {UnitID};");
                    break;
                case SearchCriteria.UnitSearchBy.Name:
                    dt = clsDatabase.ExecSPDataTable($"EXEC spSelectName_unit @Name = {Name};");
                    break;
                case SearchCriteria.UnitSearchBy.AllForCourse:
                    dt = clsDatabase.ExecSPDataTable($"EXEC spSelectAllForCourse_unit @CourseID = {UnitID};");
                    break;
                case SearchCriteria.UnitSearchBy.NotAllocated:
                    dt = clsDatabase.ExecSPDataTable($"EXEC spSelectAllNotAllowcated_unit;");
                    break;
                default:
                    return null;
                    break;
            }


            if (dt != null && dt.Rows.Count > 0)
            {
                UnitID = dt.Rows[0]["UnitID"].ToString();
                Name = dt.Rows[0]["Name"].ToString();
                Description = dt.Rows[0]["Description"].ToString();
                PointValue = dt.Rows[0]["PointValue"].ToString();
                Price = dt.Rows[0]["Price"].ToString();

            }
            return dt;
        }

        ////not sure if I get the datatable from the interaction
        //public void Search(SearchCriteria.UnitSearchBy searchCriteria)
        //{            
        //    try
        //    {
        //        DataTable dt;

        //        switch (searchCriteria)
        //        {
        //            case SearchCriteria.UnitSearchBy.ID:
        //                dt = clsDatabase.ExecSPDataTable($"EXEC spSelectID_unit @UnitID = {UnitID};");
        //                if (dt != null)
        //                {
        //                    UnitID = dt.Rows[0]["UnitID"].ToString();
        //                    Name = dt.Rows[0]["Name"].ToString();
        //                    Description = dt.Rows[0]["Description"].ToString();
        //                    PointValue = dt.Rows[0]["PointValue"].ToString();
        //                    Price = dt.Rows[0]["Price"].ToString();
                         
        //                }

        //                break;
        //            case SearchCriteria.UnitSearchBy.Name:
        //                dt = clsDatabase.ExecSPDataTable($"EXEC spSelectName_unit @Name = {Name};");
        //                if (dt != null)
        //                {
        //                    UnitID = dt.Rows[0]["UnitID"].ToString();
        //                    Name = dt.Rows[0]["Name"].ToString();
        //                    Description = dt.Rows[0]["Description"].ToString();
        //                    PointValue = dt.Rows[0]["PointValue"].ToString();
        //                    Price = dt.Rows[0]["Price"].ToString();
        //                }

        //                break;
        //            case SearchCriteria.UnitSearchBy.AllForCourse:

        //                break;
        //            case SearchCriteria.UnitSearchBy.NotAllocated:
        //                break;
        //            default:
        //                break;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}


        public void Update()
        {
            try
            {
                clsDatabase.ExecSP($"EXEC spUpdate_unit  @UnitID = {UnitID}, @Name = '{Name}', @Description = '{Description}', @PointValue = {PointValue}, @Price = {Price};");
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
