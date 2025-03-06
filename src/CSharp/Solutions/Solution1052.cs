using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1052
{
    /// <summary>
    /// 1052. Grumpy Bookstore Owner - Medium
    /// <a href="https://leetcode.com/problems/grumpy-bookstore-owner</a>
    /// </summary>
    public int MaxSatisfied(int[] customers, int[] grumpy, int minutes)
    {
        var satisfied = 0;
        var max = 0;
        var current = 0;
        var left = 0;
        var right = 0;

        while (right < customers.Length)
        {
            if (grumpy[right] == 0)
            {
                satisfied += customers[right];
            }
            else
            {
                current += customers[right];
            }

            if (right - left + 1 > minutes)
            {
                if (grumpy[left] == 1)
                {
                    current -= customers[left];
                }

                left++;
            }

            max = Math.Max(max, current);
            right++;
        }

        return satisfied + max;
    }
}
