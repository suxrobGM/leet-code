using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1189
{
    /// <summary>
    /// 1189. Maximum Number of Balloons - Easy
    /// <a href="https://leetcode.com/problems/maximum-number-of-balloons">See the problem</a>
    /// </summary>
    public int MaxNumberOfBalloons(string text)
    {
        var charCount = new Dictionary<char, int>();
        foreach (char c in text)
        {
            if (charCount.ContainsKey(c))
                charCount[c]++;
            else
                charCount[c] = 1;
        }

        int b = charCount.ContainsKey('b') ? charCount['b'] : 0;
        int a = charCount.ContainsKey('a') ? charCount['a'] : 0;
        int l = charCount.ContainsKey('l') ? charCount['l'] / 2 : 0;
        int o = charCount.ContainsKey('o') ? charCount['o'] / 2 : 0;
        int n = charCount.ContainsKey('n') ? charCount['n'] : 0;

        return Math.Min(Math.Min(Math.Min(b, a), Math.Min(l, o)), n);
    }
}
