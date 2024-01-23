namespace LeetCode.Solutions;

public class Solution80
{
    /// <summary>
    /// 80. Remove Duplicates from Sorted Array II
    /// <a href="https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii">See the problem</a>
    /// </summary>
    public int RemoveDuplicates(int[] nums)
    {
        if (nums.Length <= 2)
        {
            return nums.Length;
        }
        
        var lastItemIndex = nums.Length - 1;
        int? prevNum = null;
        
        for (var i = 1; i <= lastItemIndex; i++)
        {
            if (nums[i] == nums[i - 1] && !prevNum.HasValue)
            {
                prevNum = nums[i];
                continue;
            }
            
            if (nums[i] == nums[i - 1] && nums[i] == prevNum)
            {
                var shiftCount = lastItemIndex - i;
                ShiftRight(nums, i, lastItemIndex, shiftCount);
                i--;
                lastItemIndex--;
            }
            else
            {
                prevNum = null;
            }
        }
        
        return lastItemIndex + 1;
    }

    /// <summary>
    /// Optimized Easiest approach suggested by ChatGPT
    /// </summary>
    public int RemoveDuplicates2(int[] nums)
    {
        if (nums.Length <= 2) 
        {
            return nums.Length;
        }

        var newLength = 2; // Start from 2 as the first two elements can always be part of the result

        for (var i = 2; i < nums.Length; i++) 
        {
            // Check if current element is a duplicate of the element at newLength - 2
            if (nums[i] != nums[newLength - 2]) 
            {
                nums[newLength] = nums[i];
                newLength++;
            }
        }

        return newLength;
    }

    /// <summary>
    /// Shift array elements to right by k steps
    /// </summary>
    /// <param name="array">Array of integers</param>
    /// <param name="startIndex">Start index of array portion</param>
    /// <param name="lastIndex">Last index of array portion</param>
    /// <param name="shiftCount">Number of steps to shift elements to right</param>
    private void ShiftRight(int[] array, int startIndex, int lastIndex, int shiftCount)
    {
        var segmentSize = lastIndex - startIndex + 1;
        shiftCount %= segmentSize; // Normalize shift count

        // Reverse the entire segment
        Reverse(array, startIndex, lastIndex);

        // Reverse the first part
        Reverse(array, startIndex, startIndex + shiftCount - 1);

        // Reverse the second part
        Reverse(array, startIndex + shiftCount, lastIndex);
    }
    
    /// <summary>
    /// Reverse a segment of the array
    /// </summary>
    private void Reverse(int[] array, int start, int end) 
    {
        while (start < end) 
        {
            (array[start], array[end]) = (array[end], array[start]);
            start++;
            end--;
        }
    }
}
