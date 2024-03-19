namespace LeetCode.Solutions;

public class Solution283
{
    /// <summary>
    /// 283. Move Zeroes - Easy
    /// <a href="https://leetcode.com/problems/move-zeroes">See the problem</a>
    /// </summary>
    public void MoveZeroes(int[] nums)
    {
        var i = 0;
        var j = 0;
        
        while (j < nums.Length)
        {
            if (nums[j] != 0)
            {
                (nums[i], nums[j]) = (nums[j], nums[i]);
                i++;
            }
            j++;
        }
    }
}
