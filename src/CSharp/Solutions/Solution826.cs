using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution826
{
    /// <summary>
    /// 826. Most Profit Assigning Work - Medium
    /// <a href="https://leetcode.com/problems/most-profit-assigning-work">See the problem</a>
    /// </summary>
    public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker)
    {
        var n = difficulty.Length;
        var jobs = new Job[n];
        for (var i = 0; i < n; i++)
        {
            jobs[i] = new Job(difficulty[i], profit[i]);
        }

        Array.Sort(jobs, (a, b) => a.Difficulty - b.Difficulty);
        Array.Sort(worker);

        var result = 0;
        var maxProfit = 0;
        var j = 0;
        for (var i = 0; i < worker.Length; i++)
        {
            while (j < n && jobs[j].Difficulty <= worker[i])
            {
                maxProfit = Math.Max(maxProfit, jobs[j++].Profit);
            }

            result += maxProfit;
        }

        return result;
    }

    private class Job(int difficulty, int profit)
    {
        public int Difficulty { get; } = difficulty;
        public int Profit { get; } = profit;
    }
}
