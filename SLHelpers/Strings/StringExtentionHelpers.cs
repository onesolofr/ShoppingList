using System;
using System.Collections.Generic;
using System.Text;

namespace SLHelpers
{
    static public class StringExtentionHelpers
    {
        static public bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}
