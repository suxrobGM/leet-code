using System.Text;


namespace LeetCode.Solutions;

public class Solution1690
{
    /// <summary>
    /// 1690. Stone Game VII - Medium
    /// <a href="https://leetcode.com/problems/stone-game-vii">See the problem</a>
    /// </summary>
    public int StoneGameVII(int[] stones)
    {
        int n = stones.Length;
        var prefix = new int[n + 1];
        for (int i = 0; i < n; i++)
            prefix[i + 1] = prefix[i] + stones[i];

        var memo = new int[n, n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                memo[i, j] = int.MinValue;

        return Dp(0, n - 1, prefix, memo);
    }

    private int Dp(int i, int j, int[] prefix, int[,] memo)
    {
        if (i == j)
            return 0;
        if (memo[i, j] != int.MinValue)
            return memo[i, j];

        int totalLeft = prefix[j + 1] - prefix[i + 1];
        int totalRight = prefix[j] - prefix[i];

        int takeLeft = totalLeft - Dp(i + 1, j, prefix, memo);
        int takeRight = totalRight - Dp(i, j - 1, prefix, memo);

        return memo[i, j] = Math.Max(takeLeft, takeRight);
    }
}
