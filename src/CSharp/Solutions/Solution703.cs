namespace LeetCode.Solutions;

public class Solution703
{
    /// <summary>
    /// 703. Kth Largest Element in a Stream - Easy
    /// <a href="https://leetcode.com/problems/kth-largest-element-in-a-stream">See the problem</a>
    /// </summary>
    public class KthLargest
    {
        private PriorityQueue<int, int> minHeap = new();
        private int k;

        public KthLargest(int k, int[] nums)
        {
            this.k = k;

            // Initialize the heap with the given scores
            foreach (int num in nums)
            {
                Add(num);
            }
        }

        public int Add(int val)
        {
            // Add the new score to the heap
            minHeap.Enqueue(val, val);

            // If the heap size exceeds k, remove the smallest element
            if (minHeap.Count > k)
            {
                minHeap.Dequeue();
            }

            // The root of the heap is the kth largest element
            return minHeap.Peek();
        }
    }
}
