using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution848
{
    /// <summary>
    /// 848. Shifting Letters - Medium
    /// <a href="https://leetcode.com/problems/shifting-letters">See the problem</a>
    /// </summary>
    public string ShiftingLetters(string s, int[] shifts)
    {
        var n = s.Length;
        var totalShifts = 0;
        var sb = new StringBuilder(n);

        for (var i = n - 1; i >= 0; i--)
        {
            totalShifts = (totalShifts + shifts[i]) % 26;
            sb.Append((char)((s[i] - 'a' + totalShifts) % 26 + 'a'));
        }

        return string.Concat(sb.ToString().Reverse());
    }
}
