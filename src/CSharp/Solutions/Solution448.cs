using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution448
{
    /// <summary>
    /// 448. Find All Numbers Disappeared in an Array - Easy
    /// <a href="https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array">See the problem</a>
    /// </summary>
    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        var n = nums.Length;
        var result = new List<int>();

        for (var i = 0; i < n; i++)
        {
            var index = Math.Abs(nums[i]) - 1;

            if (nums[index] > 0)
            {
                nums[index] = -nums[index];
            }
        }

        for (var i = 0; i < n; i++)
        {
            if (nums[i] > 0)
            {
                result.Add(i + 1);
            }
        }

        return result;
    }
}
