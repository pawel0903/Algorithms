using System;

namespace Tests.Searching.Structures
{
    /// <summary>
    /// Basic item class used for time complexity test
    /// </summary>
    /// <typeparam name="T">Type - must implement IComparable<T></typeparam>
    public class Item<T> : IComparable<Item<T>> where T : IComparable<T>
    {
        private T _value;
        public T Value
        {
            get
            {
                Counter++;
                return _value;
            }
            set
            {
                this._value = value;
            }
        }
        public int Counter { get; private set; }

        public Item(T value)
        {
            this.Value = value;
        }

        public int CompareTo(Item<T> other)
        {
            return this.Value.CompareTo(other.Value);
        }

        public static int TimeComplexity(Item<T>[] array)
        {
            int sum = 0;
            foreach (var item in array)
            {
                sum += item.Counter;
            }
            return sum;
        }
    }
}
