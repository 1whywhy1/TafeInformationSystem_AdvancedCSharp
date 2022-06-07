using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TafeInformationSystem.Classes
{
    public class ClsMessenger
    {
        private static ClsMessenger _instance;

        public static ClsMessenger getInstance()
        { 
            if(_instance == null)
            {
                _instance = new ClsMessenger();
            }
            return _instance;
        }

        public static void ShowMessage(string messageTxt)
        {
            MessageBox.Show(messageTxt);
        }
    }
}
