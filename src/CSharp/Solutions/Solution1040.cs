using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1040
{
    /// <summary>
    /// 1040. Moving Stones Until Consecutive II - Medium
    /// <a href="https://leetcode.com/problems/moving-stones-until-consecutive-ii</a>
    /// </summary>
    public int[] NumMovesStonesII(int[] stones)
    {
        Array.Sort(stones);
        int n = stones.Length;
        int max = Math.Max(stones[n - 1] - stones[1] - n + 2, stones[n - 2] - stones[0] - n + 2);
        int min = n;
        int i = 0;
        for (int j = 0; j < n; j++)
        {
            while (stones[j] - stones[i] >= n)
            {
                i++;
            }

            if (j - i + 1 == n - 1 && stones[j] - stones[i] == n - 2)
            {
                min = Math.Min(min, 2);
            }
            else
            {
                min = Math.Min(min, n - (j - i + 1));
            }
        }

        return [min, max];
    }
}
