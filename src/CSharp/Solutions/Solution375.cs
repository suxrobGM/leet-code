namespace LeetCode.Solutions;

public class Solution375
{
    /// <summary>
    /// 375. Guess Number Higher or Lower II - Medium
    /// <a href="https://leetcode.com/problems/guess-number-higher-or-lower-ii">See the problem</a>
    /// </summary>
    public int GetMoneyAmount(int n)
    {
        var dp = new int[n + 1, n + 1];

        for (var len = 2; len <= n; len++)
        {
            for (var start = 1; start <= n - len + 1; start++)
            {
                var minCost = int.MaxValue;

                for (var pivot = start; pivot < start + len - 1; pivot++)
                {
                    var cost = pivot + Math.Max(dp[start, pivot - 1], dp[pivot + 1, start + len - 1]);
                    minCost = Math.Min(minCost, cost);
                }

                dp[start, start + len - 1] = minCost;
            }
        }

        return dp[1, n];
    }
}
