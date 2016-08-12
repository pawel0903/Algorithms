using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Common;

namespace Algorithms.DataStructures
{
    public class MinHeap<T> where T : IComparable<T>
    {
        private T[] HeapArray { get; set; }
        private int HeapSize { get; set; }

        private int Parent(int i) => (i - 1)/2;

        private int Left(int i) => 2*i + 1;

        private int Right(int i) => 2 * i + 2;

        private void FixUp(int current)
        {
            int parent = Parent(current);
            while (parent >= 0 && HeapArray[current].CompareTo(HeapArray[parent]) < 0)
            {
                Utils.Swap(ref HeapArray[current], ref HeapArray[parent]);
                current = parent;
                parent = Parent(current);
            }
        }

        public MinHeap(int capacity)
        {
            HeapArray = new T[capacity];
            HeapSize = 0;
        }

        private bool CheckBoundries(int i) => (i >= 0 && i < HeapSize);

        private int GetMin(int i, int j)
        {
            if (!CheckBoundries(i) && CheckBoundries(j))
                return j;

            if (!CheckBoundries(j) && CheckBoundries(i))
                return i;

            return HeapArray[i].CompareTo(HeapArray[j]) < 0 ? i : j;
        }

        public void Heapify(int i)
        {
            if (i >= HeapSize || i < 0)
                return;

            int left = Left(i);
            int right = Right(i);
            int min = GetMin(GetMin(left, i), GetMin(right, i));

            if (min != i)
            {
                Utils.Swap(ref HeapArray[i], ref HeapArray[min]);
                Heapify(min);
            }
        }

        public T ExtractMin()
        {
            if(HeapSize == 0)
                throw new Exception("Heap is empty!");
            if (HeapSize == 1)
            {
                HeapSize--;
                return HeapArray[0];
            }

            T result = HeapArray[0];
            HeapArray[0] = HeapArray[--HeapSize];
            Heapify(0);

            return result;
        }

        public void DecreaseKey(int i, T newVal)
        {
            if (HeapSize == 0 || !CheckBoundries(i))
                throw new Exception("Wrong index or heap is empty!");

            if (newVal.CompareTo(HeapArray[i]) >= 0)
                throw new Exception("New value must be less than current value!");

            HeapArray[i] = newVal;
            FixUp(i);
        }

        public T GetMin()
        {
            if (HeapSize == 0)
                throw new Exception("Heap is empty!");

            return HeapArray[0];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="minValue">Minimum value for type T, eg. in int int.MinValue</param>
        public void DeleteKey(int i, T minValue)
        {
            if (CheckBoundries(i))
            {
                DecreaseKey(i, minValue);
                ExtractMin();
            }
        }

        public void InsertKey(T key)
        {
            if (HeapSize == HeapArray.Length)
            {
                T[] newHeap = new T[HeapArray.Length * 2];
                HeapArray.CopyTo(newHeap, 0);
                HeapArray = newHeap;
            }

            HeapArray[HeapSize] = key;
            FixUp(HeapSize++);
        }
    }
}
