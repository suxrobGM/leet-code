using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1304
{
    /// <summary>
    /// 1304. Find N Unique Integers Sum up to Zero - Easy
    /// <a href="https://leetcode.com/problems/find-n-unique-integers-sum-up-to-zero">See the problem</a>
    /// </summary>
    public int[] SumZero(int n)
    {
        int[] result = new int[n];
        for (int i = 0; i < n / 2; i++)
        {
            result[i] = i + 1;
            result[n - 1 - i] = -(i + 1);
        }

        if (n % 2 == 1)
        {
            result[n / 2] = 0;
        }

        return result;
    }
}
