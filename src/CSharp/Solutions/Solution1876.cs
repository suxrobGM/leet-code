using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1876
{
    /// <summary>
    /// 1876. Substrings of Size Three with Distinct Characters - Easy
    /// <a href="https://leetcode.com/problems/substrings-of-size-three-with-distinct-characters">See the problem</a>
    /// </summary>
    public int CountGoodSubstrings(string s)
    {
        int count = 0;
        for (int i = 0; i <= s.Length - 3; i++)
        {
            if (s[i] != s[i + 1] && s[i] != s[i + 2] && s[i + 1] != s[i + 2])
            {
                count++;
            }
        }
        return count;
    }
}
