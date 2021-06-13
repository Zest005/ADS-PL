using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    class List
    {
        //1
        public int HashFunction_1(string s, string[] array)
        {
            return s.Length % array.Length;
        }
        //2
        public int HashFunction_2(string s, string[] array)
        {
            return s.Length % array.Length;
        }
        //3
        public void sort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (arr[j] < arr[min_idx])
                        min_idx = j;

                int temp = arr[min_idx];
                arr[min_idx] = arr[i];
                arr[i] = temp;
                if (check(i, arr))
                {
                    return;
                }
            }
        }
        public bool check(int i, int[] arr)
        {
            for (int z = i; z < arr.Length - 1; z++)
            {
                if (arr[z] > arr[z+1])
                {
                    return false;
                }
            }
            return true;
        }
        //4
        public void insertion_sort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }
        //4 c
        public void insertion_sort_c(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] < key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }
        //5
        public void bubbleSort(int[] arr,
                   int n)
        {
            if (n == 1)
                return;
            for (int i = 0; i < n - 1; i++)
                if (arr[i] > arr[i + 1])
                {
                    int temp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = temp;
                }
            bubbleSort(arr, n - 1);
        }
        //6
        public void insertion_sort_Rec(int[] arr,
                                   int n)
        {
            if (n <= 1)
                return;
            insertion_sort_Rec(arr, n - 1);
            int last = arr[n - 1];
            int j = n - 2;
            while (j >= 0 && arr[j] > last)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = last;
        }
        //7 
        public void Binary_sort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int x = array[i];
                int j = Math.Abs(
                    Array.BinarySearch(array,
                                       0, i, x) + 1);
                System.Array.Copy(array, j,
                                  array, j + 1,
                                  i - j);
                array[j] = x;
            }
        }
        //8
        //The algorithm as a whole still has a running worst-case running time of O(n2) because of the series of swaps required for each insertion. 

        //9
        public void bucketSort(float[] arr, int n)
        {
            if (n <= 0)
                return;

            List<float>[] buckets = new List<float>[n];

            for (int i = 0; i < n; i++)
            {
                buckets[i] = new List<float>();
            }

            for (int i = 0; i < n; i++)
            {
                float idx = arr[i] * n;
                buckets[(int)idx].Add(arr[i]);
            }

            for (int i = 0; i < n; i++)
            {
                buckets[i].Sort();
            }

            int index = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < buckets[i].Count; j++)
                {
                    arr[index++] = buckets[i][j];
                }
            }
        }
    }
}
