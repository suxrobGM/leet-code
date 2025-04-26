using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1296
{
    /// <summary>
    /// 1296. Divide Array in Sets of K Consecutive Numbers - Medium
    /// <a href="https://leetcode.com/problems/divide-array-in-sets-of-k-consecutive-numbers">See the problem</a>
    /// </summary>
    public bool IsPossibleDivide(int[] nums, int k)
    {
        if (nums.Length % k != 0) return false;

        Array.Sort(nums);
        var count = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            if (!count.ContainsKey(num))
            {
                count[num] = 0;
            }
            count[num]++;
        }

        foreach (var num in nums)
        {
            if (count[num] == 0) continue;

            for (int i = 0; i < k; i++)
            {
                if (!count.ContainsKey(num + i) || count[num + i] == 0)
                {
                    return false;
                }
                count[num + i]--;
            }
        }

        return true;
    }
}
