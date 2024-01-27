namespace LeetCode.Solutions;

public class Solution45
{
    /// <summary>
    /// 45. Jump Game II
    /// <a href="https://leetcode.com/problems/jump-game-ii">See the problem</a>
    /// </summary>
    public int Jump(int[] nums)
    {
        var jumps = 0;
        var currentEnd = 0;
        var farthest = 0;
        
        for (var i = 0; i < nums.Length - 1; i++) 
        {
            farthest = Math.Max(farthest, i + nums[i]);
            
            // When we reach the end of the current range
            if (i == currentEnd) 
            {
                jumps++; // Make a jump
                currentEnd = farthest; // Update the range to the farthest we can reach
            }
        }
        
        return jumps;
    }
}
