using System;
using System.Collections.Generic;
using System.Text;

namespace CustomList
{
    class Sorter
    {
        public static void Sort<T>(CustomList<T> customList) where T : IComparable<T>
        {
            for (int i = 1; i <= customList.Count - 1; ++i)
            {
                for (int j = 0; j < customList.Count - i; ++j)
                {

                    if (customList[j].CompareTo(customList[j + 1]) > 0)
                    {
                        var temp = customList[j];
                        customList[j] = customList[j + 1];
                        customList[j + 1] = temp;
                    }
                }
            }
        }
    }
}
