namespace LeetCode.Solutions;

public class Solution2167
{
    /// <summary>
    /// 2167. Minimum Time to Remove All Cars Containing Illegal Goods - Hard
    /// <a href="https://leetcode.com/problems/minimum-time-to-remove-all-cars-containing-illegal-goods">See the problem</a>
    /// </summary>
    public int MinimumTime(string s)
    {
        var n = s.Length;

        // pre[i] = min time to clear all '1's among s[0..i-1] using only
        // left-end removals (cost 1 each, sweeping a prefix) and middle removals (cost 2).
        var pre = new int[n + 1];
        for (var i = 0; i < n; i++)
        {
            pre[i + 1] = s[i] == '0'
                ? pre[i]
                : Math.Min(pre[i] + 2, i + 1);
        }

        // Sweep a suffix from the right, combining with the matching prefix at each split.
        // suf = min time to clear all '1's among s[j..n-1] using right-end and middle removals.
        var ans = pre[n]; // split at n: clear everything from the left, empty suffix
        var suf = 0;
        for (var j = n - 1; j >= 0; j--)
        {
            if (s[j] == '1')
                suf = Math.Min(suf + 2, n - j);

            ans = Math.Min(ans, pre[j] + suf);
        }

        return ans;
    }
}
