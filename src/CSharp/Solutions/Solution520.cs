using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution520
{
    /// <summary>
    /// 520. Detect Capital - Easy
    /// <a href="https://leetcode.com/problems/detect-capital">See the problem</a>
    /// </summary>
    public bool DetectCapitalUse(string word)
    {
        var upper = 0;
        var lower = 0;
        foreach (var c in word)
        {
            if (char.IsUpper(c))
            {
                upper++;
            }
            else
            {
                lower++;
            }
        }

        return upper == word.Length || lower == word.Length || (upper == 1 && char.IsUpper(word[0]));
    }
}
