using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlixCloud
{
    public sealed class Helper
    {
        public static int? ConvertInt32(string value)
        {
            if (value == String.Empty)
            {
                return null;
            }

            return Int32.Parse(value);
        }

        public static Int64? ConvertInt64(string value)
        {
            if (value == String.Empty)
            {
                return null;
            }

            return Int64.Parse(value);
        }
    }
}
