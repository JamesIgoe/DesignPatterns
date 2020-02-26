using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns
{
    static class CommonMethods
    {
        public static int[] Swap(int[] arrayToUse, int itemOneIndex, int itemTwoIndex)
        {
            int tempValueHolder = arrayToUse[itemOneIndex];
            arrayToUse[itemOneIndex] = arrayToUse[itemTwoIndex];
            arrayToUse[itemTwoIndex] = tempValueHolder;
            return arrayToUse;
        }
    }
}
