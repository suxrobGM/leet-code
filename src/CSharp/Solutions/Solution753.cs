using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution753
{
    /// <summary>
    /// 753. Cracking the Safe - Hard
    /// <a href="https://leetcode.com/problems/cracking-the-safe">See the problem</a>
    /// </summary>
    public string CrackSafe(int n, int k)
    {
        var total = (int)Math.Pow(k, n);
        var sb = new StringBuilder();
        var visited = new HashSet<string>();

        for (var i = 0; i < n; i++)
        {
            sb.Append('0');
        }

        visited.Add(sb.ToString());

        DFS(sb, visited, total, n, k);

        return sb.ToString();
    }

    private bool DFS(StringBuilder sb, HashSet<string> visited, int total, int n, int k)
    {
        if (visited.Count == total) return true;

        var last = sb.ToString()[(sb.Length - n + 1)..];

        for (var i = 0; i < k; i++)
        {
            var next = last + i;

            if (!visited.Contains(next))
            {
                sb.Append(i);
                visited.Add(next);

                if (DFS(sb, visited, total, n, k)) return true;

                sb.Remove(sb.Length - 1, 1);
                visited.Remove(next);
            }
        }

        return false;
    }
}
