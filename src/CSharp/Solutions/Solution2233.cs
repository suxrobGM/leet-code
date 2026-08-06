namespace LeetCode.Solutions;

public class Solution2233
{
    private const int Modulo = 1_000_000_007;

    /// <summary>
    /// 2233. Maximum Product After K Increments - Medium
    /// <a href="https://leetcode.com/problems/maximum-product-after-k-increments">See the problem</a>
    /// </summary>
    public int MaximumProduct(int[] nums, int k)
    {
        // For a fixed sum, the product is largest when the factors are as close to each
        // other as possible, so every increment should go to the current smallest value.
        var pq = new PriorityQueue<int, int>();
        foreach (var num in nums)
        {
            pq.Enqueue(num, num);
        }

        for (var i = 0; i < k; i++)
        {
            var min = pq.Dequeue() + 1;
            pq.Enqueue(min, min);
        }

        long product = 1;
        while (pq.Count > 0)
        {
            // Reduce on every step: the real product easily exceeds a 64-bit integer.
            product = product * pq.Dequeue() % Modulo;
        }

        return (int)product;
    }
}
