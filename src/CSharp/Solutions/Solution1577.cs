using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1577
{
    /// <summary>
    /// 1577. Number of Ways Where Square of Number Is Equal to Product of Two Numbers - Medium
    /// <a href="https://leetcode.com/problems/number-of-ways-where-square-of-number-is-equal-to-product-of-two-numbers">See the problem</a>
    /// </summary>
    public int NumTriplets(int[] nums1, int[] nums2)
    {
        return CountTriplets(nums1, nums2) + CountTriplets(nums2, nums1);
    }

    private int CountTriplets(int[] squareArray, int[] productArray)
    {
        int count = 0;

        foreach (long a in squareArray)
        {
            long target = a * a;
            var freq = new Dictionary<long, int>();

            foreach (int b in productArray)
            {
                if (b == 0)
                {
                    if (target == 0)
                    {
                        // Special case: if target is zero, all previous zeros can pair
                        count += freq.ContainsKey(0) ? freq[0] : 0;
                    }
                    // Don't divide by zero
                }
                else
                {
                    if (target % b == 0)
                    {
                        long other = target / b;
                        if (freq.ContainsKey(other))
                        {
                            count += freq[other];
                        }
                    }
                }

                if (!freq.ContainsKey(b)) freq[b] = 0;
                freq[b]++;
            }
        }

        return count;
    }
}
