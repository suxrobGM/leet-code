using System.Text;

namespace LeetCode.Solutions;

public class Solution1799
{
    /// <summary>
    /// 1799. Maximize Score After N Operations - Hard
    /// <a href="https://leetcode.com/problems/maximize-score-after-n-operations">See the problem</a>
    /// </summary>
    public int MaxScore(int[] nums)
    {
        int m = nums.Length;
        int maxMask = 1 << m;
        var dp = new int[maxMask];

        // Precompute gcd
        var gcd = new int[m, m];
        for (int i = 0; i < m; i++)
        {
            for (int j = i + 1; j < m; j++)
            {
                gcd[i, j] = Gcd(nums[i], nums[j]);
            }
        }

        for (int mask = 0; mask < maxMask; mask++)
        {
            int bits = CountBits(mask);
            if (bits % 2 != 0) continue; // must be even
            int op = bits / 2 + 1;

            for (int i = 0; i < m; i++)
            {
                if ((mask & (1 << i)) != 0) continue;
                for (int j = i + 1; j < m; j++)
                {
                    if ((mask & (1 << j)) != 0) continue;

                    int newMask = mask | (1 << i) | (1 << j);
                    dp[newMask] = Math.Max(dp[newMask], dp[mask] + op * gcd[i, j]);
                }
            }
        }

        return dp[maxMask - 1];
    }

    private int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int t = a % b;
            a = b;
            b = t;
        }
        return a;
    }

    private int CountBits(int x)
    {
        int count = 0;
        while (x > 0)
        {
            x &= x - 1;
            count++;
        }
        return count;
    }
}

