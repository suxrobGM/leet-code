using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution821
{
    /// <summary>
    /// 821. Shortest Distance to a Character - Easy
    /// <a href="https://leetcode.com/problems/shortest-distance-to-a-character">See the problem</a>
    /// </summary>
    public int[] ShortestToChar(string s, char c)
    {
        var n = s.Length;
        var result = new int[n];
        var prev = int.MinValue / 2;

        for (var i = 0; i < n; i++)
        {
            if (s[i] == c)
            {
                prev = i;
            }

            result[i] = i - prev;
        }

        prev = int.MaxValue / 2;
        for (var i = n - 1; i >= 0; i--)
        {
            if (s[i] == c)
            {
                prev = i;
            }

            result[i] = Math.Min(result[i], prev - i);
        }

        return result;
    }
}
