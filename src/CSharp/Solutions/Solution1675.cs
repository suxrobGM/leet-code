using System.Text;


namespace LeetCode.Solutions;

public class Solution1675
{
    /// <summary>
    /// 1675. Minimize Deviation in Array - Hard
    /// <a href="https://leetcode.com/problems/minimize-deviation-in-array">See the problem</a>
    /// </summary>
    public int MinimumDeviation(int[] nums)
    {
        var maxHeap = new PriorityQueue<int, int>(); // value, -priority for max heap
        int minVal = int.MaxValue;

        // Step 1: Normalize - make all numbers even
        foreach (int num in nums)
        {
            int val = num % 2 == 1 ? num * 2 : num;
            maxHeap.Enqueue(val, -val);
            minVal = Math.Min(minVal, val);
        }

        int minDeviation = int.MaxValue;

        // Step 2: Continuously reduce the max element if possible
        while (maxHeap.Count > 0)
        {
            int maxVal = maxHeap.Dequeue();
            minDeviation = Math.Min(minDeviation, maxVal - minVal);

            // If max is even, we can reduce it
            if (maxVal % 2 == 0)
            {
                int newVal = maxVal / 2;
                maxHeap.Enqueue(newVal, -newVal);
                minVal = Math.Min(minVal, newVal);
            }
            else
            {
                break; // Cannot reduce further
            }
        }

        return minDeviation;
    }
}
