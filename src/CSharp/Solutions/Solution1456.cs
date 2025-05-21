using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1456
{
    /// <summary>
    /// 1456. Maximum Number of Vowels in a Substring of Given Length - Medium
    /// <a href="https://leetcode.com/problems/maximum-number-of-vowels-in-a-substring-of-given-length">See the problem</a>
    /// </summary>
    public int MaxVowels(string s, int k)
    {
        // Define a set of vowels for quick lookup
        var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };

        int maxVowels = 0;
        int currentVowels = 0;

        // Count the number of vowels in the first window of size k
        for (int i = 0; i < k; i++)
        {
            if (vowels.Contains(s[i]))
            {
                currentVowels++;
            }
        }

        maxVowels = currentVowels;

        // Slide the window across the string
        for (int i = k; i < s.Length; i++)
        {
            // Remove the character going out of the window
            if (vowels.Contains(s[i - k]))
            {
                currentVowels--;
            }

            // Add the new character coming into the window
            if (vowels.Contains(s[i]))
            {
                currentVowels++;
            }

            // Update maxVowels if needed
            maxVowels = Math.Max(maxVowels, currentVowels);
        }

        return maxVowels;
    }
}
