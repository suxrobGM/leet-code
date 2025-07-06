using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1592
{
    /// <summary>
    /// 1592. Rearrange Spaces Between Words - Easy
    /// <a href="https://leetcode.com/problems/rearrange-spaces-between-words">See the problem</a>
    /// </summary>
    public string ReorderSpaces(string text)
    {
        // Count total spaces
        int spaceCount = 0;
        foreach (char c in text)
        {
            if (c == ' ') spaceCount++;
        }

        // Split words (automatically trims and skips multiple spaces)
        var words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int wordCount = words.Length;

        // If only one word, return word + all spaces
        if (wordCount == 1)
        {
            return words[0] + new string(' ', spaceCount);
        }

        // Distribute spaces between words and extra at the end
        int spacesBetween = spaceCount / (wordCount - 1);
        int extraSpaces = spaceCount % (wordCount - 1);

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < wordCount; i++)
        {
            sb.Append(words[i]);
            if (i < wordCount - 1)
            {
                sb.Append(new string(' ', spacesBetween));
            }
        }

        sb.Append(new string(' ', extraSpaces));
        return sb.ToString();
    }
}
