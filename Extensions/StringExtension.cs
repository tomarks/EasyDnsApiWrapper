using System;
using System.Collections.Generic;
using System.Text;

namespace EasyDnsLibrary
{
    public static class StringExtension
    {
        public static bool HasValue(this string value) => !string.IsNullOrWhiteSpace(value);
        public static bool IsEmpty(this string value) => string.IsNullOrWhiteSpace(value);
    }
}
