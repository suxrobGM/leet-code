namespace LeetCode.Solutions;

public class Solution2293
{
    /// <summary>
    /// 2293. Min Max Game - Easy
    /// <a href="https://leetcode.com/problems/min-max-game">See the problem</a>
    /// </summary>
    public int MinMaxGame(int[] nums)
    {
        while (nums.Length > 1)
        {
            var newLength = nums.Length / 2;
            var newNums = new int[newLength];

            for (var i = 0; i < newLength; i++)
            {
                if (i % 2 == 0)
                {
                    newNums[i] = Math.Min(nums[2 * i], nums[2 * i + 1]);
                }
                else
                {
                    newNums[i] = Math.Max(nums[2 * i], nums[2 * i + 1]);
                }
            }

            nums = newNums;
        }

        return nums[0];
    }
}
