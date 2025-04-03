using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1191
{
    private const int MOD = 1_000_000_007;

    /// <summary>
    /// 1191. K-Concatenation Maximum Sum - Medium
    /// <a href="https://leetcode.com/problems/k-concatenation-maximum-sum">See the problem</a>
    /// </summary>
    public int KConcatenationMaxSum(int[] arr, int k)
    {
        long maxKadane1 = Kadane(arr);
        if (k == 1) return (int)(maxKadane1 % MOD);

        long totalSum = 0;
        foreach (int num in arr) totalSum += num;

        long maxKadane2 = Kadane(Concat(arr, arr));

        if (totalSum > 0)
        {
            return (int)((maxKadane2 + (k - 2) * totalSum) % MOD);
        }
        else
        {
            return (int)(Math.Max(maxKadane1, maxKadane2) % MOD);
        }
    }

    private long Kadane(int[] arr)
    {
        long maxSoFar = 0, maxEndingHere = 0;
        foreach (int x in arr)
        {
            maxEndingHere = Math.Max(x, maxEndingHere + x);
            maxSoFar = Math.Max(maxSoFar, maxEndingHere);
        }
        return maxSoFar;
    }

    private int[] Concat(int[] a, int[] b)
    {
        var result = new int[a.Length + b.Length];
        Array.Copy(a, 0, result, 0, a.Length);
        Array.Copy(b, 0, result, a.Length, b.Length);
        return result;
    }
}
