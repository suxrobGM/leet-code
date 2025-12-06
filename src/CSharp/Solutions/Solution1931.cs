using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1931
{
    /// <summary>
    /// 1931. Painting a Grid With Three Different Colors - Hard
    /// <a href="https://leetcode.com/problems/painting-a-grid-with-three-different-colors">See the problem</a>
    /// </summary>
    public int ColorTheGrid(int m, int n)
    {
        const int MOD = 1_000_000_007;

        // Generate all valid row colorings
        var validRows = new List<int>();
        void GenerateRows(int pos, int prevColor, int currRow)
        {
            if (pos == m)
            {
                validRows.Add(currRow);
                return;
            }

            for (int color = 0; color < 3; color++)
            {
                if (color != prevColor)
                {
                    GenerateRows(pos + 1, color, currRow * 3 + color);
                }
            }
        }
        GenerateRows(0, -1, 0);

        // Precompute compatibility between rows
        var compatibility = new Dictionary<int, List<int>>();
        foreach (var row1 in validRows)
        {
            compatibility[row1] = new List<int>();
            foreach (var row2 in validRows)
            {
                bool compatible = true;
                for (int i = 0; i < m; i++)
                {
                    int color1 = (row1 / (int)Math.Pow(3, m - 1 - i)) % 3;
                    int color2 = (row2 / (int)Math.Pow(3, m - 1 - i)) % 3;
                    if (color1 == color2)
                    {
                        compatible = false;
                        break;
                    }
                }
                if (compatible)
                {
                    compatibility[row1].Add(row2);
                }
            }
        }

        // Dynamic programming to count ways to paint the grid
        var dp = new Dictionary<int, long>();
        foreach (var row in validRows)
        {
            dp[row] = 1;
        }

        for (int col = 1; col < n; col++)
        {
            var newDp = new Dictionary<int, long>();
            foreach (var row in validRows)
            {
                newDp[row] = 0;
                foreach (var prevRow in compatibility[row])
                {
                    newDp[row] = (newDp[row] + dp[prevRow]) % MOD;
                }
            }
            dp = newDp;
        }

        long result = 0;
        foreach (var ways in dp.Values)
        {
            result = (result + ways) % MOD;
        }

        return (int)result;
    }
}
