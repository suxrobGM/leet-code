using System.Text;

namespace LeetCode.Solutions;

public class Solution1819
{
    /// <summary>
    /// 1819. Number of Different Subsequences GCDs - Hard
    /// <a href="https://leetcode.com/problems/minimum-absolute-sum-difference">See the problem</a>
    /// </summary>
    public int CountDifferentSubsequenceGCDs(int[] nums)
    {
        int max = 0;
        foreach (int x in nums) max = Math.Max(max, x);

        // presence array for fast "is in nums"
        bool[] has = new bool[max + 1];
        foreach (int x in nums) has[x] = true;

        int ans = 0;

        // For each candidate gcd g
        for (int g = 1; g <= max; g++)
        {
            int currGcd = 0;
            // Consider only multiples of g that appear in nums
            for (int m = g; m <= max; m += g)
            {
                if (has[m])
                {
                    currGcd = Gcd(currGcd, m);
                    // Small optimization: if already equals g, no need to continue
                    if (currGcd == g) break;
                }
            }
            if (currGcd == g) ans++;
        }

        return ans;
    }

    private int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int t = a % b;
            a = b;
            b = t;
        }
        return Math.Abs(a);
    }
}
