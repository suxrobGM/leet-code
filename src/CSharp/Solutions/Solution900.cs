using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution900
{
    /// <summary>
    /// 900. RLE Iterator - Medium
    /// <a href="https://leetcode.com/problems/rle-iterator">See the problem</a>
    /// </summary>
    public class RLEIterator
    {
        private readonly int[] encoded;
        private int index;

        public RLEIterator(int[] encoded)
        {
            this.encoded = encoded;
        }

        public int Next(int n)
        {
            while (index < encoded.Length)
            {
                // If the current count can satisfy n
                if (encoded[index] >= n)
                {
                    encoded[index] -= n; // Decrement the count
                    return encoded[index + 1]; // Return the value
                }

                // Otherwise, move to the next element
                n -= encoded[index]; // Exhaust all elements of the current count
                index += 2; // Move to the next count-value pair
            }

            // If we've exhausted the array
            return -1;
        }
    }
}
