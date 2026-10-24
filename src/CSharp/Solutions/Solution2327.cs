namespace LeetCode.Solutions;

public class Solution2327
{
    /// <summary>
    /// 2327. Number of People Aware of a Secret - Medium
    /// <a href="https://leetcode.com/problems/number-of-people-aware-of-a-secret">See the problem</a>
    /// </summary>
    public int PeopleAwareOfSecret(int n, int delay, int forget)
    {
        const int mod = 1_000_000_007;
        var learned = new long[n + 1];
        learned[1] = 1;
        long sharing = 0;

        for (var day = 2; day <= n; day++)
        {
            // People start sharing after delay days and stop when they forget.
            if (day - delay >= 1)
            {
                sharing = (sharing + learned[day - delay]) % mod;
            }

            if (day - forget >= 1)
            {
                sharing = (sharing - learned[day - forget] + mod) % mod;
            }

            learned[day] = sharing;
        }

        long aware = 0;
        for (var day = Math.Max(1, n - forget + 1); day <= n; day++)
        {
            aware = (aware + learned[day]) % mod;
        }

        return (int)aware;
    }
}
