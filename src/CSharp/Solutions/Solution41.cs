namespace LeetCode.Solutions;

public class Solution41
{
    /// <summary>
    /// 41. First Missing Positive - Hard
    /// <a href="https://leetcode.com/problems/first-missing-positive">See the problem</a>
    /// </summary>
    public int FirstMissingPositive(int[] nums)
    {
        var n = nums.Length;
        
        // The idea is to put each number in its right place.
        for (var i = 0; i < n; i++)
        {
            // Swap the current number with the number at the index of the current number
            while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i])
            {
                (nums[nums[i] - 1], nums[i]) = (nums[i], nums[nums[i] - 1]);
            }
        }
        
        // Find the first number that is not in its right place
        for (var i = 0; i < n; i++)
        {
            if (nums[i] != i + 1)
            {
                return i + 1;
            }
        }
        
        return n + 1;
    }
}
