using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1016
{
    /// <summary>
    /// 1016. Binary String With Substrings Representing 1 To N - Medium
    /// <a href="https://leetcode.com/problems/binary-string-with-substrings-representing-1-to-n</a>
    /// </summary>
    public bool QueryString(string s, int n)
    {
        for (var i = n; i > n / 2; i--)
        {
            if (!s.Contains(Convert.ToString(i, 2)))
            {
                return false;
            }
        }

        return true;
    }
}
