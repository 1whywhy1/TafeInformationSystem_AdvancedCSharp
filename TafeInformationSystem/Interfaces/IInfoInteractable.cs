using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TafeInformationSystem.Enums;

namespace TafeInformationSystem.Interfaces
{
    interface IInfoInteractable
    {
        // might need to rewrite stuff so SearchBy enums are derriving from SearchCriteria and then make a generic SearchCriteria by ref and check inside which one it is.

        DataTable Search(SearchCriteria.UnitSearchBy unitSearchBy);

        // MAKE THIS INT and return the ID through this
        int Add();
        int Delete();

        // check how to check how many rows have been updated by the method
        void Update();

    }
}
