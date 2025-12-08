using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1935
{
    /// <summary>
    /// 1935. Maximum Number of Words You Can Type - Easy
    /// <a href="https://leetcode.com/problems/maximum-number-of-words-you-can-type">See the problem</a>
    /// </summary>
    public int CanBeTypedWords(string text, string brokenLetters)
    {
        var brokenSet = new HashSet<char>(brokenLetters);
        var words = text.Split(' ');
        int count = 0;

        foreach (var word in words)
        {
            bool canType = true;
            foreach (var ch in word)
            {
                if (brokenSet.Contains(ch))
                {
                    canType = false;
                    break;
                }
            }
            if (canType)
            {
                count++;
            }
        }

        return count;
    }
}
