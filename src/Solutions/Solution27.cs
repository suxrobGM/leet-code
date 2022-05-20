namespace LeetCode.Solutions;

public partial class Solution
{
    /// <summary>
    /// Given an integer array nums and an integer val, remove all occurrences of val in nums in-place. The relative order of the elements may be changed.
    /// Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in the first part of the array nums.More formally, if there are k elements after removing the duplicates, then the first k elements of nums should hold the final result.It does not matter what you leave beyond the first k elements.
    /// Return k after placing the final result in the first k slots of nums.
    /// Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.
    /// <see href="https://leetcode.com/problems/remove-element/">See the problem</see>
    /// </summary>
    public int RemoveElement(int[] nums, int val)
    {
        // Fill removed numbers with the dummy number
        const int dummy = 101;
        var removedItems = 0; // count removed items from the array

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != dummy && nums[i] == val)
            {
                nums[i] = dummy;
                removedItems++;
            }
        }

        Array.Sort(nums);

        // k number is subtraction of removed numbers from the total size of the array
        return nums.Length - removedItems; 
    }
}
