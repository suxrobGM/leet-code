using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1449
{
    /// <summary>
    /// 1449. Form Largest Integer With Digits That Add up to Target - Hard
    /// <a href="https://leetcode.com/problems/form-largest-integer-with-digits-that-add-up-to-target">See the problem</a>
    /// </summary>
    public string LargestNumber(int[] cost, int target)
    {
        var dp = new string[target + 1];
        dp[0] = "";

        for (int t = 1; t <= target; t++)
        {
            dp[t] = null;
            for (int d = 9; d >= 1; d--)
            {
                int c = cost[d - 1];
                if (t >= c && dp[t - c] != null)
                {
                    string candidate = d.ToString() + dp[t - c];
                    if (dp[t] == null || Compare(candidate, dp[t]) > 0)
                    {
                        dp[t] = candidate;
                    }
                }
            }
        }

        return dp[target] ?? "0";
    }

    private int Compare(string a, string b)
    {
        if (a.Length != b.Length) return a.Length.CompareTo(b.Length);
        return string.Compare(a, b, StringComparison.Ordinal);
    }
}
