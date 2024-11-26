using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace WPF.CustomControl.UI.TreeListView
{
    public class TreeListView : TreeView
    {
        static TreeListView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeListView), new FrameworkPropertyMetadata(typeof(TreeListView)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            var item = new TreeListViewItem
            {
                // 设置样式
                Style = FindResource("DepartmentTreeListViewItem") as Style
            };
            return item;
        }
    }
}
