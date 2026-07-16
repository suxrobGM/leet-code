namespace LeetCode.Solutions;

public class Solution2208
{
    /// <summary>
    /// 2208. Minimum Operations to Halve Array Sum - Medium
    /// <a href="https://leetcode.com/problems/minimum-operations-to-halve-array-sum">See the problem</a>
    /// </summary>
    public int HalveArray(int[] nums)
    {
        // Greedy: halving the largest value removes the most from the sum,
        // so always pick it. A max-heap keeps the current largest on top.
        var heap = new PriorityQueue<double, double>();
        double sum = 0;

        foreach (var num in nums)
        {
            sum += num;
            heap.Enqueue(num, -num);
        }

        var target = sum / 2;
        double reduced = 0;
        var operations = 0;

        while (reduced < target)
        {
            var half = heap.Dequeue() / 2;
            reduced += half;
            heap.Enqueue(half, -half);
            operations++;
        }

        return operations;
    }
}
