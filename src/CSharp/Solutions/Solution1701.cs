using System.Text;


namespace LeetCode.Solutions;

public class Solution1701
{
    /// <summary>
    /// 1701. Average Waiting Time - Medium
    /// <a href="https://leetcode.com/problems/average-waiting-time">See the problem</a>
    /// </summary>
    public double AverageWaitingTime(int[][] customers)
    {
        long cur = 0;         // current time on the chef's clock
        long totalWait = 0;   // sum of all waiting times

        foreach (var c in customers)
        {
            int arrive = c[0];
            int prep = c[1];

            if (cur < arrive) cur = arrive;   // chef idle till the customer arrives
            cur += prep;                       // finish time for this order
            totalWait += cur - arrive;         // waiting time = finish - arrival
        }

        return (double)totalWait / customers.Length;
    }
}
