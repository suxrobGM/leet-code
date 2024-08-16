namespace LeetCode.Solutions;

public class Solution470
{
    /// <summary>
    /// 470. Implement Rand10() Using Rand7() - Medium
    /// <a href="https://leetcode.com/problems/implement-rand10-using-rand7">See the problem</a>
    /// </summary>
    public int Rand10() 
    {
        while (true) 
        {
            // Generate a number in the range [1, 49]
            var num = (Rand7() - 1) * 7 + Rand7();
            
            // If the number is within the range [1, 40], map it to [1, 10]
            if (num <= 40) 
            {
                return num % 10 + 1;
            }
            
            // Otherwise, reject the number and try again
        }
    }

    public int Rand7() 
    {
        return 0;
    }
}
