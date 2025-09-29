using System.Text;

namespace LeetCode.Solutions;

public class Solution1846
{
    /// <summary>
    /// 1846. Maximum Element After Decreasing and Rearranging - Medium
    /// <a href="https://leetcode.com/problems/maximum-element-after-decreasing-and-rearranging">See the problem</a>
    /// </summary>
    public int MaximumElementAfterDecrementingAndRearranging(int[] arr)
    {
        Array.Sort(arr);
        arr[0] = 1;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] - arr[i - 1] > 1)
            {
                arr[i] = arr[i - 1] + 1;
            }
        }
        return arr[^1];
    }
}
