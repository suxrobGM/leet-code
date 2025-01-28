using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution960
{
    /// <summary>
    /// 960. Delete Columns to Make Sorted III - Medium
    /// <a href="https://leetcode.com/problems/delete-columns-to-make-sorted-iii">See the problem</a>
    /// </summary>
    public int MinDeletionSize(string[] strs)
    {
        var n = strs.Length;
        var m = strs[0].Length;
        var dp = new int[m];
        var result = m - 1;

        for (var i = 0; i < m; i++)
        {
            dp[i] = 1;

            for (var j = 0; j < i; j++)
            {
                var valid = true;

                for (var k = 0; k < n; k++)
                {
                    if (strs[k][j] > strs[k][i])
                    {
                        valid = false;
                        break;
                    }
                }

                if (valid)
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }

            result = Math.Min(result, m - dp[i]);
        }

        return result;
    }
}
