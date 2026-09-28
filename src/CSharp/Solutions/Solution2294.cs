namespace LeetCode.Solutions;

public class Solution2294
{
    /// <summary>
    /// 2294. Partition Array Such That Maximum Difference Is K - Medium
    /// <a href="https://leetcode.com/problems/partition-array-such-that-maximum-difference-is-k">See the problem</a>
    /// </summary>
    public int PartitionArray(int[] nums, int k)
    {
        Array.Sort(nums);

        var count = 1;
        var min = nums[0];

        foreach (var num in nums)
        {
            if (num - min > k)
            {
                count++;
                min = num;
            }
        }

        return count;
    }
}
