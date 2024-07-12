namespace LeetCode.Solutions;

public class Solution365
{
    /// <summary>
    /// 365. Water and Jug Problem - Medium
    /// <a href="https://leetcode.com/problems/water-and-jug-problem">See the problem</a>
    /// </summary>
    public bool CanMeasureWater(int x, int y, int target)
    {
        if (x + y < target)
        {
            return false;
        }

        if (x == 0 || y == 0)
        {
            return target == 0 || x + y == target;
        }

        return target % Gcd(x, y) == 0;
    }

    private int Gcd(int a, int b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }
}
