using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1540
{
    /// <summary>
    /// 1540. Can Convert String in K Moves - Medium
    /// <a href="https://leetcode.com/problems/can-convert-string-in-k-moves">See the problem</a>
    /// </summary>
    public bool CanConvertString(string s, string t, int k)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        int[] shifts = new int[26];
        for (int i = 0; i < s.Length; i++)
        {
            int shift = (t[i] - s[i] + 26) % 26;
            shifts[shift]++;
            if (shift > 0 && shifts[shift] > (k / 26) + (k % 26 >= shift ? 1 : 0))
            {
                return false;
            }
        }

        return true;
    }
}
