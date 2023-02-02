using JewelsCafe.Services;
using System.Globalization;

namespace JewelsCafe.Converters
{
    public class IdToCountConverter : IValueConverter
    {
        private readonly OrderService _orderService;

        public IdToCountConverter()
        {
#if WINDOWS10_0_17763_0_OR_GREATER
            _orderService = MauiWinUIApplication.Current.Services.GetService<OrderService>();
#elif ANDROID
            _orderService = MauiApplication.Current.Services.GetService<OrderService>();
#endif
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var id = Guid.Parse(value.ToString());            
            return _orderService.GetCountById(id); ;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? 1 : 0;
        }
    }
}
