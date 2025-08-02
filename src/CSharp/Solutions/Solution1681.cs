using System.Text;


namespace LeetCode.Solutions;

public class Solution1681
{
    /// <summary>
    /// 1681. Minimum Incompatibility - Hard
    /// <a href="https://leetcode.com/problems/minimum-incompatibility">See the problem</a>
    /// </summary>
    public int MinimumIncompatibility(int[] nums, int k)
    {
        int n = nums.Length;
        int groupSize = n / k;
        int maxMask = 1 << n;
        int[] dp = new int[maxMask];
        Array.Fill(dp, int.MaxValue);
        dp[0] = 0;

        // Precompute all valid subsets of size groupSize and their incompatibility
        Dictionary<int, int> subsetScore = new();

        for (int mask = 0; mask < maxMask; mask++)
        {
            if (CountBits(mask) != groupSize) continue;
            HashSet<int> seen = new();
            List<int> values = new();

            for (int i = 0; i < n; i++)
            {
                if ((mask & (1 << i)) != 0)
                {
                    if (!seen.Add(nums[i]))
                    {
                        values = null;
                        break;
                    }
                    values.Add(nums[i]);
                }
            }

            if (values != null)
            {
                int min = values.Min();
                int max = values.Max();
                subsetScore[mask] = max - min;
            }
        }

        // DP
        for (int mask = 0; mask < maxMask; mask++)
        {
            if (dp[mask] == int.MaxValue) continue;
            int available = ((1 << n) - 1) ^ mask;
            for (int sub = available; sub > 0; sub = (sub - 1) & available)
            {
                if (subsetScore.ContainsKey(sub))
                {
                    dp[mask | sub] = Math.Min(dp[mask | sub], dp[mask] + subsetScore[sub]);
                }
            }
        }

        return dp[maxMask - 1] == int.MaxValue ? -1 : dp[maxMask - 1];
    }

    private int CountBits(int x)
    {
        int count = 0;
        while (x > 0)
        {
            count += x & 1;
            x >>= 1;
        }
        return count;
    }
}
