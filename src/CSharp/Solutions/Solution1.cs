namespace LeetCode.Solutions;

public class Solution1
{
    /// <summary>
    /// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
    /// You can return the answer in any order.
    /// <a href="https://leetcode.com/problems/two-sum/">See the problem</a>
    /// </summary>
    /// <remarks>Time complexity O(n)</remarks>
    public int[] TwoSum(int[] nums, int target)
    {
        var seen = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            var diff = target - num;
            if (seen.ContainsKey(diff))
            {
                return [i, seen[diff]];
            }

            seen[num] = i;
        }
        return new int[2];
    }
}
