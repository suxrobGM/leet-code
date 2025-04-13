using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1240
{
    private int minTiles = int.MaxValue;
    private bool[,] used;

    /// <summary>
    /// 1240. Tiling a Rectangle with the Fewest Squares - Hard
    /// <a href="https://leetcode.com/problems/maximum-length-of-a-concatenated-string-with-unique-characters">See the problem</a>
    /// </summary>
    public int TilingRectangle(int n, int m)
    {
        used = new bool[n, m];
        Dfs(n, m, 0);
        return minTiles;
    }

    private void Dfs(int n, int m, int count)
    {
        if (count >= minTiles)
            return;

        // Find first empty cell (top-left most)
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (!used[i, j])
                {
                    // Try to place squares starting from largest size down to 1
                    for (int size = Math.Min(n - i, m - j); size >= 1; size--)
                    {
                        if (CanPlace(i, j, size, n, m))
                        {
                            Fill(i, j, size, true);
                            Dfs(n, m, count + 1);
                            Fill(i, j, size, false);
                        }
                    }

                    return; // Important: return after first empty cell is processed
                }
            }
        }

        // All cells are filled
        minTiles = Math.Min(minTiles, count);
    }

    private bool CanPlace(int x, int y, int size, int n, int m)
    {
        for (int i = x; i < x + size; i++)
        {
            for (int j = y; j < y + size; j++)
            {
                if (i >= n || j >= m || used[i, j])
                    return false;
            }
        }
        return true;
    }

    private void Fill(int x, int y, int size, bool fill)
    {
        for (int i = x; i < x + size; i++)
        {
            for (int j = y; j < y + size; j++)
            {
                used[i, j] = fill;
            }
        }
    }
}
