using System.Text;

namespace LeetCode.Solutions;

public class Solution696
{
    /// <summary>
    /// 696. Count Binary Substrings - Easy
    /// <a href="https://leetcode.com/problems/max-area-of-island">See the problem</a>
    /// </summary>
    public int CountBinarySubstrings(string s)
    {
        var count = 0;
        var prev = 0;
        var current = 1;
        
        for (var i = 1; i < s.Length; i++)
        {
            if (s[i] == s[i - 1])
            {
                current++;
            }
            else
            {
                count += Math.Min(prev, current);
                prev = current;
                current = 1;
            }
        }

        return count + Math.Min(prev, current);
    }
}
