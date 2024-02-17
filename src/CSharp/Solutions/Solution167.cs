namespace LeetCode.Solutions;

public class Solution167
{
    /// <summary>
    /// 167. Two Sum II - Input Array Is Sorted
    /// <a href="https://leetcode.com/problems/two-sum-ii-input-array-is-sorted">See the problem</a>
    /// </summary>
    public int[] TwoSum(int[] numbers, int target)
    {
        var left = 0;
        var right = numbers.Length - 1;

        while (left < right)
        {
            var sum = numbers[left] + numbers[right];

            if (sum == target)
            {
                return [left + 1, right + 1];
            }

            if (sum < target)
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return [-1, -1];
    }
}
