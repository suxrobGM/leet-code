using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1525
{
    /// <summary>
    /// 1525. Number of Good Ways to Split a String - Medium
    /// <a href="https://leetcode.com/problems/number-of-good-ways-to-split-a-string">See the problem</a>
    /// </summary>
    public int NumSplits(string s)
    {
        int n = s.Length;
        int[] prefix = new int[n];
        int[] suffix = new int[n];

        var seenLeft = new HashSet<char>();
        for (int i = 0; i < n; i++)
        {
            seenLeft.Add(s[i]);
            prefix[i] = seenLeft.Count;
        }

        var seenRight = new HashSet<char>();
        for (int i = n - 1; i >= 0; i--)
        {
            seenRight.Add(s[i]);
            suffix[i] = seenRight.Count;
        }

        int count = 0;
        for (int i = 1; i < n; i++)
        {
            if (prefix[i - 1] == suffix[i])
                count++;
        }

        return count;
    }
}
