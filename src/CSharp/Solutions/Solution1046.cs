using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1046
{
    /// <summary>
    /// 1046. Last Stone Weight - Easy
    /// <a href="https://leetcode.com/problems/last-stone-weight</a>
    /// </summary>
    public int LastStoneWeight(int[] stones)
    {
        var maxHeap = new PriorityQueue<int, int>();

        // Insert all stones as negative values to simulate a Max Heap
        foreach (var stone in stones)
        {
            maxHeap.Enqueue(-stone, -stone);
        }

        while (maxHeap.Count > 1)
        {
            int stone1 = -maxHeap.Dequeue(); // Largest stone
            int stone2 = -maxHeap.Dequeue(); // Second largest stone

            if (stone1 != stone2)
            {
                maxHeap.Enqueue(-(stone1 - stone2), -(stone1 - stone2)); // Insert the difference
            }
        }

        return maxHeap.Count == 1 ? -maxHeap.Dequeue() : 0;
    }
}
