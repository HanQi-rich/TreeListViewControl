using Cupertino.Support.Local.Models;
using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cupertino.Control.UI
{
    public class TreeListViewItem:Behavior<TreeViewItem>
    {
        public ICommand SelectionCommand
        {
            get { return (ICommand)GetValue(SelectionCommandProperty); }
            set { SetValue(SelectionCommandProperty, value); }
        }

        public Type DefaultStyleKey
        {
            get { return (Type)GetValue(DefaultStyleKeyProperty); }
            set { SetValue(DefaultStyleKeyProperty, value); }
        }

        // 设置你的行为的默认样式关键字
        public static readonly DependencyProperty DefaultStyleKeyProperty = DependencyProperty.Register(
            "DefaultStyleKey", typeof(Type), typeof(TreeListViewItem), new PropertyMetadata(null));

        public static readonly DependencyProperty SelectionCommandProperty =
            DependencyProperty.Register("SelectionCommand", typeof(ICommand), typeof(TreeListViewItem), new PropertyMetadata(null));


        static TreeListViewItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeListViewItem), new FrameworkPropertyMetadata(typeof(TreeListViewItem)));
        }

        private void TreeListViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            if (AssociatedObject.DataContext is FileItem item)
            {
                SelectionCommand?.Execute(item);
            }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.MouseLeftButtonUp += TreeListViewItem_MouseLeftButtonUp;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.MouseLeftButtonUp-= TreeListViewItem_MouseLeftButtonUp;
        }
    }
}

