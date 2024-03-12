namespace LeetCode.Solutions;

public class Solution334
{
    /// <summary>
    /// 334. Increasing Triplet Subsequence - Medium
    /// <a href="https://leetcode.com/problems/increasing-triplet-subsequence">See the problem</a>
    /// </summary>
    public bool IncreasingTriplet(int[] nums)
    {
        var first = int.MaxValue;
        var second = int.MaxValue;

        foreach (var num in nums)
        {
            if (num <= first)
            {
                first = num;
            }
            else if (num <= second)
            {
                second = num;
            }
            else
            {
                return true;
            }
        }

        return false;
    }
}
