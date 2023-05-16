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
        /// <summary>
        /// Проверка вводимого времени в поле
        /// </summary>
        /// <param name="input">
        /// Входная строка, содержащая время
        /// </param>
        /// <returns>
        /// Если время можно преобразовать, то true, в ином случае false
        /// </returns>
        public static bool HourChecking(string input)
        {
            DateTime result;
            return DateTime.TryParseExact(input, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
        }
        /// <summary>
        /// Проверка вводимой даты в поле
        /// </summary>
        /// <param name="dateString">
        /// Строка с вводимой датой
        /// </param>
        /// <returns>
        /// Если успешно удалось конвертировать, то true, в ином случае false
        /// </returns>
        public static bool DataChecking(string dateString)
        {
            DateTime result;
            return DateTime.TryParse(dateString, out result);
        }
     
    }
}
