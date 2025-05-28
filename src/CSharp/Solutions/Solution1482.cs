using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1482
{
    /// <summary>
    /// 1482. Minimum Number of Days to Make m Bouquets - Medium
    /// <a href="https://leetcode.com/problems/minimum-number-of-days-to-make-m-bouquets">See the problem</a>
    /// </summary>
    public int MinDays(int[] bloomDay, int m, int k)
    {
        long total = (long)m * k;
        if (total > bloomDay.Length)
            return -1;

        int left = bloomDay.Min();
        int right = bloomDay.Max();
        int answer = -1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (CanMake(bloomDay, m, k, mid))
            {
                answer = mid;
                right = mid - 1; // try to minimize
            }
            else
            {
                left = mid + 1;
            }
        }

        return answer;
    }

    private bool CanMake(int[] bloomDay, int m, int k, int day)
    {
        int bouquets = 0, flowers = 0;
        foreach (var bloom in bloomDay)
        {
            if (bloom <= day)
            {
                flowers++;
                if (flowers == k)
                {
                    bouquets++;
                    flowers = 0;
                }
            }
            else
            {
                flowers = 0;
            }
        }
        return bouquets >= m;
    }
}
