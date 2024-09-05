using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution522
{
    /// <summary>
    /// 522. Longest Uncommon Subsequence II - Medium
    /// <a href="https://leetcode.com/problems/longest-uncommon-subsequence-ii">See the problem</a>
    /// </summary>
    public int FindLUSlength(string[] strs)
    {
        var n = strs.Length;
        Array.Sort(strs, (a, b) => b.Length.CompareTo(a.Length));

        for (var i = 0; i < n; i++)
        {
            var isSubsequence = false;
            for (var j = 0; j < n; j++)
            {
                if (i == j) continue;
                if (IsSubsequence(strs[i], strs[j]))
                {
                    isSubsequence = true;
                    break;
                }
            }

            if (!isSubsequence) return strs[i].Length;
        }

        return -1;
    }

    private bool IsSubsequence(string a, string b)
    {
        var i = 0;
        var j = 0;

        while (i < a.Length && j < b.Length)
        {
            if (a[i] == b[j]) i++;
            j++;
        }

        return i == a.Length;
    }
}
