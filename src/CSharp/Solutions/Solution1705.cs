using System.Text;


namespace LeetCode.Solutions;

public class Solution1705
{
    /// <summary>
    /// 1705. Maximum Number of Eaten Apples - Medium
    /// <a href="https://leetcode.com/problems/maximum-number-of-eaten-apples">See the problem</a>
    /// </summary>
    public int MaxEatenApples(int[] apples, int[] days)
    {
        int n = apples.Length;
        long eaten = 0;
        int day = 0;

        // (expire, count) prioritized by expire (smallest first)
        var pq = new PriorityQueue<(int expire, int count), int>();

        while (day < n || pq.Count > 0)
        {
            // If still within given days, add today's batch
            if (day < n && apples[day] > 0 && days[day] > 0)
            {
                int expire = day + days[day];
                pq.Enqueue((expire, apples[day]), expire);
            }

            // Remove expired or empty batches
            while (pq.Count > 0 && (pq.Peek().expire <= day || pq.Peek().count <= 0))
                pq.Dequeue();

            // Eat one apple from the batch expiring soonest
            if (pq.Count > 0)
            {
                var top = pq.Dequeue();
                eaten++;
                if (top.count - 1 > 0)
                {
                    pq.Enqueue((top.expire, top.count - 1), top.expire);
                }
            }

            day++;
        }

        return (int)eaten;
    }
}
