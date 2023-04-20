using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Render3D.BackEnd
{
    public class DateTimeProvider
    {
        private static DateTime? now;
        public static DateTime Now
        {
            get
            {
                if (now == null)
                {
                    return DateTime.Now;
                }
                else
                {
                    return (DateTime)now;
                }
            }
            set
            {
                now = value;
            }
        }
        public static void Reset() => now = null;
    }
}
