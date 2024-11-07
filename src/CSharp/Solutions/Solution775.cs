using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution775
{
    /// <summary>
    /// 775. Global and Local Inversions - Medium
    /// <a href="https://leetcode.com/problems/global-and-local-inversions">See the problem</a>
    /// </summary>
    public bool IsIdealPermutation(int[] nums)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            if (Math.Abs(nums[i] - i) > 1)
            {
                return false;
            }
        }

        return true;
    }
}
