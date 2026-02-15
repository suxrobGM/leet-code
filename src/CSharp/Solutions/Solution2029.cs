namespace LeetCode.Solutions;

public class Solution2029
{
    /// <summary>
    /// 2029. Stone Game IX - Medium
    /// <a href="https://leetcode.com/problems/stone-game-ix">See the problem</a>
    /// </summary>
    public bool StoneGameIX(int[] stones)
    {
        var count = new int[3];
        foreach (var stone in stones)
            count[stone % 3]++;

        if (count[0] % 2 == 0)
            return count[1] > 0 && count[2] > 0;

        return Math.Abs(count[1] - count[2]) > 2;
    }
}
