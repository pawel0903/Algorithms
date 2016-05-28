using System;

namespace Tests.TestStructures
{
    /// <summary>
    /// Basic item class used for time complexity test
    /// </summary>
    /// <typeparam name="T">Type - must implement IComparable<T></typeparam>
    public class Item<T> : IComparable<Item<T>> where T : IComparable<T>
    {
        private T _value;
        /// <summary>
        /// Item value
        /// </summary>
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
        /// <summary>
        /// How many times the object value was accesed
        /// </summary>
        public int Counter { get; private set; }

        /// <summary>
        /// Item constructor
        /// </summary>
        /// <param name="value">initial Value parameter</param>
        public Item(T value)
        {
            this.Value = value;
        }

        public int CompareTo(Item<T> other)
        {
            return this.Value.CompareTo(other.Value);
        }

        /// <summary>
        /// Returns time complexity of array collection
        /// </summary>
        /// <param name="array">collection of items</param>
        /// <returns>Sum of items access</returns>
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
