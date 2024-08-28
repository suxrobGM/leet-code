using System.Text;

namespace LeetCode.Solutions;

public class Solution507
{
    /// <summary>
    /// 507. Perfect Number - Easy
    /// <a href="https://leetcode.com/problems/perfect-number">See the problem</a>
    /// </summary>
    public bool CheckPerfectNumber(int num)
    {
        if (num <= 1)
        {
            return false;
        }

        var sum = 1;

        for (var i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0)
            {
                sum += i;

                if (i != num / i)
                {
                    sum += num / i;
                }
            }
        }

        return sum == num;
    }
}
