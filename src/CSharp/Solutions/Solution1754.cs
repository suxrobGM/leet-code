using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1754
{
    /// <summary>
    /// 1754. Largest Merge Of Two Strings - Medium
    /// <a href="https://leetcode.com/problems/largest-merge-of-two-strings">See the problem</a>
    /// </summary>
    public string LargestMerge(string word1, string word2)
    {
        var merge = new StringBuilder();
        int i = 0, j = 0;

        while (i < word1.Length && j < word2.Length)
        {
            if (string.Compare(word1[i..], word2[j..]) > 0)
            {
                merge.Append(word1[i]);
                i++;
            }
            else
            {
                merge.Append(word2[j]);
                j++;
            }
        }

        // Append any remaining characters from either string
        merge.Append(word1.AsSpan(i));
        merge.Append(word2.AsSpan(j));

        return merge.ToString();
    }
}
