namespace LeetCode.Solutions;

public class Solution31
{
    /// <summary>
    /// 31. Next Permutation
    /// <a href="https://leetcode.com/problems/next-permutation">See the problem</a>
    /// </summary>
    public void NextPermutation(int[] nums)
    {
        var i = nums.Length - 2;

        // Step 1: Find the first decreasing element
        while (i >= 0 && nums[i] >= nums[i + 1]) 
        {
            i--;
        }

        // Step 2 and 3: If the pivot is found, swap it with the element just larger than itself
        if (i >= 0) 
        {
            var j = nums.Length - 1;
            while (nums[j] <= nums[i]) 
            {
                j--;
            }
            Swap(nums, i, j);
        }

        // Step 4: Reverse the elements after the pivot's position
        Reverse(nums, i + 1, nums.Length - 1);
    }
    
    private void Swap(int[] nums, int i, int j)
    {
        (nums[i], nums[j]) = (nums[j], nums[i]);
    }

    private void Reverse(int[] nums, int start, int end)
    {
        while (start < end) 
        {
            Swap(nums, start, end);
            start++;
            end--;
        }
    }
}
