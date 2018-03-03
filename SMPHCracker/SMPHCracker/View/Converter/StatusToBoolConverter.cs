using SMPHCracker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace SMPHCracker.View.Converter
{
    public class StatusToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && parameter != null)
            {
                Status status = (Status)value;
                Status allowed = (Status)parameter;

                if (allowed.Equals(status))
                    return true;

                switch (allowed)
                {
                    case Status.RootXRecovery:
                        if (status == Status.Root || status == Status.Recovery)
                            return true;
                        break;

                    case Status.RootXRecoveryXSideload:
                        if (status == Status.Root || status == Status.Recovery || status == Status.Sideload)
                            return true;
                        break;

                    case Status.RecoveryXSideload:
                        if (status == Status.Recovery || status == Status.Sideload)
                            return true;
                        break;
                }
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new NotImplementedException();
        }
    }
}
