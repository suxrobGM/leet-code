using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution556
{
    /// <summary>
    /// 556. Next Greater Element III - Medium
    /// <a href="https://leetcode.com/problems/next-greater-element-iii">See the problem</a>
    /// </summary>
    public int NextGreaterElement(int n)
    {
        var digits = n.ToString().ToCharArray();
        int i = digits.Length - 2;
        while (i >= 0 && digits[i] >= digits[i + 1])
        {
            i--;
        }

        if (i < 0)
        {
            return -1;
        }

        int j = digits.Length - 1;
        while (j >= 0 && digits[j] <= digits[i])
        {
            j--;
        }

        (digits[i], digits[j]) = (digits[j], digits[i]);
        Array.Reverse(digits, i + 1, digits.Length - i - 1);

        long result = long.Parse(new string(digits));
        return result > int.MaxValue ? -1 : (int)result;
    }
}
