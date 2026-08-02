namespace LeetCode.Solutions;

public class Solution2226
{
    /// <summary>
    /// 2226. Maximum Candies Allocated to K Children - Medium
    /// <a href="https://leetcode.com/problems/maximum-candies-allocated-to-k-children">See the problem</a>
    /// </summary>
    public int MaximumCandies(int[] candies, long k)
    {
        long total = 0;
        int max = 0;

        foreach (var candy in candies)
        {
            total += candy;
            max = Math.Max(max, candy);
        }

        if (total < k)
            return 0;

        int low = 1;
        int high = max;
        int result = 0;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            long children = 0;

            foreach (var candy in candies)
                children += candy / mid;

            if (children >= k)
            {
                result = mid;
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return result;
    }
}
