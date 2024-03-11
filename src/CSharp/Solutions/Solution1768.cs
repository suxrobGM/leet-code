using System.Text;

namespace LeetCode.Solutions;

public class Solution1768
{
    /// <summary>
    /// 1768. Merge Strings Alternately - Easy
    /// <a href="https://leetcode.com/problems/merge-strings-alternately">See the problem</a>
    /// </summary>
    public string MergeAlternately(string word1, string word2)
    {
        var i = 0;
        var strBuilder = new StringBuilder();
        
        // Append the first i characters from each string
        while (i < word1.Length && i < word2.Length)
        {
            strBuilder.Append(word1[i]);
            strBuilder.Append(word2[i]);
            i++;
        }

        // Append the rest of the longer string
        for (var j = i; j < word2.Length; j++)
        {
            strBuilder.Append(word2[j]);
        }
        
        for (var j = i; j < word1.Length; j++)
        {
            strBuilder.Append(word1[j]);
        }
        
        return strBuilder.ToString();
    }
}
