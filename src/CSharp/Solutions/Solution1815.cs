using System.Text;

namespace LeetCode.Solutions;

public class Solution1815
{
    private int batchSize;
    private Dictionary<string, int> memo = [];

    /// <summary>
    /// 1815. Maximum Number of Groups Getting Fresh Donuts - Hard
    /// <a href="https://leetcode.com/problems/maximum-number-of-groups-getting-fresh-donuts">See the problem</a>
    /// </summary>
    public int MaxHappyGroups(int batchSize, int[] groups)
    {
        this.batchSize = batchSize;
        int happy = 0;
        int[] cnt = new int[batchSize];

        // count remainders
        foreach (var g in groups)
        {
            int r = g % batchSize;
            if (r == 0) happy++;   // remainder 0 groups always happy
            else cnt[r]++;
        }

        return happy + Dfs(cnt, 0);
    }

    private int Dfs(int[] cnt, int leftover)
    {
        string key = string.Join(",", cnt) + "|" + leftover;
        if (memo.TryGetValue(key, out int cached)) return cached;

        int best = 0;
        for (int r = 1; r < batchSize; r++)
        {
            if (cnt[r] == 0) continue;

            cnt[r]--;

            int add = (leftover == 0) ? 1 : 0;
            int nextLeftover = (leftover + r) % B;

            best = Math.Max(best, add + Dfs(cnt, nextLeftover));

            cnt[r]++;
        }

        memo[key] = best;
        return best;
    }
}
