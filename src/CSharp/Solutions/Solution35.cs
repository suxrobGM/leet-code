namespace LeetCode.Solutions;

public class Solution35
{
    /// <summary>
    /// Problem #35
    /// <a href="https://leetcode.com/problems/search-insert-position/">See the problem</a>
    /// </summary>
    public int SearchInsert(int[] nums, int target)
    {
        if (target > nums[nums.Length - 1]) 
            return nums.Length;

        if (target < nums[0]) 
            return 0;

        int index = BinarySearch(nums, target);
        return index;
    }

    private int BinarySearch(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;
        
        while (left <= right)
        {
            int middle = (left + right) / 2;

            if (nums[middle] == target)
            {
                return middle;
            }
            else if (nums[middle] > target)
            {
                right = middle - 1;
                
            }
            else
            {
                left = middle + 1;
            }
        }

        return left;
    }
}
