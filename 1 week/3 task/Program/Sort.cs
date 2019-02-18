using System;

namespace Program
{
    class Sort
    {
        static int Partition(int[] array, int left, int right)
        {
            int first = array[left];
            int i = left + 1;
            for (int j = left + 1; j < right + 1; ++j)
            {
                if (array[j] <= first)
                {
                    Swap(ref array[j], ref array[i]);
                    i++;
                }
            }
            Swap(ref array[left], ref array[i - 1]);
            return i - 1;
        }

        static void Swap(ref int a, ref int b)
        {
            int buffer = a;
            a = b;
            b = buffer;
        }

        public static void QuickSort(int[] array, int left, int right)
        {
            if (right <= left)
            {
                return;
            }
            int pivot = Partition(array, left, right);
            QuickSort(array, left, pivot - 1);
            QuickSort(array, pivot + 1, right);
        }
    }
}
