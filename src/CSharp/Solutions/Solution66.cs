namespace LeetCode.Solutions;

public partial class Solution
{
    /// <summary>
    /// You are given a large integer represented as an integer array digits, where each digits[i] is the ith digit of the integer. The digits are ordered from most significant to least significant in left-to-right order. The large integer does not contain any leading 0's.
    /// Increment the large integer by one and return the resulting array of digits.
    /// <see href="https://leetcode.com/problems/plus-one/">See the problem</see>
    /// </summary>
    public int[] PlusOne(int[] digits)
    {
        var len = digits.Length;

        for (int i = len - 1; i >= 0; i--)
        {
            digits[i]++;
            if (digits[i] != 10)
                return digits;

            digits[i] = 0;
        }

        int[] arr = new int[digits.Length + 1];
        arr[0] = 1;
        return arr;
    }
}
