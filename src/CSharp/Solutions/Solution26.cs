namespace LeetCode.Solutions;

public class Solution26
{
    /// <summary>
    /// Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same.
    /// Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in the first part of the array nums.More formally, if there are k elements after removing the duplicates, then the first k elements of nums should hold the final result.It does not matter what you leave beyond the first k elements.
    /// Return k after placing the final result in the first k slots of nums.
    /// Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.
    /// <a href="https://leetcode.com/problems/remove-duplicates-from-sorted-array/">See the problem</a>
    /// </summary>
    public int RemoveDuplicates(int[] nums)
    {
        if (nums.Length == 1)
        {
            return 1;
        }

        // Fill removed numbers with the dummy number
        const int dummy = 101;
        var removedItems = 0; // count removed items from the array

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == dummy)
                continue;

            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] == nums[j])
                {
                    nums[j] = dummy;
                    removedItems++;
                }
            }
        }

        Array.Sort(nums); // sort array

        // k number is subtraction of removed numbers from the total size of the array
        return nums.Length - removedItems; 
    }
}
