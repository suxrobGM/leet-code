namespace LeetCode.Solutions;

public class Solution2217
{
    /// <summary>
    /// 2217. Find Palindrome With Fixed Length - Medium
    /// <a href="https://leetcode.com/problems/find-palindrome-with-fixed-length">See the problem</a>
    /// </summary>
    public long[] KthPalindrome(int[] queries, int intLength)
    {
        int halfLength = (intLength + 1) / 2;
        long start = (long)Math.Pow(10, halfLength - 1);
        long count = start * 9;
        var result = new long[queries.Length];

        for (int i = 0; i < queries.Length; i++)
        {
            if (queries[i] > count)
            {
                result[i] = -1;
                continue;
            }

            long half = start + queries[i] - 1;
            long palindrome = half;

            // Mirror the half, skipping its last digit when the length is odd.
            long rest = intLength % 2 == 0 ? half : half / 10;

            while (rest > 0)
            {
                palindrome = palindrome * 10 + rest % 10;
                rest /= 10;
            }

            result[i] = palindrome;
        }

        return result;
    }
}
