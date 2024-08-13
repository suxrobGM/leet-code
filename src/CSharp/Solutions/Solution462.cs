using System.Text;

namespace LeetCode.Solutions;

public class Solution462
{
    /// <summary>
    /// 462. Minimum Moves to Equal Array Elements II - Medium
    /// <a href="https://leetcode.com/problems/minimum-moves-to-equal-array-elements-ii">See the problem</a>
    /// </summary>
    public int MinMoves2(int[] nums)
    {
        Array.Sort(nums);

        var median = nums[nums.Length / 2];
        var moves = 0;

        foreach (var num in nums)
        {
            moves += Math.Abs(num - median);
        }

        return moves;
    }
}
