using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1073
{
    /// <summary>
    /// 1073. Adding Two Negabinary Numbers - Medium
    /// <a href="https://leetcode.com/problems/adding-two-negabinary-numbers"</a>
    /// </summary>
    public int[] AddNegabinary(int[] arr1, int[] arr2)
    {
        var result = new List<int>();
        int carry = 0;

        int i = arr1.Length - 1;
        int j = arr2.Length - 1;

        while (i >= 0 || j >= 0 || carry != 0)
        {
            if (i >= 0)
            {
                carry += arr1[i--];
            }

            if (j >= 0)
            {
                carry += arr2[j--];
            }

            result.Add(carry & 1);
            carry = -(carry >> 1);
        }

        // Remove leading zeros
        while (result.Count > 1 && result[^1] == 0)
        {
            result.RemoveAt(result.Count - 1);
        }

        result.Reverse();
        return [.. result];
    }
}
