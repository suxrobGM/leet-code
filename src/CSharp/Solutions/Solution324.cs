namespace LeetCode.Solutions;

public class Solution324
{
    /// <summary>
    /// 324. Wiggle Sort II - Medium
    /// <a href="https://leetcode.com/problems/wiggle-sort-ii">See the problem</a>
    /// </summary>
    public void WiggleSort(int[] nums)
    {
        var n = nums.Length;
        var sorted = new int[n];
        
        Array.Copy(nums, sorted, n);
        Array.Sort(sorted);

        var j = n - 1;

        for (var i = 1; i < n; i += 2)
        {
            nums[i] = sorted[j--];
        }

        for (var i = 0; i < n; i += 2)
        {
            nums[i] = sorted[j--];
        }
    }
}
