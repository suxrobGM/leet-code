namespace LeetCode.Solutions;

public class Solution2260
{
    /// <summary>
    /// 2260. Minimum Consecutive Cards to Pick Up - Medium
    /// <a href="https://leetcode.com/problems/minimum-consecutive-cards-to-pick-up">See the problem</a>
    /// </summary>
    public int MinimumCardPickup(int[] cards)
    {
        var lastIndices = new Dictionary<int, int>();
        var shortest = int.MaxValue;

        for (var index = 0; index < cards.Length; index++)
        {
            // The closest matching pair for a card is always its previous occurrence,
            // so tracking the latest index of each value is enough.
            if (lastIndices.TryGetValue(cards[index], out var previous))
            {
                shortest = Math.Min(shortest, index - previous + 1);
            }

            lastIndices[cards[index]] = index;
        }

        return shortest == int.MaxValue ? -1 : shortest;
    }
}
