namespace LeetCode.Solutions;

public class Solution55
{
    /// <summary>
    /// 55. Jump Game
    /// <a href="https://leetcode.com/problems/jump-game">See the problem</a>
    /// </summary>
    public bool CanJump(int[] nums)
    {
        var jumCount = 0;

        foreach (var n in nums)
        {
            if (jumCount < 0)
            {
                return false;
            }

            if (n > jumCount)
            {
                jumCount = n;
            }

            jumCount--;
        }
        
        return true;
    }
}
