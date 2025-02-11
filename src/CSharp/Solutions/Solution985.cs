using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution985
{
    /// <summary>
    /// 985. Sum of Even Numbers After Queries - Medium
    /// <a href="https://leetcode.com/problems/sum-of-even-numbers-after-queries">See the problem</a>
    /// </summary>
    public int[] SumEvenAfterQueries(int[] nums, int[][] queries)
    {
        var result = new int[queries.Length];
        var sum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 2 == 0)
            {
                sum += nums[i];
            }
        }

        for (int i = 0; i < queries.Length; i++)
        {
            var val = queries[i][0];
            var index = queries[i][1];

            if (nums[index] % 2 == 0)
            {
                sum -= nums[index];
            }

            nums[index] += val;

            if (nums[index] % 2 == 0)
            {
                sum += nums[index];
            }

            result[i] = sum;
        }

        return result;
    }
}
