using SMPHCracker.Model.Enums;
using System;
using System.Globalization;
using System.Windows.Data;

namespace SMPHCracker.View.Converter
{
    public class StatusToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null)
            {
                StatusEnum status = (StatusEnum)value;

                switch (status)
                {
                    case StatusEnum.NoDevice:
                        return "No Device";

                    case StatusEnum.Unauthorized:
                        return "Unauthorized";

                    case StatusEnum.ADB:
                        return "ADB";

                    case StatusEnum.Root:
                        return "Root";

                    case StatusEnum.Recovery:
                        return "Recovery";

                    case StatusEnum.Sideload:
                        return "Sideload";

                    default:
                        return "No Device";
                    
                }
            }

            return "No Device";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string status = value.ToString();

                switch (status)
                {
                    case "No Device":
                        return StatusEnum.NoDevice;

                    case "Unauthorized":
                        return StatusEnum.Unauthorized;

                    case "ADB":
                        return StatusEnum.ADB;

                    case "Root":
                        return StatusEnum.Root;

                    case "Recovery":
                        return StatusEnum.Recovery;

                    case "Sideload":
                        return StatusEnum.Sideload;

                    default:
                        return StatusEnum.NoDevice;

                }
            }

            return StatusEnum.NoDevice;
        }
    }
}
