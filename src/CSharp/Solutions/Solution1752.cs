using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1752
{
    /// <summary>
    /// 1752. Check if Array Is Sorted and Rotated - Easy
    /// <a href="https://leetcode.com/problems/check-if-array-is-sorted-and-rotated">See the problem</a>
    /// </summary>
    public bool Check(int[] nums)
    {
        int n = nums.Length;
        int count = 0;

        for (int i = 0; i < n; i++)
        {
            if (nums[i] > nums[(i + 1) % n])
            {
                count++;
            }
        }

        return count <= 1;
    }
}

