using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1131
{
    /// <summary>
    /// 1131. Maximum of Absolute Value Expression - Medium
    /// <a href="https://leetcode.com/problems/maximum-of-absolute-value-expression">See the problem</a>
    /// </summary>
    public int MaxAbsValExpr(int[] arr1, int[] arr2)
    {
        int n = arr1.Length;
        int max1 = int.MinValue, min1 = int.MaxValue;
        int max2 = int.MinValue, min2 = int.MaxValue;
        int max3 = int.MinValue, min3 = int.MaxValue;
        int max4 = int.MinValue, min4 = int.MaxValue;

        for (int i = 0; i < n; i++)
        {
            max1 = Math.Max(max1, arr1[i] + arr2[i] + i);
            min1 = Math.Min(min1, arr1[i] + arr2[i] + i);

            max2 = Math.Max(max2, arr1[i] + arr2[i] - i);
            min2 = Math.Min(min2, arr1[i] + arr2[i] - i);

            max3 = Math.Max(max3, arr1[i] - arr2[i] + i);
            min3 = Math.Min(min3, arr1[i] - arr2[i] + i);

            max4 = Math.Max(max4, arr1[i] - arr2[i] - i);
            min4 = Math.Min(min4, arr1[i] - arr2[i] - i);
        }

        return Math.Max(
            Math.Max(max1 - min1, max2 - min2),
            Math.Max(max3 - min3, max4 - min4)
        );
    }
}
