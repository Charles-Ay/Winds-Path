using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winds_Path.Source.Public
{
    class Utilites
    {
        /// <summary>
        /// Generate random numbe bettween min and max. max is exclsive
        /// </summary>
        /// <param name="min">min number</param>
        /// <param name="max">max number</param>
        /// <returns></returns>
        internal static int GenerateRandomNumber(int min, int max)
        {
            return new Random().Next(min, max);
        }
    }
}
