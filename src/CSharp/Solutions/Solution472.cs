namespace LeetCode.Solutions;

public class Solution472
{
    /// <summary>
    /// 472. Concatenated Words - Hard
    /// <a href="https://leetcode.com/problems/concatenated-words">See the problem</a>
    /// </summary>
    public IList<string> FindAllConcatenatedWordsInADict(string[] words)
    {
        // Use a HashSet for quick lookup
        var wordSet = new HashSet<string>(words);
        var result = new List<string>();

        foreach (string word in words)
        {
            if (IsConcatenatedWord(word, wordSet))
            {
                result.Add(word);
            }
        }

        return result;
    }

    private bool IsConcatenatedWord(string word, HashSet<string> wordSet) {
        var len = word.Length;
        
        if (len == 0)
        {
            return false;
        }

        // Dynamic programming array
        var dp = new bool[len + 1];
        dp[0] = true; // Base case: an empty prefix is a valid "concatenation"

        // Iterate through the word, trying to form valid words
        for (int i = 1; i <= len; i++)
        {
            for (int j = (i == len ? 1 : 0); j < i; j++)
            {
                if (dp[j] && wordSet.Contains(word.Substring(j, i - j)))
                {
                    dp[i] = true;
                    break;
                }
            }
        }

        // The entire word can be formed by concatenating other words
        return dp[len] && len > 0;
    }
}
