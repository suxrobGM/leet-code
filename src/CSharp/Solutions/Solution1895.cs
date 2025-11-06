using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1895
{
    /// <summary>
    /// 1895. Largest Magic Square - Medium
    /// <a href="https://leetcode.com/problems/largest-magic-square">See the problem</a>
    /// </summary>
    public int LargestMagicSquare(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;

        // Row prefix: rowPref[i][j] = sum of grid[i][0..j-1]
        long[][] rowPref = new long[m][];
        for (int i = 0; i < m; i++)
        {
            rowPref[i] = new long[n + 1];
            for (int j = 0; j < n; j++)
                rowPref[i][j + 1] = rowPref[i][j] + grid[i][j];
        }

        // Col prefix: colPref[i][j] = sum of grid[0..i-1][j]
        long[][] colPref = new long[m + 1][];
        for (int i = 0; i <= m; i++) colPref[i] = new long[n];
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                colPref[i + 1][j] = colPref[i][j] + grid[i][j];

        // Main diagonal prefix (down-right) ending at (i,j)
        long[][] d1 = new long[m][];
        for (int i = 0; i < m; i++) d1[i] = new long[n];
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                d1[i][j] = grid[i][j] + ((i > 0 && j > 0) ? d1[i - 1][j - 1] : 0);

        // Anti-diagonal prefix (down-left) ending at (i,j)
        long[][] d2 = new long[m][];
        for (int i = 0; i < m; i++) d2[i] = new long[n];
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                d2[i][j] = grid[i][j] + ((i > 0 && j + 1 < n) ? d2[i - 1][j + 1] : 0);

        // Helpers
        long RowSum(int r, int c1, int c2Exclusive) => rowPref[r][c2Exclusive] - rowPref[r][c1];
        long ColSum(int c, int r1, int r2Exclusive) => colPref[r2Exclusive][c] - colPref[r1][c];
        long MainDiag(int r, int c, int k)
        {
            int er = r + k - 1, ec = c + k - 1;
            long baseSum = d1[er][ec];
            if (r > 0 && c > 0) baseSum -= d1[r - 1][c - 1];
            return baseSum;
        }
        long AntiDiag(int r, int c, int k)
        {
            // anti-diagonal goes from (r, c+k-1) down-left to (r+k-1, c)
            int er = r + k - 1, ec = c;
            long baseSum = d2[er][ec];
            if (r > 0 && c + k < n) baseSum -= d2[r - 1][c + k];
            return baseSum;
        }

        // Try sizes from largest to smallest
        for (int k = Math.Min(m, n); k >= 1; k--)
        {
            for (int r = 0; r + k <= m; r++)
            {
                for (int c = 0; c + k <= n; c++)
                {
                    long target = MainDiag(r, c, k);
                    if (AntiDiag(r, c, k) != target) continue;

                    bool ok = true;

                    // check rows
                    for (int i = r; i < r + k && ok; i++)
                        if (RowSum(i, c, c + k) != target) ok = false;

                    if (!ok) continue;

                    // check cols
                    for (int j = c; j < c + k && ok; j++)
                        if (ColSum(j, r, r + k) != target) ok = false;

                    if (ok) return k;
                }
            }
        }
        return 1; // at least 1x1 is always magic
    }
}
