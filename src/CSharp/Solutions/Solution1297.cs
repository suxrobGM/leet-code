using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1297
{
    /// <summary>
    /// 1297. Maximum Number of Occurrences of a Substring - Medium
    /// <a href="https://leetcode.com/problems/maximum-number-of-occurrences-of-a-substring">See the problem</a>
    /// </summary>
    public int MaxFreq(string s, int maxLetters, int minSize, int maxSize)
    {
        var count = new Dictionary<string, int>();
        int maxCount = 0;

        for (int size = minSize; size <= maxSize; size++)
        {
            for (int i = 0; i <= s.Length - size; i++)
            {
                string substring = s.Substring(i, size);
                if (substring.Distinct().Count() > maxLetters) continue;

                if (!count.ContainsKey(substring))
                {
                    count[substring] = 0;
                }
                count[substring]++;
                maxCount = Math.Max(maxCount, count[substring]);
            }
        }

        return maxCount;
    }
}
