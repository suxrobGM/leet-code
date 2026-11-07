namespace LeetCode.Solutions;

public class Solution2347
{
    /// <summary>
    /// 2347. Best Poker Hand - Easy
    /// <a href="https://leetcode.com/problems/best-poker-hand">See the problem</a>
    /// </summary>
    public string BestHand(int[] ranks, char[] suits)
    {
        bool isFlush = true;
        for (int i = 1; i < suits.Length; i++)
        {
            if (suits[i] != suits[0])
            {
                isFlush = false;
                break;
            }
        }

        if (isFlush)
            return "Flush";

        int[] counts = new int[14];
        bool hasPair = false;
        foreach (int rank in ranks)
        {
            counts[rank]++;
            if (counts[rank] >= 3)
                return "Three of a Kind";

            if (counts[rank] == 2)
                hasPair = true;
        }

        return hasPair ? "Pair" : "High Card";
    }
}
