using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1299
{
    /// <summary>
    /// 1299. Replace Elements with Greatest Element on Right Side - Easy
    /// <a href="https://leetcode.com/problems/replace-elements-with-greatest-element-on-right-side">See the problem</a>
    /// </summary>
    public int[] ReplaceElements(int[] arr)
    {
        int n = arr.Length;
        var result = new int[n];
        int maxFromRight = -1;

        for (int i = n - 1; i >= 0; i--)
        {
            result[i] = maxFromRight;
            maxFromRight = Math.Max(maxFromRight, arr[i]);
        }

        return result;
    }
}
