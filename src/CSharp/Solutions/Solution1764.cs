using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1764
{
    /// <summary>
    /// 1764. Form Array by Concatenating Subarrays of Another Array - Medium
    /// <a href="https://leetcode.com/problems/form-array-by-concatenating-subarrays-of-another-array">See the problem</a>
    /// </summary>
    public bool CanChoose(int[][] groups, int[] nums)
    {
        int i = 0; // pointer for groups
        int j = 0; // pointer for nums

        while (i < groups.Length && j < nums.Length)
        {
            if (Match(groups[i], nums, j))
            {
                j += groups[i].Length; // move past matched subarray
                i++; // go to next group
            }
            else
            {
                j++; // try next position
            }
        }

        return i == groups.Length;
    }

    private bool Match(int[] group, int[] nums, int start)
    {
        if (start + group.Length > nums.Length) return false;

        for (int k = 0; k < group.Length; k++)
        {
            if (nums[start + k] != group[k])
            {
                return false;
            }
        }
        return true;
    }
}
