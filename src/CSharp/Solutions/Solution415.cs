using System.Text;

namespace LeetCode.Solutions;

public class Solution415
{
    /// <summary>
    /// 415. Add Strings - Easy
    /// <a href="https://leetcode.com/problems/add-strings">See the problem</a>
    /// </summary>
    public string AddStrings(string num1, string num2)
    {
        var result = new StringBuilder();
        var carry = 0;
        var i = num1.Length - 1;
        var j = num2.Length - 1;

        while (i >= 0 || j >= 0)
        {
            var sum = carry;

            if (i >= 0)
            {
                sum += num1[i--] - '0';
            }

            if (j >= 0)
            {
                sum += num2[j--] - '0';
            }

            carry = sum / 10;
            result.Append(sum % 10);
        }

        if (carry > 0)
        {
            result.Append(carry);
        }

        return new string(result.ToString().Reverse().ToArray());
    }
}
