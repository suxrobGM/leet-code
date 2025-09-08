using System.Text;

namespace LeetCode.Solutions;

public class Solution1814
{
    /// <summary>
    /// 1814. Count Nice Pairs in an Array - Medium
    /// <a href="https://leetcode.com/problems/count-nice-pairs-in-an-array">See the problem</a>
    /// </summary>
    public int CountNicePairs(int[] nums)
    {
        const int MOD = 1000000007;
        var freq = new Dictionary<int, long>();

        long result = 0;
        foreach (var num in nums)
        {
            int diff = num - Reverse(num);

            if (freq.ContainsKey(diff))
            {
                result = (result + freq[diff]) % MOD;
                freq[diff]++;
            }
            else
            {
                freq[diff] = 1;
            }
        }

        return (int)(result % MOD);
    }

    private int Reverse(int x)
    {
        int res = 0;
        while (x > 0)
        {
            res = res * 10 + (x % 10);
            x /= 10;
        }
        return res;
    }
}
