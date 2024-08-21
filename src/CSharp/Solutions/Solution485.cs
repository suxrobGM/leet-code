namespace LeetCode.Solutions;

public class Solution485
{
    /// <summary>
    /// 485. Max Consecutive Ones - Easy
    /// <a href="https://leetcode.com/problems/max-consecutive-ones">See the problem</a>
    /// </summary>
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        var max = 0;
        var count = 0;

        foreach (var num in nums)
        {
            if (num == 1)
            {
                count++;
                max = Math.Max(max, count);
            }
            else
            {
                count = 0;
            }
        }

        return max;
    }
}
