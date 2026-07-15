namespace LeetCode.Solutions;

public class Solution2207
{
    /// <summary>
    /// 2207. Maximize Number of Subsequences in a String - Medium
    /// <a href="https://leetcode.com/problems/maximize-number-of-subsequences-in-a-string">See the problem</a>
    /// </summary>
    public long MaximumSubsequenceCount(string text, string pattern)
    {
        var first = pattern[0];
        var second = pattern[1];

        // Adding one character can only help at the extremes: prepending pattern[0]
        // pairs it with every pattern[1] already present, while appending pattern[1]
        // pairs it with every pattern[0]. Take whichever count is larger.
        long countFirst = 0;
        long countSecond = 0;
        long subsequences = 0;

        foreach (var ch in text)
        {
            if (ch == second)
            {
                // Each pattern[1] closes a pair with every pattern[0] seen so far.
                subsequences += countFirst;
                countSecond++;
            }

            if (ch == first)
            {
                countFirst++;
            }
        }

        return subsequences + Math.Max(countFirst, countSecond);
    }
}
