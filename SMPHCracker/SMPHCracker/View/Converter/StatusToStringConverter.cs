using SMPHCracker.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SMPHCracker.View.Converter
{
    public class StatusToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null)
            {
                Status status = (Status)value;

                switch (status)
                {
                    case Status.NoDevice:
                        return "No Device";

                    case Status.Unauthorized:
                        return "Unauthorized";

                    case Status.ADB:
                        return "ADB";

                    case Status.Root:
                        return "Root";

                    case Status.Recovery:
                        return "Recovery";

                    case Status.Sideload:
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
                        return Status.NoDevice;

                    case "Unauthorized":
                        return Status.Unauthorized;

                    case "ADB":
                        return Status.ADB;

                    case "Root":
                        return Status.Root;

                    case "Recovery":
                        return Status.Recovery;

                    case "Sideload":
                        return Status.Sideload;

                    default:
                        return Status.NoDevice;

                }
            }

            return Status.NoDevice;
        }
    }
}
