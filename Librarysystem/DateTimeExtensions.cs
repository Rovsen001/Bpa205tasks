using System;
using System.Collections.Generic;
using System.Text;

namespace Librarysystem
{
    static class DateTimeExtensions
    {
        public static bool IsNew(this DateTime date)
        {
            if ((DateTime.Now - date).TotalDays <= 7) return true;
            else return false;
        }
    }
}
