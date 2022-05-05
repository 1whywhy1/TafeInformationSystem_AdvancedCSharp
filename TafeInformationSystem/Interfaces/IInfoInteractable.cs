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
        DataTable Search(SearchCriteria.UnitSearchBy unitSearchBy);
        void Add();
        int Delete();
        void Update();

    }
}
