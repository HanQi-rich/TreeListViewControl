using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows;

namespace WPF.CustomControl.Converter
{
  
        public sealed class IntToMarginConverter : MarkupExtension, IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                int depth = (int)value;
                Thickness margin = new Thickness(depth * 20, 0, 0, 0);
                return margin;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }

            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                return this;
            }
        }
    
}
