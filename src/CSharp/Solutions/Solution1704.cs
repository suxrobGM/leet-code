using System.Text;


namespace LeetCode.Solutions;

public class Solution1704
{
    /// <summary>
    /// 1704. Determine if String Halves Are Alike - Easy
    /// <a href="https://leetcode.com/problems/determine-if-string-halves-are-alike">See the problem</a>
    /// </summary>
    public bool HalvesAreAlike(string s)
    {
        int n = s.Length;
        int leftVowels = 0, rightVowels = 0;

        for (int i = 0; i < n / 2; i++)
        {
            if (IsVowel(s[i])) leftVowels++;
            if (IsVowel(s[n - 1 - i])) rightVowels++;
        }

        return leftVowels == rightVowels;
    }

    private static bool IsVowel(char c)
    {
        return "aeiouAEIOU".Contains(c);
    }
}
