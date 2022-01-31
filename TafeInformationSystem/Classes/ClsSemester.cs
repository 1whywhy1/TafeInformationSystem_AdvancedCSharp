using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TafeInformationSystem.Classes
{
    class ClsSemester
    {
        #region Fields
        DateTime _startDateTime;
        DateTime _endDateTime;
        #endregion


        #region Constructors
        public ClsSemester() { }

        public ClsSemester(DateTime startDateTime, DateTime endDateTime) { }




        #endregion

        #region Properties
        public DateTime StartDateTime { get => _startDateTime; set => _startDateTime = value; }
        public DateTime EndDateTime { get => _endDateTime; set => _endDateTime = value; }
        #endregion
    }
}
