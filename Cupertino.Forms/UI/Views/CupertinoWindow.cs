﻿using Cupertino.Forms.Local.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cupertino.Forms.UI.Views
{
    public class CupertinoWindow : UserControl
    {
        static CupertinoWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CupertinoWindow), new FrameworkPropertyMetadata(typeof(CupertinoWindow)));
        }

        public CupertinoWindow()
        {
            DataContext = new CupertinoWindowViewModel();
        }
    }
}
