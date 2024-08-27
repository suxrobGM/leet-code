using System.Text;

namespace LeetCode.Solutions;

public class Solution504
{
    /// <summary>
    /// 504. Base 7 - Easy
    /// <a href="https://leetcode.com/problems/base-7">See the problem</a>
    /// </summary>
    public string ConvertToBase7(int num)
    {
        if (num == 0)
        {
            return "0";
        }

        bool isNegative = num < 0;
        num = Math.Abs(num);
        StringBuilder result = new();

        while (num > 0)
        {
            result.Insert(0, num % 7);
            num /= 7;
        }

        return isNegative ? "-" + result.ToString() : result.ToString();
    }
}
