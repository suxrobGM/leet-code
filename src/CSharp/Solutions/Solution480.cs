namespace LeetCode.Solutions;

public class Solution480
{
    /// <summary>
    /// 480. Sliding Window Median - Hard
    /// <a href="https://leetcode.com/problems/sliding-window-median">See the problem</a>
    /// </summary>
    public double[] MedianSlidingWindow(int[] nums, int k)
    {
        var n = nums.Length;
        var medians = new double[n - k + 1];
        var maxHeap = new SortedSet<(int, int)>(Comparer<(int, int)>.Create((a, b) => a.Item1 != b.Item1 ? b.Item1.CompareTo(a.Item1) : a.Item2.CompareTo(b.Item2)));
        var minHeap = new SortedSet<(int, int)>(Comparer<(int, int)>.Create((a, b) => a.Item1 != b.Item1 ? a.Item1.CompareTo(b.Item1) : a.Item2.CompareTo(b.Item2)));

        void balanceHeaps()
        {
            if (maxHeap.Count > minHeap.Count + 1)
            {
                minHeap.Add(maxHeap.Min);
                maxHeap.Remove(maxHeap.Min);
            }
            else if (minHeap.Count > maxHeap.Count)
            {
                maxHeap.Add(minHeap.Min);
                minHeap.Remove(minHeap.Min);
            }
        }

        double getMedian()
        {
            return maxHeap.Count > minHeap.Count ? maxHeap.Min.Item1 : (maxHeap.Min.Item1 + minHeap.Min.Item1) / 2.0;
        }

        for (int i = 0; i < n; i++)
        {
            if (maxHeap.Count == 0 || nums[i] <= maxHeap.Min.Item1)
                maxHeap.Add((nums[i], i));
            else
                minHeap.Add((nums[i], i));

            if (i >= k)
            {
                if (maxHeap.Contains((nums[i - k], i - k)))
                    maxHeap.Remove((nums[i - k], i - k));
                else
                    minHeap.Remove((nums[i - k], i - k));
            }

            balanceHeaps();

            if (i >= k - 1)
            {
                medians[i - k + 1] = getMedian();
            }
        }

        return medians;
    }
}
