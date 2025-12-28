using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1962
{
    /// <summary>
    /// 1962. Remove Stones to Minimize the Total - Medium
    /// <a href="https://leetcode.com/problems/remove-stones-to-minimize-the-total">See the problem</a>
    /// </summary>
    public int MinStoneSum(int[] piles, int k)
    {
        var maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));
        foreach (var pile in piles)
        {
            maxHeap.Enqueue(pile, pile);
        }

        for (int i = 0; i < k; i++)
        {
            var largestPile = maxHeap.Dequeue();
            var stonesToRemove = largestPile / 2;
            var newPileSize = largestPile - stonesToRemove;
            maxHeap.Enqueue(newPileSize, newPileSize);
        }

        var totalStones = 0;
        while (maxHeap.Count > 0)
        {
            totalStones += maxHeap.Dequeue();
        }

        return totalStones;
    }
}
