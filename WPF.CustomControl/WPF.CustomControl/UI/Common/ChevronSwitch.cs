using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows;

namespace WPF.CustomControl.UI.Common
{
    public class ChevronSwitch : ToggleButton
    {
        static ChevronSwitch()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChevronSwitch), new FrameworkPropertyMetadata(typeof(ChevronSwitch)));
        }
    }
}
