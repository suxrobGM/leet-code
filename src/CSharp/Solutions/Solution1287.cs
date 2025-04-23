using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1287
{
    /// <summary>
    /// 1287. Element Appearing More Than 25% In Sorted Array - Easy
    /// <a href="https://leetcode.com/problems/element-appearing-more-than-25-in-sorted-array">See the problem</a>
    /// </summary>
    public int FindSpecialInteger(int[] arr)
    {
        int n = arr.Length;
        int threshold = n / 4;
        for (int i = 0; i < n; i++)
        {
            if (i + threshold < n && arr[i] == arr[i + threshold])
            {
                return arr[i];
            }
        }
        return -1;
    }
}
