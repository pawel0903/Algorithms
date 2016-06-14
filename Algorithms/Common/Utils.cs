namespace Algorithms.Common
{
    public class Utils
    {
        /// <summary>
        /// Swap helper function
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="left">first argument</param>
        /// <param name="right">second argument</param>
        public static void Swap<T>(ref T left, ref T right)
        {
            T tmp = left;
            left = right;
            right = tmp;
        }
    }
}
