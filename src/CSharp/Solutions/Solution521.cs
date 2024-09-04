using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution521
{
    /// <summary>
    /// 521. Longest Uncommon Subsequence I - Easy
    /// <a href="https://leetcode.com/problems/longest-uncommon-subsequence-i">See the problem</a>
    /// </summary>
    public int FindLUSlength(string a, string b)
    {
        return a == b ? -1 : Math.Max(a.Length, b.Length);
    }
}
