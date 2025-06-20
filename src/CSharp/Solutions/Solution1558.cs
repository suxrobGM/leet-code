using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1558
{
    /// <summary>
    /// 1558. Minimum Numbers of Function Calls to Make Target Array - Medium
    /// <a href="https://leetcode.com/problems/minimum-numbers-of-function-calls-to-make-target-array">See the problem</a>
    /// </summary>
    public int MinOperations(int[] nums)
    {
        int totalIncrements = 0;
        int maxDoubles = 0;

        foreach (int num in nums)
        {
            int n = num;
            int bits = 0;

            while (n > 0)
            {
                if ((n & 1) == 1)
                {
                    totalIncrements++;
                }
                n >>= 1;
                bits++;
            }

            maxDoubles = Math.Max(maxDoubles, bits - 1);
        }

        return totalIncrements + maxDoubles;
    }
}
