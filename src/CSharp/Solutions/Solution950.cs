using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution950
{
    /// <summary>
    /// 950. Reveal Cards In Increasing Order - Medium
    /// <a href="https://leetcode.com/problems/reveal-cards-in-increasing-order">See the problem</a>
    /// </summary>
    public int[] DeckRevealedIncreasing(int[] deck)
    {
        // Sort the deck in ascending order
        Array.Sort(deck);

        // Use a queue to simulate the revealing process
        var indexQueue = new Queue<int>();
        for (int i = 0; i < deck.Length; i++)
        {
            indexQueue.Enqueue(i);
        }

        var result = new int[deck.Length];

        foreach (var card in deck)
        {
            // Place the current card at the index from the queue
            result[indexQueue.Dequeue()] = card;

            // If there are still indices in the queue, move the next index to the back
            if (indexQueue.Count > 0)
            {
                indexQueue.Enqueue(indexQueue.Dequeue());
            }
        }

        return result;
    }
}
