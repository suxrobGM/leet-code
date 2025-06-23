using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1569
{
    private const int MOD = 1_000_000_007;
    private long[] fact;
    private long[] invFact;

    /// <summary>
    /// 1569. Number of Ways to Reorder Array to Get Same BST - Hard
    /// <a href="https://leetcode.com/problems/number-of-ways-to-reorder-array-to-get-same-bst">See the problem</a>
    /// </summary>
    public int NumOfWays(int[] nums)
    {
        int n = nums.Length;
        PrecomputeFactorials(n);

        return (int)((DFS(nums.ToList()) - 1 + MOD) % MOD); // subtract 1 to exclude original order
    }

    private long DFS(List<int> nums)
    {
        if (nums.Count <= 2)
            return 1;

        int root = nums[0];
        List<int> left = [], right = [];

        foreach (var num in nums.Skip(1))
        {
            if (num < root) left.Add(num);
            else right.Add(num);
        }

        long leftWays = DFS(left);
        long rightWays = DFS(right);
        long combinations = C(left.Count + right.Count, left.Count);

        return combinations * leftWays % MOD * rightWays % MOD;
    }

    private void PrecomputeFactorials(int n)
    {
        fact = new long[n + 1];
        invFact = new long[n + 1];
        fact[0] = 1;

        for (int i = 1; i <= n; i++)
            fact[i] = fact[i - 1] * i % MOD;

        invFact[n] = ModInverse(fact[n]);
        for (int i = n - 1; i >= 0; i--)
            invFact[i] = invFact[i + 1] * (i + 1) % MOD;
    }

    private long C(int n, int k)
    {
        return fact[n] * invFact[k] % MOD * invFact[n - k] % MOD;
    }

    private long ModInverse(long x) => Pow(x, MOD - 2);

    private long Pow(long x, int y)
    {
        long res = 1;
        x %= MOD;
        while (y > 0)
        {
            if ((y & 1) == 1)
                res = res * x % MOD;
            x = x * x % MOD;
            y >>= 1;
        }
        return res;
    }
}
