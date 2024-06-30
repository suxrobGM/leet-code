using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution260
{
    /// <summary>
    /// 260. Single Number III - Medium
    /// <a href="https://leetcode.com/problems/single-number-iii">See the problem</a>
    /// </summary>
    public int[] SingleNumber(int[] nums)
    {
        var xor = 0;

        foreach (var num in nums)
        {
            xor ^= num;
        }

        var mask = 1;

        while ((xor & mask) == 0)
        {
            mask <<= 1;
        }

        var num1 = 0;
        var num2 = 0;

        foreach (var num in nums)
        {
            if ((num & mask) == 0)
            {
                num1 ^= num;
            }
            else
            {
                num2 ^= num;
            }
        }

        return [num1, num2];
    }
}
