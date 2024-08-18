namespace LeetCode.Solutions;

public class Solution476
{
    /// <summary>
    /// 476. Number Complement - Easy
    /// <a href="https://leetcode.com/problems/number-complement">See the problem</a>
    /// </summary>
    public int FindComplement(int num)
    {
        var mask = 1;
        while (mask < num)
        {
            mask = (mask << 1) | 1;
        }

        return ~num & mask;
    }
}
