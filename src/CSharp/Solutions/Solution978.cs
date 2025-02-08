using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution978
{
    /// <summary>
    /// 978. Longest Turbulent Subarray - Medium
    /// <a href="https://leetcode.com/problems/longest-turbulent-subarray">See the problem</a>
    /// </summary>
    public int MaxTurbulenceSize(int[] arr)
    {
        int n = arr.Length;
        if (n == 1) return 1;

        int maxLen = 1;
        int left = 0;
        int right = 0;

        while (right < n - 1)
        {
            int cmp = Compare(arr[right], arr[right + 1]);

            if (cmp == 0)
            {
                left = right + 1; // Reset window
            }
            else if (right == n - 2 || cmp * Compare(arr[right + 1], arr[right + 2]) != -1)
            {
                maxLen = Math.Max(maxLen, right - left + 2);
                left = right + 1; // Reset window
            }

            right++;
        }

        return maxLen;
    }

    private int Compare(int a, int b)
    {
        return a == b ? 0 : (a > b ? 1 : -1);
    }
}
