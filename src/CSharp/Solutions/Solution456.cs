namespace LeetCode.Solutions;

public class Solution456
{
    /// <summary>
    /// 456. 132 Pattern - Medium
    /// <a href="https://leetcode.com/problems/132-pattern">See the problem</a>
    /// </summary>
    public bool Find132pattern(int[] nums) 
    {
        var n = nums.Length;
        var stack = new Stack<int>();
        var third = int.MinValue;
        
        for (var i = n - 1; i >= 0; i--)
        {
            if (nums[i] < third)
            {
                return true;
            }
            
            while (stack.Count > 0 && nums[i] > stack.Peek())
            {
                third = stack.Pop();
            }
            
            stack.Push(nums[i]);
        }
        
        return false;
    }
}
