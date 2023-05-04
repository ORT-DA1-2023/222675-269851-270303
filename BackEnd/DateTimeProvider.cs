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
        private static DateTime? _now;
        public static DateTime Now
        {
            get
            {
                if (_now == null)
                {
                    return DateTime.Now;
                }
                else
                {
                    return (DateTime)_now;
                }
            }
            set
            {
                _now = value;
            }
        }
        public static void Reset() => _now = null;
    }
}
