using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistryClassLibrary
{
    public class InputClass
    {
        public static bool HourChecking(string input)
        {
            DateTime result;
            return DateTime.TryParseExact(input, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
        }
        public static bool DataChecking(string dateString)
        {
            DateTime result;
            return DateTime.TryParse(dateString, out result);
        }

    }
}
