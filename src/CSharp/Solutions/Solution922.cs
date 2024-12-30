using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution922
{
    /// <summary>
    /// 922. Sort Array By Parity II - Easy
    /// <a href="https://leetcode.com/problems/sort-array-by-parity-ii">See the problem</a>
    /// </summary>
    public int[] SortArrayByParityII(int[] nums)
    {
        var n = nums.Length;
        var result = new int[n];
        var evenIndex = 0;
        var oddIndex = 1;

        foreach (var num in nums)
        {
            if (num % 2 == 0)
            {
                result[evenIndex] = num;
                evenIndex += 2;
            }
            else
            {
                result[oddIndex] = num;
                oddIndex += 2;
            }
        }

        return result;
    }
}
