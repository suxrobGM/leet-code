using System.Text;

namespace LeetCode.Solutions;

public class Solution1784
{
    /// <summary>
    /// 1784. Check if Binary String Has at Most One Segment of Ones - Easy
    /// <a href="https://leetcode.com/problems/check-if-binary-string-has-at-most-one-segment-of-ones">See the problem</a>
    /// </summary>
    public bool CheckOnesSegment(string s)
    {
        // Find the first '0' in the string
        int zeroIndex = s.IndexOf('0');
        // If there's no '0', the string is all '1's
        if (zeroIndex == -1) return true;

        // Check if there's another '1' after the first '0'
        for (int i = zeroIndex + 1; i < s.Length; i++)
        {
            if (s[i] == '1') return false;
        }

        return true;
    }
}
