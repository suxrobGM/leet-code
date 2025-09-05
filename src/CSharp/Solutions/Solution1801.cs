using System.Text;

namespace LeetCode.Solutions;

public class Solution1801
{
    /// <summary>
    /// 1801. Number of Orders in the Backlog - Medium
    /// <a href="https://leetcode.com/problems/number-of-orders-in-the-backlog">See the problem</a>
    /// </summary>
    public int GetNumberOfBacklogOrders(int[][] orders)
    {
        const int MOD = 1000000007;

        // min-heap for sell orders (price asc)
        var sellPQ = new PriorityQueue<(int price, long amount), int>();
        // max-heap for buy orders (price desc)
        var buyPQ = new PriorityQueue<(int price, long amount), int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

        foreach (var o in orders)
        {
            int price = o[0], amount = o[1], type = o[2];
            long amt = amount;

            if (type == 0)
            {
                // Buy order
                while (amt > 0 && sellPQ.Count > 0 && sellPQ.Peek().price <= price)
                {
                    var (sp, sa) = sellPQ.Dequeue();
                    long used = Math.Min(amt, sa);
                    amt -= used;
                    sa -= used;
                    if (sa > 0) sellPQ.Enqueue((sp, sa), sp);
                }
                if (amt > 0) buyPQ.Enqueue((price, amt), price);
            }
            else
            {
                // Sell order
                while (amt > 0 && buyPQ.Count > 0 && buyPQ.Peek().price >= price)
                {
                    var (bp, ba) = buyPQ.Dequeue();
                    long used = Math.Min(amt, ba);
                    amt -= used;
                    ba -= used;
                    if (ba > 0) buyPQ.Enqueue((bp, ba), bp);
                }
                if (amt > 0) sellPQ.Enqueue((price, amt), price);
            }
        }

        long result = 0;
        while (buyPQ.Count > 0) result = (result + buyPQ.Dequeue().amount) % MOD;
        while (sellPQ.Count > 0) result = (result + sellPQ.Dequeue().amount) % MOD;

        return (int)(result % MOD);
    }
}

