using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class BubbleSort
    {
        public static string[] Sort(string[] array)
        {
            bool flag = true;
            var temp = "";
            for (int i = 1; (i <= (array.Length - 1)) && flag; i++)
            {
                flag = false;
                for (int j = 0; j < (array.Length - 1); j++)
                {
                    if (array[j + 1].CompareTo(array[j]) < 1)
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        flag = true;
                    }
                }
            }
            return array;
        }

        public static int[] Sort(int[] array)
        {
            bool flag = true;
            int temp = -1;

            for (int i = 1; (i <= (array.Length - 1)) && flag; i++)
            {
                flag = false;
                for (int j = 0; j < (array.Length - 1); j++)
                {
                    if (array[j + 1] > array[j])
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        flag = true;
                    }
                    if (flag) break;
                }
            }
            return array;
        }

        public static int[] sortParallel(int[] array)
        {
            bool flag = true;
            int temp = -1;

            Parallel.For(1, (array.Length - 1), i =>
            {
                flag = false;
                for (int j = 0; j < (array.Length - 1); j++)
                {
                    if (array[j + 1] > array[j])
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        flag = true;
                    }
                    if (flag) break;
                }
            });
            return array;
        }
    }
}
