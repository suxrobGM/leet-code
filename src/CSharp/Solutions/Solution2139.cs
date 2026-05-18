namespace LeetCode.Solutions;

public class Solution2139
{
    /// <summary>
    /// 2139. Minimum Moves to Reach Target Score - Medium
    /// <a href="https://leetcode.com/problems/minimum-moves-to-reach-target-score">See the problem</a>
    /// </summary>
    public int MinMoves(int target, int maxDoubles)
    {
        int moves = 0;
        while (target > 1)
        {
            if (maxDoubles > 0 && target % 2 == 0)
            {
                target /= 2;
                maxDoubles--;
            }
            else
            {
                target--;
            }
            moves++;
        }
        return moves;
    }
}
