using SMPHCracker.Model.Enums;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SMPHCracker.View.Converter
{
    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null)
            {
                StatusEnum status = (StatusEnum)value;

                switch (status)
                {
                    case StatusEnum.NoDevice:
                        return Colors.Red.ToString();

                    case StatusEnum.Unauthorized:
                        return Colors.Red.ToString();

                    case StatusEnum.ADB:
                        return Colors.Yellow.ToString();

                    case StatusEnum.Root:
                        return Colors.Green.ToString();

                    case StatusEnum.Recovery:
                        return Colors.Green.ToString();

                    case StatusEnum.Sideload:
                        return Colors.Green.ToString();

                    default:
                        return Colors.Red.ToString();
                    
                }
            }

            return Colors.Red.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new NotImplementedException();
        }
    }
}
