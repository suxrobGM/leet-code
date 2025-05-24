using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1470
{
    /// <summary>
    /// 1470. Shuffle the Array - Easy
    /// <a href="https://leetcode.com/problems/shuffle-the-array">See the problem</a>
    /// </summary>
    public int[] Shuffle(int[] nums, int n)
    {
        var shuffled = new int[2 * n];
        for (int i = 0; i < n; i++)
        {
            shuffled[2 * i] = nums[i];
            shuffled[2 * i + 1] = nums[i + n];
        }
        return shuffled;
    }
}
