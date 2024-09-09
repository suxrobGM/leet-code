using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution532
{
    /// <summary>
    /// 532. K-diff Pairs in an Array - Medium
    /// <a href="https://leetcode.com/problems/k-diff-pairs-in-an-array">See the problem</a>
    /// </summary>
    public int FindPairs(int[] nums, int k)
    {
        if (k < 0)
        {
            return 0;
        }

        var dict = new Dictionary<int, int>();
        var count = 0;

        foreach (var num in nums)
        {
            if (dict.ContainsKey(num))
            {
                dict[num]++;
            }
            else
            {
                dict[num] = 1;
            }
        }

        foreach (var num in dict.Keys)
        {
            if (k == 0)
            {
                if (dict[num] > 1)
                {
                    count++;
                }
            }
            else
            {
                if (dict.ContainsKey(num + k))
                {
                    count++;
                }
            }
        }

        return count;
    }
}
