using System;
using System.Collections.Generic;
using System.Text;

namespace EasyDnsLibrary
{
    public static class ListExtension
    {
        public static bool IsEmpty<T>(this List<T> list) => list == null || list.Count == 0;
        public static bool HasItems<T>(this List<T> list) => list != null && list.Count > 0;
    }
}
