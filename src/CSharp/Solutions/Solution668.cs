using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution668
{
    /// <summary>
    /// 668. Kth Smallest Number in Multiplication Table - Hard
    /// <a href="https://leetcode.com/problems/kth-smallest-number-in-multiplication-table">See the problem</a>
    /// </summary>
    public int FindKthNumber(int m, int n, int k)
    {
        int left = 1;
        int right = m * n;

        while (left < right)
        {
            int mid = left + (right - left) / 2;
            int count = 0;

            for (int i = 1; i <= m; i++)
            {
                count += Math.Min(mid / i, n);
            }

            if (count < k)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return left;
    }
}
