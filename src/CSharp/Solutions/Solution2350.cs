namespace LeetCode.Solutions;

public class Solution2350
{
    /// <summary>
    /// 2350. Shortest Impossible Sequence of Rolls - Hard
    /// <a href="https://leetcode.com/problems/shortest-impossible-sequence-of-rolls">See the problem</a>
    /// </summary>
    public int ShortestSequence(int[] rolls, int k)
    {
        var seen = new int[k + 1];
        int shortestLength = 1;
        int distinct = 0;

        foreach (int roll in rolls)
        {
            if (seen[roll] == shortestLength)
            {
                continue;
            }

            seen[roll] = shortestLength;
            distinct++;

            if (distinct == k)
            {
                // Each complete set extends the length of every possible subsequence.
                shortestLength++;
                distinct = 0;
                // The new length also marks a fresh set without clearing seen.
            }
        }

        return shortestLength;
    }
}
