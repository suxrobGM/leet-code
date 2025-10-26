using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1880
{
    /// <summary>
    /// 1880. Check if Word Equals Summation of Two Words - Easy
    /// <a href="https://leetcode.com/problems/check-if-word-equals-summation-of-two-words">See the problem</a>
    /// </summary>
    public bool IsSumEqual(string firstWord, string secondWord, string targetWord)
    {
        int firstVal = WordToNumber(firstWord);
        int secondVal = WordToNumber(secondWord);
        int targetVal = WordToNumber(targetWord);
        return firstVal + secondVal == targetVal;
    }

    private int WordToNumber(string word)
    {
        int val = 0;
        foreach (char c in word)
        {
            val = val * 10 + (c - 'a');
        }
        return val;
    }
}
