namespace LeetCode.Solutions;

/// <summary>
/// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
/// You may assume that each input would have exactly one solution, and you may not use the same element twice.
/// You can return the answer in any order.
/// </summary>
public partial class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var seen = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (seen.ContainsKey(target - nums[i]))
            {
                return new int[] { i, seen[target - nums[i]] };
            }
            else
            {
                seen[nums[i]] = i;
            }
        }
        return new int[2];
    }
}
