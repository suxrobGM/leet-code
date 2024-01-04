namespace LeetCode.Solutions;

public class Solution27
{
    /// <summary>
    /// Problem #27
    /// <a href="https://leetcode.com/problems/remove-element/">See the problem</a>
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
