using System.Text;

namespace LeetCode.Solutions;

public class Solution1839
{
    /// <summary>
    /// 1839. Longest Substring Of All Vowels in Order - Medium
    /// <a href="https://leetcode.com/problems/longest-substring-of-all-vowels-in-order">See the problem</a>
    /// </summary>
    public int LongestBeautifulSubstring(string word)
    {
        int maxLength = 0;
        int currentLength = 1;
        int vowelCount = 1; // Count of distinct vowels in the current substring
        //string vowels = "aeiou";

        for (int i = 1; i < word.Length; i++)
        {
            if (word[i] >= word[i - 1])
            {
                currentLength++;
                if (word[i] != word[i - 1])
                {
                    vowelCount++;
                }
            }
            else
            {
                if (vowelCount == 5)
                {
                    maxLength = Math.Max(maxLength, currentLength);
                }
                currentLength = 1;
                vowelCount = 1;
            }
        }

        if (vowelCount == 5)
        {
            maxLength = Math.Max(maxLength, currentLength);
        }

        return maxLength;
    }
}
