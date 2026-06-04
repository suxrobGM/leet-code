namespace LeetCode.Solutions;

public class Solution2161
{
    /// <summary>
    /// 2161. Partition Array According to Given Pivot - Medium
    /// <a href="https://leetcode.com/problems/partition-array-according-to-given-pivot">See the problem</a>
    /// </summary>
    public int[] PivotArray(int[] nums, int pivot)
    {
        int[] result = new int[nums.Length];
        int index = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] < pivot)
            {
                result[index++] = nums[i];
            }
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == pivot)
            {
                result[index++] = nums[i];
            }
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > pivot)
            {
                result[index++] = nums[i];
            }
        }
        return result;
    }
}
