using System.Text;

namespace LeetCode.Solutions;

public class Solution1785
{
    /// <summary>
    /// 1785. Minimum Elements to Add to Form a Given Sum - Medium
    /// <a href="https://leetcode.com/problems/minimum-elements-to-add-to-form-a-given-sum">See the problem</a>
    /// </summary>
    public int MinElements(int[] nums, int limit, int goal)
    {
        long sum = 0;
        foreach (var num in nums) sum += num;

        long diff = Math.Abs((long)goal - sum);
        return (int)((diff + limit - 1) / limit); // ceil(diff/limit)
    }
}
