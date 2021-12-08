using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPPLab9
{
    public class DynamicList<T> : IEnumerable
    {
        private const int INCOUNTER = 100;
        private int size;
        private int currentElement;
        private T[] array;

        public int Count
        {
            get { return array.Length; }
            private set {; }
        }
        public T this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }
        public DynamicList(int size)
        {
            this.size = size;
            array = new T[size];
            currentElement = 0;
        }
        private T[] CopyAndExtend(T[] array)
        {
            int length = array.Length + INCOUNTER;
            T[] newArray = new T[length];
            for (int i = 0; i < array.Length; i++)
                newArray[i] = array[i];
            return newArray;
        }
        public void Add(T item)
        {
            if (currentElement > array.Length - 1)
                array = CopyAndExtend(array);
            array[currentElement] = item;
            currentElement++;
        }
        public void RemoveAt(int index)
        {
            var dest = new T[array.Length - 1];
            if (index > 0)
                Array.Copy(array, 0, dest, 0, index);

            if (index < array.Length - 1)
                Array.Copy(array, index + 1, dest, index,
                array.Length - index - 1);
            currentElement--;
            array = dest;
        }

        public void Remove(T name)
        {
            int numIndex = Array.IndexOf(array, name);
            array = array.Where((val, idx) => idx != numIndex).ToArray();
            currentElement--;
        }

        public void Clear()
        {
            array = new T[size];
            currentElement = 0;
        }

        public IEnumerator GetEnumerator()
        {
            return array.GetEnumerator();
        }
    }
}
