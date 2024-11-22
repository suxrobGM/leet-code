using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution846
{
    /// <summary>
    /// 846. Hand of Straights - Medium
    /// <a href="https://leetcode.com/problems/hand-of-straights">See the problem</a>
    /// </summary>
    public bool IsNStraightHand(int[] hand, int groupSize)
    {
        if (hand.Length % groupSize != 0)
        {
            return false;
        }

        var count = new SortedDictionary<int, int>();
        foreach (int card in hand)
        {
            if (!count.ContainsKey(card))
            {
                count[card] = 0;
            }
            count[card]++;
        }

        while (count.Count > 0)
        {
            int first = count.First().Key;
            for (int card = first; card < first + groupSize; card++)
            {
                if (!count.ContainsKey(card))
                {
                    return false;
                }
                count[card]--;
                if (count[card] == 0)
                {
                    count.Remove(card);
                }
            }
        }

        return true;
    }
}
