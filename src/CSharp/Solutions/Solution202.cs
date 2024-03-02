namespace LeetCode.Solutions;

public class Solution202
{
    /// <summary>
    /// 202. Happy Number - Easy
    /// <a href="https://leetcode.com/problems/happy-number">See the problem</a>
    /// </summary>
    public bool IsHappy(int n)
    {
        var slow = n;
        var fast = SumOfSquares(n);
        
        while (fast != 1 && slow != fast)
        {
            slow = SumOfSquares(slow);
            fast = SumOfSquares(SumOfSquares(fast));
        }
        
        return slow == 1 || fast == 1;
    }
    
    private int SumOfSquares(int n)
    {
        var sum = 0;
        while (n > 0)
        {
            var digit = n % 10;
            sum += digit * digit;
            n /= 10;
        }
        return sum;
    }
}
