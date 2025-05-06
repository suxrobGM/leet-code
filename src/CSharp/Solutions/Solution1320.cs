using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1320
{
    private int[][] pos = new int[26][];
    private int[,] memo;
    private string word;

    /// <summary>
    /// 1320. Minimum Distance to Type a Word Using Two Fingers - Hard
    /// <a href="https://leetcode.com/problems/minimum-distance-to-type-a-word-using-two-fingers">See the problem</a>
    /// </summary>
    public int MinimumDistance(string word)
    {
        this.word = word;
        for (int i = 0; i < 26; i++)
            pos[i] = [i / 6, i % 6];

        // 0..25 = A..Z, 26 = undefined
        memo = new int[word.Length, 27 * 27];
        for (int i = 0; i < word.Length; i++)
            for (int j = 0; j < 27 * 27; j++)
                memo[i, j] = -1;

        return Dp(0, 26, 26); // index 0, both fingers unused
    }

    private int Dp(int i, int f1, int f2)
    {
        if (i == word.Length)
            return 0;

        int key = f1 * 27 + f2;
        if (memo[i, key] != -1)
            return memo[i, key];

        int target = word[i] - 'A';

        // Move f1 to target
        int move1 = (f1 == 26 ? 0 : Dist(f1, target)) + Dp(i + 1, target, f2);

        // Move f2 to target
        int move2 = (f2 == 26 ? 0 : Dist(f2, target)) + Dp(i + 1, f1, target);

        return memo[i, key] = Math.Min(move1, move2);
    }

    private int Dist(int a, int b)
    {
        return Math.Abs(pos[a][0] - pos[b][0]) + Math.Abs(pos[a][1] - pos[b][1]);
    }
}
