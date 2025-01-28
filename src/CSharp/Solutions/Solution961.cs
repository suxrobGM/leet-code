using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution961
{
    /// <summary>
    /// 961. N-Repeated Element in Size 2N Array - Medium
    /// <a href="https://leetcode.com/problems/n-repeated-element-in-size-2n-array">See the problem</a>
    /// </summary>
    public int RepeatedNTimes(int[] nums)
    {
        var set = new HashSet<int>();

        foreach (var num in nums)
        {
            if (!set.Add(num))
            {
                return num;
            }
        }

        return -1;
    }
}
