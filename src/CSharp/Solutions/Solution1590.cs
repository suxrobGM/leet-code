using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1590
{
    /// <summary>
    /// 1590. Make Sum Divisible by P - Medium
    /// <a href="https://leetcode.com/problems/make-sum-divisible-by-p">See the problem</a>
    /// </summary>
    public int MinSubarray(int[] nums, int p)
    {
        long total = 0;
        foreach (var num in nums)
            total = (total + num) % p;

        if (total == 0) return 0;

        int n = nums.Length;
        var modToIndex = new Dictionary<long, int>
        {
            [0] = -1
        };

        long prefix = 0;
        int res = n;

        for (int i = 0; i < n; i++)
        {
            prefix = (prefix + nums[i]) % p;
            long target = (prefix - total + p) % p;

            if (modToIndex.ContainsKey(target))
                res = Math.Min(res, i - modToIndex[target]);

            modToIndex[prefix] = i;
        }

        return res == n ? -1 : res;
    }
}
