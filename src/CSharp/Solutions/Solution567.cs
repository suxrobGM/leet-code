using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution567
{
    /// <summary>
    /// 567. Permutation in String - Medium
    /// <a href="https://leetcode.com/problems/permutation-in-string">See the problem</a>
    /// </summary>
    public bool CheckInclusion(string s1, string s2)
    {
        var n = s1.Length;
        var m = s2.Length;

        if (n > m)
        {
            return false;
        }

        var s1Count = new int[26];
        var s2Count = new int[26];

        for (var i = 0; i < n; i++)
        {
            s1Count[s1[i] - 'a']++;
            s2Count[s2[i] - 'a']++;
        }

        for (var i = 0; i < m - n; i++)
        {
            if (IsPermutation(s1Count, s2Count))
            {
                return true;
            }

            s2Count[s2[i] - 'a']--;
            s2Count[s2[i + n] - 'a']++;
        }

        return IsPermutation(s1Count, s2Count);
    }

    private bool IsPermutation(int[] s1Count, int[] s2Count)
    {
        for (var i = 0; i < 26; i++)
        {
            if (s1Count[i] != s2Count[i])
            {
                return false;
            }
        }

        return true;
    }
}
