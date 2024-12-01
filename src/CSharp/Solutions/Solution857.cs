using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution857
{
    /// <summary>
    /// 857. Minimum Cost to Hire K Workers - Hard
    /// <a href="https://leetcode.com/problems/minimum-cost-to-hire-k-workers">See the problem</a>
    /// </summary>
    public double MincostToHireWorkers(int[] quality, int[] wage, int k)
    {
        int n = quality.Length;
        var workers = new List<(double ratio, int quality)>();

        // Compute the wage-to-quality ratio for each worker
        for (int i = 0; i < n; i++)
        {
            double ratio = (double)wage[i] / quality[i];
            workers.Add((ratio, quality[i]));
        }

        // Sort workers by their ratio
        workers.Sort((a, b) => a.ratio.CompareTo(b.ratio));

        // Use a max-heap to maintain the k smallest qualities
        var maxHeap = new PriorityQueue<int, int>();
        int totalQuality = 0;
        var minCost = double.MaxValue;

        // Iterate over the workers
        foreach (var (ratio, q) in workers)
        {
            // Add the current worker's quality to the heap
            totalQuality += q;
            maxHeap.Enqueue(q, -q); // Use negative to simulate max-heap

            // If the heap size exceeds k, remove the largest quality
            if (maxHeap.Count > k)
            {
                totalQuality -= maxHeap.Dequeue();
            }

            // If we have exactly k workers, calculate the cost
            if (maxHeap.Count == k)
            {
                double cost = ratio * totalQuality;
                minCost = Math.Min(minCost, cost);
            }
        }

        return minCost;
    }
}
