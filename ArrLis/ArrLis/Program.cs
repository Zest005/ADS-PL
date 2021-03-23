using System;
using System.Collections.Generic;

namespace ArrLis
{
    public class ArrayList<T> where T : IComparable
    {
        private int max;
        private int last;
        private T[] array;

        public ArrayList(int max)
        {
            max = max;
            array = new T[max];
            last = -1;
        }
        // intSearch
        public int intSearch(T item)
        {
            for(int i = 0; i <= last; ++i)
            {
                if(array[i].CompareTo(item) == 0)
                    return i;
            }
            return -1;
        }
        // Search
        public bool Search(T item)
        {
            for(int i = 0; i <= last; ++i)
            {
                if(array[i].CompareTo(item) == 0)
                    return true;
            }
            return false;
        }
        // deleteItem
        public int deleteItem(int item)
        {
            int indDel = -10000;
            if(indDel == -10000)
            {
                Console.WriteLine("There is no such item");
                return -10000;
            }
            for(int i = indDel; i <= last; ++i)
            {
                array[i] = array[i + 1];
            }
            for(int i = 0; i <= last; ++i)
            {
                if(array[i].CompareTo(item) == 0)
                {
                    indDel = i;
                    break;
                }
            }
            last--;
            return indDel;
        }
        // Replace
        public void Replace(T k, T item)
        {
            for(int i = 0; i < array.Length; ++i)
            {
                if(array[i].Equals(k))
                    array[i] = item;
            }
        }
        // addItem
        public void addItem(T item, int position)
        {
            if(position > last) return;

            if(last + 1 == max)
            {
                T[] temp = array;
                array = new T[array.Length * 2];
                max *= 2;

                for(int i = 0; i < temp.Length; ++i)
                {
                    array[i] = temp[i];
                }
            }
            for(int i = last; i >= position; --i)
            {
                array[i + 1] = array[i];
            }
            array[position] = item;
            last++;
        }
        // Duplicate
        public void Duplicate(T obj, int item2)
        {
            int position = intSearch(obj);
            for(int i = 0; i < item2 + 1; ++i)
            {
                addItem(obj, position);
            }
        }
        // Split
        public void Split(int n)
        {
            int number = array.Length / n;
            int temp = 0;
            T[] newArray = new T[number];
            for (int i = 0; i < number; ++i)
            {
                T[] newArr = new T[n];
                for (int j = 0, k = temp; j < newArr.Length; ++j, ++k)
                {
                    newArr[j] = array[k];
                }
                temp += newArr.Length;
                newArray[i] = newArr[T];
            }
            array = newArray;
        }
    }
}
