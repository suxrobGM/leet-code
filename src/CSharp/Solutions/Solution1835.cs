using System.Text;

namespace LeetCode.Solutions;

public class Solution1835
{
    /// <summary>
    /// 1835. Find XOR Sum of All Pairs Bitwise AND - Hard
    /// <a href="https://leetcode.com/problems/find-xor-sum-of-all-pairs-bitwise-and">See the problem</a>
    /// </summary>
    public int GetXORSum(int[] arr1, int[] arr2)
    {
        int x1 = 0, x2 = 0;
        foreach (var a in arr1) x1 ^= a;
        foreach (var b in arr2) x2 ^= b;
        return x1 & x2;
    }
}
