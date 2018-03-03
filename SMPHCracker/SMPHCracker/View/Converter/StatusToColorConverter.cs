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
                Status status = (Status)value;

                switch (status)
                {
                    case Status.NoDevice:
                        return Colors.Red.ToString();

                    case Status.Unauthorized:
                        return Colors.Red.ToString();

                    case Status.ADB:
                        return Colors.Yellow.ToString();

                    case Status.Root:
                        return Colors.Green.ToString();

                    case Status.Recovery:
                        return Colors.Green.ToString();

                    case Status.Sideload:
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
