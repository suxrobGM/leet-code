namespace LeetCode.Solutions;

public class Solution34
{
    /// <summary>
    /// 34. Find First and Last Position of Element in Sorted Array
    /// <a href="https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array">See the problem</a>
    /// </summary>
    public int[] SearchRange(int[] nums, int target)
    {
        var result = new int[2];
        result[0] = FindFirstPosition(nums, target);
        result[1] = FindLastPosition(nums, target);
        return result;
    }
    
    private int FindFirstPosition(int[] nums, int target) {
        var index = -1;
        var left = 0;
        var right = nums.Length - 1;
        
        while (left <= right) 
        {
            var mid = left + (right - left) / 2;
            
            if (nums[mid] >= target)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
            
            if (nums[mid] == target)
            {
                index = mid;
            }
        }
        return index;
    }

    private int FindLastPosition(int[] nums, int target) {
        var index = -1;
        var left = 0;
        var right = nums.Length - 1;
        
        while (left <= right) 
        {
            var mid = left + (right - left) / 2;
            
            if (nums[mid] <= target) 
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
            
            if (nums[mid] == target)
            {
                index = mid;
            }
        }
        return index;
    }
}
