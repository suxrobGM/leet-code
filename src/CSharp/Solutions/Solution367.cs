namespace LeetCode.Solutions;

public class Solution367
{
    /// <summary>
    /// 367. Valid Perfect Square - Easy
    /// <a href="https://leetcode.com/problems/valid-perfect-square">See the problem</a>
    /// </summary>
    public bool IsPerfectSquare(int num)
    {
        if (num < 2)
        {
            return true;
        }

        var left = 2;
        var right = num / 2;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            var square = (long)mid * mid;

            if (square == num)
            {
                return true;
            }

            if (square < num)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return false;
    }
}
