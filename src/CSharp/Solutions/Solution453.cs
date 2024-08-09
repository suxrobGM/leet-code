namespace LeetCode.Solutions;

public class Solution453
{
    /// <summary>
    /// 453. Minimum Moves to Equal Array Elements - Medium
    /// <a href="https://leetcode.com/problems/minimum-moves-to-equal-array-elements">See the problem</a>
    /// </summary>
    public int MinMoves(int[] nums) 
    {
        var min = int.MaxValue;
        var sum = 0;
        
        foreach (var num in nums)
        {
            min = Math.Min(min, num);
            sum += num;
        }
        
        return sum - min * nums.Length;
    }
}
