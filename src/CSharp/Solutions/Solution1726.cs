using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1726
{
    /// <summary>
    /// 1726. Tuple with Same Product - Medium
    /// <a href="https://leetcode.com/problems/tuple-with-same-product">See the problem</a>
    /// </summary>
    public int TupleSameProduct(int[] nums)
    {
        var freq = new Dictionary<long, int>();
        int n = nums.Length;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                long prod = (long)nums[i] * nums[j];
                freq.TryGetValue(prod, out int c);
                freq[prod] = c + 1;
            }
        }

        long ans = 0;
        foreach (var kv in freq)
        {
            long c = kv.Value;
            if (c >= 2)
            {
                ans += 8L * c * (c - 1) / 2; // 8 * C(c,2)
            }
        }

        return (int)ans;
    }
}
