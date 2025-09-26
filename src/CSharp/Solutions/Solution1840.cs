using System.Text;

namespace LeetCode.Solutions;

public class Solution1840
{
    /// <summary>
    /// 1840. Maximum Building Height - Hard
    /// <a href="https://leetcode.com/problems/maximum-building-height">See the problem</a>
    /// </summary>
    public int MaxBuilding(int n, int[][] restrictions)
    {
        var list = new List<int[]>();

        // Add given restrictions
        foreach (var r in restrictions) list.Add([r[0], r[1]]);

        // Add implicit restrictions
        list.Add([1, 0]);
        list.Add([n, n - 1]);

        // Sort by id
        list.Sort((a, b) => a[0].CompareTo(b[0]));

        int m = list.Count;

        // Left -> Right tighten
        for (int i = 1; i < m; i++)
        {
            int dist = list[i][0] - list[i - 1][0];
            list[i][1] = Math.Min(list[i][1], list[i - 1][1] + dist);
        }

        // Right -> Left tighten
        for (int i = m - 2; i >= 0; i--)
        {
            int dist = list[i + 1][0] - list[i][0];
            list[i][1] = Math.Min(list[i][1], list[i + 1][1] + dist);
        }

        // Compute maximum peak between consecutive restrictions
        long ans = 0;
        for (int i = 0; i < m - 1; i++)
        {
            int a = list[i][0], ha = list[i][1];
            int b = list[i + 1][0], hb = list[i + 1][1];
            int d = b - a;
            long peak = (long)(ha + hb + d) / 2; // floor
            if (peak > ans) ans = peak;
        }

        return (int)ans;
    }
}
