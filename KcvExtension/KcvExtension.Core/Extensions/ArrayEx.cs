using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMing.KcvExtension.Core.Extensions
{
    public static class ArrayEx
    {
        public static int? Get(this int[] array, int index)
        {
            return array.Length > index ? (int?)array[index] : null;
        }
    }
}
