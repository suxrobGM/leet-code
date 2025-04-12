using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1235
{
    /// <summary>
    /// 1235. Maximum Profit in Job Scheduling - Hard
    /// <a href="https://leetcode.com/problems/maximum-profit-in-job-scheduling">See the problem</a>
    /// </summary>
    public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
    {
        int n = startTime.Length;
        var jobs = new List<(int start, int end, int profit)>();

        for (int i = 0; i < n; i++)
            jobs.Add((startTime[i], endTime[i], profit[i]));

        // Sort jobs by end time
        jobs.Sort((a, b) => a.end.CompareTo(b.end));

        // DP: list of (endTime, maxProfit)
        var dp = new List<(int end, int profit)>
        {
            (0, 0) // dummy job
        };

        foreach (var job in jobs)
        {
            int start = job.start;
            int end = job.end;
            int p = job.profit;

            // Binary search for the last job that ends <= current start
            int idx = BinarySearch(dp, start);
            int totalProfit = dp[idx].profit + p;

            // Only add to dp if totalProfit improves result
            if (totalProfit > dp[^1].profit)
                dp.Add((end, totalProfit));
        }

        return dp[^1].profit;
    }

    // Find the rightmost job in dp such that dp[i].end <= currentStart
    private int BinarySearch(List<(int end, int profit)> dp, int start)
    {
        int low = 0, high = dp.Count - 1;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            if (dp[mid].end <= start)
                low = mid + 1;
            else
                high = mid - 1;
        }
        return high;
    }
}
