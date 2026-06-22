namespace LeetCode.Solutions;

public class Solution2180
{
    /// <summary>
    /// 2180. Count Integers With Even Digit Sum - Easy
    /// <a href="https://leetcode.com/problems/count-integers-with-even-digit-sum">See the problem</a>
    /// </summary>
    public int CountEven(int num)
    {
        var count = 0;
        for (var i = 1; i <= num; i++)
        {
            var sum = 0;
            for (var n = i; n > 0; n /= 10)
            {
                sum += n % 10;
            }

            if (sum % 2 == 0)
            {
                count++;
            }
        }

        return count;
    }
}
