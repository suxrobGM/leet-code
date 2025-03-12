using System.Text;

namespace LeetCode.Solutions;

public class Solution1089
{
    /// <summary>
    /// 1089. Duplicate Zeros - Easy
    /// <a href="https://leetcode.com/problems/duplicate-zeros">See the problem</a>
    /// </summary>
    public void DuplicateZeros(int[] arr)
    {
        var n = arr.Length;
        var zeros = 0;

        // Count the number of zeros
        foreach (var num in arr)
        {
            if (num == 0)
            {
                zeros++;
            }
        }

        // Start from the end of the array
        for (var i = n - 1; i >= 0; i--)
        {
            if (i + zeros < n)
            {
                arr[i + zeros] = arr[i];
            }

            if (arr[i] == 0)
            {
                zeros--;
                if (i + zeros < n)
                {
                    arr[i + zeros] = 0;
                }
            }
        }
    }
}
