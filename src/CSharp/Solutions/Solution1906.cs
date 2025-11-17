using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1906
{
    /// <summary>
    /// 1906. Minimum Absolute Difference Queries - Medium
    /// <a href="https://leetcode.com/problems/minimum-absolute-difference-queries">See the problem</a>
    /// </summary>
    public int[] MinDifference(int[] nums, int[][] queries)
    {
        int n = nums.Length;
        int maxNum = 100;
        var prefixCounts = new int[n + 1, maxNum + 1];

        for (int i = 0; i < n; i++)
        {
            for (int num = 1; num <= maxNum; num++)
            {
                prefixCounts[i + 1, num] = prefixCounts[i, num];
            }
            prefixCounts[i + 1, nums[i]]++;
        }

        int[] result = new int[queries.Length];

        for (int q = 0; q < queries.Length; q++)
        {
            int left = queries[q][0];
            int right = queries[q][1];

            int prevNum = -1;
            int minDiff = int.MaxValue;

            for (int num = 1; num <= maxNum; num++)
            {
                int countInRange = prefixCounts[right + 1, num] - prefixCounts[left, num];
                if (countInRange > 0)
                {
                    if (prevNum != -1)
                    {
                        minDiff = Math.Min(minDiff, num - prevNum);
                    }
                    prevNum = num;
                }
            }

            result[q] = minDiff == int.MaxValue ? -1 : minDiff;
        }

        return result;
    }
}
