namespace LeetCode.Solutions;

public class Solution410
{
    /// <summary>
    /// 410. Split Array Largest Sum - Hard
    /// <a href="https://leetcode.com/problems/split-array-largest-sum">See the problem</a>
    /// </summary>
    public int SplitArray(int[] nums, int k)
    {
        var left = 0;
        var right = 0;

        foreach (var num in nums)
        {
            left = Math.Max(left, num);
            right += num;
        }

        while (left < right)
        {
            var mid = left + (right - left) / 2;
            var sum = 0;
            var pieces = 1;

            foreach (var num in nums)
            {
                if (sum + num > mid)
                {
                    sum = num;
                    pieces++;
                }
                else
                {
                    sum += num;
                }
            }

            if (pieces > k)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return left;
    }
}
