using System.Text;


namespace LeetCode.Solutions;

public class Solution1686
{
    /// <summary>
    /// 1686. Stone Game VI - Medium
    /// <a href="https://leetcode.com/problems/stone-game-vi">See the problem</a>
    /// </summary>
    public int StoneGameVI(int[] aliceValues, int[] bobValues)
    {
        int n = aliceValues.Length;

        // Pair index with total value and sort
        var stones = new (int index, int priority)[n];
        for (int i = 0; i < n; i++)
        {
            stones[i] = (i, aliceValues[i] + bobValues[i]);
        }

        Array.Sort(stones, (a, b) => b.priority.CompareTo(a.priority));

        int aliceScore = 0, bobScore = 0;
        for (int i = 0; i < n; i++)
        {
            int idx = stones[i].index;
            if (i % 2 == 0)
                aliceScore += aliceValues[idx];
            else
                bobScore += bobValues[idx];
        }

        if (aliceScore > bobScore) return 1;
        if (bobScore > aliceScore) return -1;
        return 0;
    }
}
