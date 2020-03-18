using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    public static partial class GreatestCommonDivisor
    {
        /// <summary>
        /// Сalculates the execution time of the passed method and returns the result of the execution     
        /// </summary>
        /// <param name="func">The tested Method</param>
        /// <param name="time">Time of the execution</param>
        /// <returns></returns>
        static int CalculateTime(Func<int> func, out long time)
        {
            var timer = new Stopwatch();
            timer.Start();
            var result = func.Invoke();
            timer.Stop();
            time = timer.ElapsedMilliseconds;
            return result;
        }
    }
}
