using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF.CustomControl.Local;

namespace WPF.CustomControl.UI.TreeListView
{
    public class TreeListViewItem : TreeViewItem
    {
        public ICommand SelectionCommand
        {
            get { return (ICommand)GetValue(SelectionCommandProperty); }
            set { SetValue(SelectionCommandProperty, value); }
        }

        public static readonly DependencyProperty SelectionCommandProperty =
            DependencyProperty.Register("SelectionCommand", typeof(ICommand), typeof(TreeListViewItem), new PropertyMetadata(null));


        static TreeListViewItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeListViewItem), new FrameworkPropertyMetadata(typeof(TreeListViewItem)));
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

        public TreeListViewItem()
        {
            MouseLeftButtonUp += TreeListViewItem_MouseLeftButtonUp;
        }

        private void TreeListViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            if (DataContext is SysDeptDto item)
            {
                SelectionCommand?.Execute(item);
            }
        }
    }
}

