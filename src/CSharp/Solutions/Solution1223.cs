using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1223
{
    /// <summary>
    /// 1223. Dice Roll Simulation - Hard
    /// <a href="https://leetcode.com/problems/dice-roll-simulation">See the problem</a>
    /// </summary>
    public int DieSimulator(int n, int[] rollMax)
    {
        const int MOD = 1000000007;
        var dpPrev = new int[6, 16];
        var dpCurr = new int[6, 16];

        // Base case: 1 roll, each face once
        for (int j = 0; j < 6; j++)
        {
            dpPrev[j, 1] = 1;
        }

        for (int i = 2; i <= n; i++)
        {
            Array.Clear(dpCurr, 0, dpCurr.Length);

            for (int j = 0; j < 6; j++) // current face
            {
                for (int p = 0; p < 6; p++) // previous face
                {
                    if (j == p)
                    {
                        for (int k = 1; k < rollMax[j]; k++)
                        {
                            dpCurr[j, k + 1] = (dpCurr[j, k + 1] + dpPrev[j, k]) % MOD;
                        }
                    }
                    else
                    {
                        for (int k = 1; k <= rollMax[p]; k++)
                        {
                            dpCurr[j, 1] = (dpCurr[j, 1] + dpPrev[p, k]) % MOD;
                        }
                    }
                }
            }

            // Swap current with previous
            (dpCurr, dpPrev) = (dpPrev, dpCurr);
        }

        // Sum all dp[n][j][k]
        int result = 0;
        for (int j = 0; j < 6; j++)
        {
            for (int k = 1; k <= rollMax[j]; k++)
            {
                result = (result + dpPrev[j, k]) % MOD;
            }
        }

        return result;
    }
}
