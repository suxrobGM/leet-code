using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1005
{
    /// <summary>
    /// 1005. Maximize Sum Of Array After K Negations - Easy
    /// <a href="https://leetcode.com/problems/maximize-sum-of-array-after-k-negations</a>
    /// </summary>
    public int LargestSumAfterKNegations(int[] nums, int k)
    {
        Array.Sort(nums);

        var i = 0;
        while (k > 0 && i < nums.Length && nums[i] < 0)
        {
            nums[i] = -nums[i];
            i++;
            k--;
        }

        if (k % 2 == 1)
        {
            Array.Sort(nums);
            nums[0] = -nums[0];
        }

        return nums.Sum();
    }
}
