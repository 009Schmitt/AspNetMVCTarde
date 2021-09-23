using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public static class Checker
    {
        /// <summary>
        /// value is the string to be analyzed, value.Length <= length
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static bool StringChecker(string value, int length)
        {
            return (!string.IsNullOrEmpty(value) && value.Length <= length);
        }
    }
}
