using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1668
{
    /// <summary>
    /// 1668. Maximum Repeating Substring - Easy
    /// <a href="https://leetcode.com/problems/maximum-repeating-substring">See the problem</a>
    /// </summary>
    public int MaxRepeating(string sequence, string word)
    {
        int k = 0;
        string repeated = word;

        while (sequence.Contains(repeated))
        {
            k++;
            repeated += word;
        }

        return k;
    }
}
