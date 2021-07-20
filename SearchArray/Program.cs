namespace SearchArray
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine($"{IsInclude(new[] { 1, 2, 3, 5, 7, 9, 11 }, new int[0])}=={true}");
            Console.WriteLine($"{IsInclude(new[] { 1, 2, 3, 5, 7, 9, 11 }, new[] { 3, 5, 7 })}=={true}");
            Console.WriteLine($"{IsInclude(new[] { 1, 2, 3, 5, 7, 9, 11 }, new[] { 4, 5, 7 })}=={false}");
        }

        private static bool IsInclude(IReadOnlyList<int> array, IReadOnlyList<int> subArray)
        {
            if (subArray.Count == 0)
            {
                return true;
            }

            var low = 0;
            var high = array.Count;

            while (low <= high)
            {
                var mid = (((low + high) / 2) << 1) >> 1;
                if (array.Count <= mid)
                {
                    return false;
                }

                var left = array[mid];
                var right = subArray[0];
                
                if (left == right)
                {
                    var fullCompare = true;
                    for (var i = 1; i < subArray.Count; i++)
                    {
                        var next = mid + i;
                        if (subArray[i] != array[next])
                        {
                            fullCompare = false;
                            break;
                        }
                    }

                    if (fullCompare)
                    {
                        return true;
                    }
                }

                if (left > right)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return false;
        }
    }
}