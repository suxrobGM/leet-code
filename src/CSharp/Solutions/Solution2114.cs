using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution2114
{
    /// <summary>
    /// 2114. Maximum Number of Words Found in Sentences - Easy
    /// <a href="https://leetcode.com/problems/maximum-number-of-words-found-in-sentences">See the problem</a>
    /// </summary>
    public int MostWordsFound(string[] sentences)
    {
        var max = 0;
        foreach (var sentence in sentences)
        {
            var count = 1;
            foreach (var c in sentence)
            {
                if (c == ' ') count++;
            }
            max = Math.Max(max, count);
        }
        return max;
    }
}
