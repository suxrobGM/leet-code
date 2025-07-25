using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1659
{
    /// <summary>
    /// 1659. Maximize Grid Happiness - Hard
    /// <a href="https://leetcode.com/problems/maximize-grid-happiness">See the problem</a>
    /// </summary>
    public int GetMaxGridHappiness(int m, int n, int introvertsCount, int extrovertsCount)
    {
        int S = (int)Math.Pow(3, n);

        // helpers indexed by mask
        var introInRow = new int[S];
        var extroInRow = new int[S];
        var rowScore = new int[S];
        var crossScore = new int[S, S];

        int[] pow3 = new int[n + 1];
        pow3[0] = 1;
        for (int i = 1; i <= n; ++i) pow3[i] = pow3[i - 1] * 3;

        //------------------------------------------------------------
        // 1) enumerate every single row
        //------------------------------------------------------------
        for (int mask = 0; mask < S; ++mask)
        {
            int tmp = mask;
            int score = 0;
            for (int c = 0; c < n; ++c)
            {
                int cell = tmp % 3;          // 0 = empty, 1 = introvert, 2 = extrovert
                tmp /= 3;

                if (cell == 1) introInRow[mask]++;
                else if (cell == 2) extroInRow[mask]++;

                if (c > 0)          // left neighbour (same row)
                {
                    int left = (mask / pow3[c - 1]) % 3;
                    if (cell == 1) score -= 30;      // this introvert loses 30
                    if (left == 1) score -= 30;

                    if (cell == 2) score += 20;      // this extrovert gains 20
                    if (left == 2) score += 20;
                }

                // base happiness of the person itself
                if (cell == 1) score += 120;
                else if (cell == 2) score += 40;
            }
            rowScore[mask] = score;
        }

        //------------------------------------------------------------
        // 2) between-row interaction
        //------------------------------------------------------------
        for (int prev = 0; prev < S; ++prev)
            for (int cur = 0; cur < S; ++cur)
            {
                int add = 0;
                for (int c = 0; c < n; ++c)
                {
                    int a = (prev / pow3[c]) % 3;
                    int b = (cur / pow3[c]) % 3;
                    if (a == 0 || b == 0) continue;

                    if (a == 1) add -= 30;
                    if (a == 2) add += 20;
                    if (b == 1) add -= 30;
                    if (b == 2) add += 20;
                }
                crossScore[prev, cur] = add;
            }

        //------------------------------------------------------------
        // 3) DP over rows
        //------------------------------------------------------------
        // dp[rowParity, mask, p, q]
        const int MAXP = 6, MAXQ = 6;
        int[,,,] dp = new int[2, S, MAXP + 1, MAXQ + 1];
        for (int i = 0; i < 2; ++i)
            for (int j = 0; j < S; ++j)
                for (int p = 0; p <= MAXP; ++p)
                    for (int q = 0; q <= MAXQ; ++q)
                        dp[i, j, p, q] = int.MinValue / 2;   // negative infinity

        dp[0, 0, introvertsCount, extrovertsCount] = 0;

        for (int r = 0; r < m; ++r)
        {
            int curRow = (r + 1) & 1;
            int prevRow = r & 1;

            // reset next layer
            for (int j = 0; j < S; ++j)
                for (int p = 0; p <= introvertsCount; ++p)
                    for (int q = 0; q <= extrovertsCount; ++q)
                        dp[curRow, j, p, q] = int.MinValue / 2;

            for (int prevMask = 0; prevMask < S; ++prevMask)
                for (int p = 0; p <= introvertsCount; ++p)
                    for (int q = 0; q <= extrovertsCount; ++q)
                    {
                        int curVal = dp[prevRow, prevMask, p, q];
                        if (curVal == int.MinValue / 2) continue;

                        // Try every possible current row
                        for (int curMask = 0; curMask < S; ++curMask)
                        {
                            int needI = introInRow[curMask];
                            int needE = extroInRow[curMask];
                            if (needI > p || needE > q) continue;

                            int np = p - needI;
                            int nq = q - needE;

                            int val = curVal + rowScore[curMask] +
                                      crossScore[prevMask, curMask];

                            if (val > dp[curRow, curMask, np, nq])
                                dp[curRow, curMask, np, nq] = val;
                        }
                    }
        }

        //------------------------------------------------------------
        // result = best among last layer
        //------------------------------------------------------------
        int best = 0;
        int last = m & 1;
        for (int mask = 0; mask < S; ++mask)
            for (int p = 0; p <= introvertsCount; ++p)
                for (int q = 0; q <= extrovertsCount; ++q)
                    best = Math.Max(best, dp[last, mask, p, q]);

        return best;
    }
}
