namespace LeetCode.Solutions;

public class Solution75
{
    /// <summary>
    /// 75. Sort Colors - Medium
    /// <a href="https://leetcode.com/problems/sort-colors">See the problem</a>
    /// </summary>
    public void SortColors(int[] nums)
    {
        var low = 0;
        var high = nums.Length - 1;
        var i = 0;

        while (i <= high)
        {
            if (nums[i] == 0)
            {
                (nums[i], nums[low]) = (nums[low], nums[i]);
                low++;
                i++;
            }
            else if (nums[i] == 2)
            {
                (nums[i], nums[high]) = (nums[high], nums[i]);
                high--;
            }
            else
            {
                i++;
            }
        }
    }
}
