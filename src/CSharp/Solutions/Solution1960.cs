using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1960
{
    /// <summary>
    /// 1960. Maximum Product of the Length of Two Palindromic Substrings - Hard
    /// <a href="https://leetcode.com/problems/maximum-product-of-the-length-of-two-palindromic-substrings">See the problem</a>
    /// </summary>
    public long MaxProduct(string s)
    {
        int n = s.Length;

        // maxLeftPalin[i] = length of longest odd-length palindrome in s[0...i]
        int[] maxLeftPalin = new int[n];

        // maxRightPalin[i] = length of longest odd-length palindrome in s[i...n-1]
        int[] maxRightPalin = new int[n];

        // Compute maxLeftPalin by expanding around each center from left to right
        int currentMax = 0;
        for (int center = 0; center < n; center++)
        {
            // Expand around odd-length palindrome centered at 'center'
            int left = center, right = center;
            while (left >= 0 && right < n && s[left] == s[right])
            {
                int length = right - left + 1;
                currentMax = Math.Max(currentMax, length);
                left--;
                right++;
            }
            maxLeftPalin[center] = currentMax;
        }

        // Compute maxRightPalin by expanding around each center from right to left
        currentMax = 0;
        for (int center = n - 1; center >= 0; center--)
        {
            // Expand around odd-length palindrome centered at 'center'
            int left = center, right = center;
            while (left >= 0 && right < n && s[left] == s[right])
            {
                int length = right - left + 1;
                currentMax = Math.Max(currentMax, length);
                left--;
                right++;
            }
            maxRightPalin[center] = currentMax;
        }

        // Find maximum product by trying all possible split points
        // Split point at i means: first palindrome ends at or before i, second starts at i+1
        long maxProduct = 0;
        for (int i = 0; i < n - 1; i++)
        {
            long product = (long)maxLeftPalin[i] * maxRightPalin[i + 1];
            maxProduct = Math.Max(maxProduct, product);
        }

        return maxProduct;
    }
}
