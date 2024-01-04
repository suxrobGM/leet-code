namespace LeetCode.Solutions;

public class Solution7
{
    /// <summary>
    /// Problem #7
    /// <a href="https://leetcode.com/problems/reverse-integer/">See the problem</a>
    /// </summary>
    public int Reverse(int x)
    {
        try
        {
            var reversed = 0;
            var sign = x < 0 ? -1 : 1;
            x = Math.Abs(x);

            checked
            {
                while (x > 0)
                {
                    var digit = x % 10; // Extract the last digit
                    reversed = reversed * 10 + digit; // Append it to the reversed number
                    x /= 10; // Remove the last digit
                }
            }
            
            return sign * reversed;
        }
        catch (OverflowException)
        {
            return 0;
        }
    }
}
