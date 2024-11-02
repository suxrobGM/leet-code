using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution747
{
    /// <summary>
    /// 747. Largest Number At Least Twice of Others - Easy
    /// <a href="https://leetcode.com/problems/largest-number-at-least-twice-of-others">See the problem</a>
    /// </summary>
    public int DominantIndex(int[] nums)
    {
        var max = nums.Max();
        var index = Array.IndexOf(nums, max);

        return nums.All(num => num == max || num * 2 <= max) ? index : -1;
    }
}
