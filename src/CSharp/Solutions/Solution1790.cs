using System.Text;

namespace LeetCode.Solutions;

public class Solution1790
{
    /// <summary>
    /// 1790. Check if One String Swap Can Make Strings Equal - Easy
    /// <a href="https://leetcode.com/problems/check-if-one-string-swap-can-make-strings-equal">See the problem</a>
    /// </summary>
    public bool AreAlmostEqual(string s1, string s2)
    {
        if (s1.Length != s2.Length) return false;

        int[] diff = new int[2];
        for (int i = 0; i < s1.Length; i++)
        {
            if (s1[i] != s2[i])
            {
                if (diff[0] == 0)
                {
                    diff[0] = i + 1;
                }
                else if (diff[1] == 0)
                {
                    diff[1] = i + 1;
                }
                else
                {
                    return false;
                }
            }
        }

        if (diff[0] == 0) return true; // Strings are already equal
        if (diff[1] == 0) return false; // Only one difference found

        // Check if swapping the differing characters makes the strings equal
        return s1[diff[0] - 1] == s2[diff[1] - 1] && s1[diff[1] - 1] == s2[diff[0] - 1];
    }
}

