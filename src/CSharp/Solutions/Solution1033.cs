using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1033
{
    /// <summary>
    /// 1033. Moving Stones Until Consecutive - Medium
    /// <a href="https://leetcode.com/problems/moving-stones-until-consecutive</a>
    /// </summary>
    public int[] NumMovesStones(int a, int b, int c)
    {
        int[] stones = { a, b, c };
        Array.Sort(stones);

        int minMoves = 0;
        int maxMoves = stones[2] - stones[0] - 2;

        if (stones[2] - stones[1] == 1 && stones[1] - stones[0] == 1)
        {
            minMoves = 0;
        }
        else if (stones[2] - stones[1] <= 2 || stones[1] - stones[0] <= 2)
        {
            minMoves = 1;
        }
        else
        {
            minMoves = 2;
        }

        return [minMoves, maxMoves];
    }
}
