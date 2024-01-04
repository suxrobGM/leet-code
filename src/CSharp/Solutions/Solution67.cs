using System.Text;

namespace LeetCode.Solutions;

public class Solution67
{
    /// <summary>
    /// Given two binary strings a and b, return their sum as a binary string.
    /// <see href="https://leetcode.com/problems/add-binary/">See the problem</see>
    /// </summary>
    public string AddBinary(string a, string b)
    {
        var sb = new StringBuilder();
        var i = a.Length - 1;
        var j = b.Length - 1;
        var carry = 0;

        while (i >= 0 || j >= 0)
        {
            int sum = carry;

            if (i >= 0)
            {
                sum += a[i--] - '0';
            }

            if (j >= 0)
            {
                sum += b[j--] - '0';
            }

            carry = sum > 1 ? 1 : 0;
            sb.Append(sum % 2);
        }

        if (carry != 0)
        {
            sb.Append(carry);
        }

        return new string(sb.ToString().Reverse().ToArray());
    }
}
