using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TafeInformationSystem.Classes
{
    class ClsUtils
    {
        public static void SetActiveControls(Control[] controls, Boolean isEnabled)
        {
            foreach(Control ctrl in controls)
            {
                ctrl.IsEnabled = isEnabled;
            }
        }

        public static void SetControlsVisible(Control[] controls)
        {
            foreach (Control ctrl in controls)
            {
                ctrl.Visibility = System.Windows.Visibility.Visible;
            }
        }

        public static void SetControlsHidden(Control[] controls)
        {
            foreach (Control ctrl in controls)
            {
                ctrl.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }
}
