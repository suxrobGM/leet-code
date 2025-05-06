using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1316
{
    /// <summary>
    /// 1316. Distinct Echo Substrings - Hard
    /// <a href="https://leetcode.com/problems/distinct-echo-substrings">See the problem</a>
    /// </summary>
    public int DistinctEchoSubstrings(string text)
    {
        var result = new HashSet<string>();
        int n = text.Length;

        for (int len = 2; len <= n; len += 2)
        {
            for (int i = 0; i + len <= n; i++)
            {
                int mid = i + len / 2;
                var left = text.Substring(i, len / 2);
                var right = text.Substring(mid, len / 2);

                if (left == right)
                {
                    result.Add(text.Substring(i, len));
                }
            }
        }

        return result.Count;
    }
}
