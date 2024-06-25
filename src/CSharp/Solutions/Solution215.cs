namespace LeetCode.Solutions;

public class Solution215
{
    /// <summary>
    /// 215. Kth Largest Element in an Array - Medium
    /// <a href="https://leetcode.com/problems/kth-largest-element-in-an-array">See the problem</a>
    /// </summary>
    public int FindKthLargest(int[] nums, int k)
    {
        var n = nums.Length;
        var left = 0;
        var right = n - 1;
        
        while (true)
        {
            var pivotIndex = Partition(nums, left, right);
            
            if (pivotIndex == n - k)
            {
                return nums[pivotIndex];
            }
            else if (pivotIndex < n - k)
            {
                left = pivotIndex + 1;
            }
            else
            {
                right = pivotIndex - 1;
            }
        }
    }

    private int Partition(int[] nums, int left, int right)
    {
        var pivot = nums[right];
        var i = left;
        
        for (var j = left; j < right; j++)
        {
            if (nums[j] < pivot)
            {
                Swap(nums, i, j);
                i++;
            }
        }
        
        Swap(nums, i, right);
        return i;
    }

    private void Swap(int[] nums, int i, int j)
    {
        (nums[j], nums[i]) = (nums[i], nums[j]);
    }
}
