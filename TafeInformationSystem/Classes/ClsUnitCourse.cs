using DLLDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeInformationSystem.Classes
{
    class ClsUnitCourse
    {
        #region Fields
        private int _unit1, _unit2, _unit3;
        private int _courseID;

        #endregion

        #region Fields
        public string CourseID
        { get { return _courseID.ToString(); } set { _courseID = Convert.ToInt32(value); } }
        public string Unit1
        { get { return _unit1.ToString(); } set { _unit1 = Convert.ToInt32(value); } }
        public string Unit2
        { get { return _unit2.ToString(); } set { _unit2 = Convert.ToInt32(value); } }
        public string Unit3
        { get { return _unit3.ToString(); } set { _unit3 = Convert.ToInt32(value); } }

        #endregion

        #region Constructors

        public ClsUnitCourse() { }
        public ClsUnitCourse(string unit1, string unit2, string unit3, string courseID)
        {
            CourseID = courseID;
            Unit1 = unit1;
            Unit2 = unit2;
            Unit3 = unit3;
        }


        #endregion

        #region Assign Units

        public int AssignUnits()
        {
            //clsDatabase
            return 1;
        }
        #endregion


        #region Deassign Units
        public int DeassignUnits()
        {

            try
            {
                int rowsAffected = clsDatabase.ExecSP($"EXEC spDelete_unitCourse @CourseID = {CourseID};");
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
