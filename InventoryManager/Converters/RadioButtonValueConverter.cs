using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace InventoryManager.Converters
{
    internal class RadioButtonValueConverter:MarkupExtension, IValueConverter
    {
        public RadioButtonValueConverter(object optionValue)
            => OptionValue = optionValue;
        public object OptionValue { get; }
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => value.Equals(OptionValue);


        public object ConvertBack(object isChecked, Type targetType, object parameter, CultureInfo culture)
            => (bool)isChecked
                ? OptionValue
                : Binding.DoNothing;

        public override object ProvideValue(IServiceProvider serviceProvider)
            => this;
    }
}
