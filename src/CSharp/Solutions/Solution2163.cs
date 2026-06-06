namespace LeetCode.Solutions;

public class Solution2163
{
    /// <summary>
    /// 2163. Minimum Difference in Sums After Removal of Elements - Hard
    /// <a href="https://leetcode.com/problems/minimum-difference-in-sums-after-removal-of-elements">See the problem</a>
    /// </summary>
    public long MinimumDifference(int[] nums)
    {
        int n = nums.Length, m = n / 3;
        long[] left = new long[n], right = new long[n];
        PriorityQueue<int, int> pq = new();
        long sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += nums[i];
            pq.Enqueue(nums[i], -nums[i]);
            if (pq.Count > m) sum -= pq.Dequeue();
            left[i] = sum;
        }
        pq.Clear();
        sum = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            sum += nums[i];
            pq.Enqueue(nums[i], nums[i]);
            if (pq.Count > m) sum -= pq.Dequeue();
            right[i] = sum;
        }
        long best = long.MaxValue;
        for (int i = m - 1; i < n - m; i++) best = Math.Min(best, left[i] - right[i + 1]);
        return best;
    }
}
