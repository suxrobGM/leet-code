using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1130
{
    /// <summary>
    /// 1130. Minimum Cost Tree From Leaf Values - Medium
    /// <a href="https://leetcode.com/problems/minimum-cost-tree-from-leaf-values">See the problem</a>
    /// </summary>
    public int MctFromLeafValues(int[] arr)
    {
        var n = arr.Length;
        var dp = new int[n, n];
        var max = new int[n, n];

        for (var i = 0; i < n; i++)
        {
            max[i, i] = arr[i];

            for (var j = i + 1; j < n; j++)
            {
                max[i, j] = Math.Max(max[i, j - 1], arr[j]);
            }
        }

        for (var len = 2; len <= n; len++)
        {
            for (var i = 0; i <= n - len; i++)
            {
                var j = i + len - 1;
                dp[i, j] = int.MaxValue;

                for (var k = i; k < j; k++)
                {
                    dp[i, j] = Math.Min(dp[i, j], dp[i, k] + dp[k + 1, j] + max[i, k] * max[k + 1, j]);
                }
            }
        }

        return dp[0, n - 1];
    }
}
