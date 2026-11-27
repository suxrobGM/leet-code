namespace LeetCode.Solutions;

public class Solution2370
{
    /// <summary>
    /// 2370. Longest Ideal Subsequence - Medium
    /// <a href="https://leetcode.com/problems/longest-ideal-subsequence">See the problem</a>
    /// </summary>
    public int LongestIdealString(string s, int k)
    {
        // Track the longest ideal subsequence ending with each letter.
        int[] bestEndingAt = new int[26];
        int longest = 0;

        foreach (char letter in s)
        {
            int index = letter - 'a';
            int first = Math.Max(0, index - k);
            int last = Math.Min(bestEndingAt.Length - 1, index + k);
            int bestPrevious = 0;

            for (int previous = first; previous <= last; previous++)
            {
                bestPrevious = Math.Max(bestPrevious, bestEndingAt[previous]);
            }

            bestEndingAt[index] = bestPrevious + 1;
            longest = Math.Max(longest, bestEndingAt[index]);
        }

        return longest;
    }
}
