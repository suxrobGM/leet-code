using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1337
{
    /// <summary>
    /// 1337. The K Weakest Rows in a Matrix - Easy
    /// <a href="https://leetcode.com/problems/the-k-weakest-rows-in-a-matrix">See the problem</a>
    /// </summary>
    public int[] KWeakestRows(int[][] mat, int k)
    {
        int m = mat.Length;
        int n = mat[0].Length;
        var rowStrengths = new List<(int index, int strength)>();

        for (int i = 0; i < m; i++)
        {
            int strength = 0;
            for (int j = 0; j < n; j++)
            {
                if (mat[i][j] == 1)
                    strength++;
                else
                    break;
            }
            rowStrengths.Add((i, strength));
        }

        rowStrengths.Sort((a, b) => a.strength == b.strength ? a.index - b.index : a.strength - b.strength);

        return [.. rowStrengths.Take(k).Select(x => x.index)];
    }
}
