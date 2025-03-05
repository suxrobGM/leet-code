using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1048
{
    /// <summary>
    /// 1048. Longest String Chain - Medium
    /// <a href="https://leetcode.com/problems/longest-string-chain</a>
    /// </summary>
    public int LongestStrChain(string[] words)
    {
        var wordSet = new HashSet<string>(words);
        var dp = new Dictionary<string, int>();
        var maxChainLength = 1;

        foreach (var word in words)
        {
            maxChainLength = Math.Max(maxChainLength, DFS(word, wordSet, dp));
        }

        return maxChainLength;
    }

    private int DFS(string word, HashSet<string> wordSet, Dictionary<string, int> dp)
    {
        if (dp.ContainsKey(word))
        {
            return dp[word];
        }

        var maxChainLength = 1;

        for (var i = 0; i < word.Length; i++)
        {
            var nextWord = word.Remove(i, 1);

            if (wordSet.Contains(nextWord))
            {
                maxChainLength = Math.Max(maxChainLength, 1 + DFS(nextWord, wordSet, dp));
            }
        }

        dp[word] = maxChainLength;

        return maxChainLength;
    }
}
