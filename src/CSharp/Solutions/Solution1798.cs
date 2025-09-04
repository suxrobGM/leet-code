using System.Text;

namespace LeetCode.Solutions;

public class Solution1798
{
    /// <summary>
    /// 1798. Maximum Number of Consecutive Values You Can Make - Medium
    /// <a href="https://leetcode.com/problems/maximum-number-of-consecutive-values-you-can-make">See the problem</a>
    /// </summary>
    public int GetMaximumConsecutive(int[] coins)
    {
        Array.Sort(coins);
        int maxConsecutive = 0;
        for (int i = 0; i < coins.Length; i++)
        {
            if (coins[i] > maxConsecutive + 1)
            {
                break;
            }
            maxConsecutive += coins[i];
        }
        return maxConsecutive + 1;
    }
}

