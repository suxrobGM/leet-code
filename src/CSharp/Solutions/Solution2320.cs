namespace LeetCode.Solutions;

public class Solution2320
{
    /// <summary>
    /// 2320. Count Number of Ways to Place Houses - Medium
    /// <a href="https://leetcode.com/problems/count-number-of-ways-to-place-houses">See the problem</a>
    /// </summary>
    public int CountHousePlacements(int n)
    {
        const int mod = 1_000_000_007;
        long empty = 1;
        long house = 0;

        // Track valid arrangements on one side by the last plot's state.
        for (var plot = 0; plot < n; plot++)
        {
            var nextEmpty = (empty + house) % mod;
            house = empty;
            empty = nextEmpty;
        }

        var ways = (empty + house) % mod;

        // The two sides can be arranged independently.
        return (int)(ways * ways % mod);
    }
}
