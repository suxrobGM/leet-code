using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1733
{
    /// <summary>
    /// 1733. Minimum Number of People to Teach - Medium
    /// <a href="https://leetcode.com/problems/minimum-number-of-people-to-teach">See the problem</a>
    /// </summary>
    public int MinimumTeachings(int n, int[][] languages, int[][] friendships)
    {
        int m = languages.Length; // users are 1..m (1-indexed in input)
        // Build per-user language sets
        var knows = new HashSet<int>[m + 1];
        for (int i = 1; i <= m; i++)
        {
            knows[i] = [.. languages[i - 1]];
        }

        // Collect users involved in friendships that cannot communicate
        var needUsers = new HashSet<int>();
        foreach (var f in friendships)
        {
            int u = f[0], v = f[1];
            if (!ShareLanguage(knows[u], knows[v]))
            {
                needUsers.Add(u);
                needUsers.Add(v);
            }
        }

        if (needUsers.Count == 0) return 0; // already all good

        // For each language, count how many in needUsers already know it
        var knowCount = new int[n + 1];
        foreach (int user in needUsers)
            foreach (int lang in knows[user])
                knowCount[lang]++;

        int ans = int.MaxValue;
        int need = needUsers.Count;
        for (int lang = 1; lang <= n; lang++)
            ans = Math.Min(ans, need - knowCount[lang]);

        return ans;
    }

    private bool ShareLanguage(HashSet<int> a, HashSet<int> b)
    {
        // iterate smaller set
        if (a.Count > b.Count) { var t = a; a = b; b = t; }
        foreach (var x in a) if (b.Contains(x)) return true;
        return false;
    }
}
