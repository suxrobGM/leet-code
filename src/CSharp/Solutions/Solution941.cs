using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution941
{
    /// <summary>
    /// 941. Valid Mountain Array - Easy
    /// <a href="https://leetcode.com/problems/valid-mountain-array">See the problem</a>
    /// </summary>
    public bool ValidMountainArray(int[] arr)
    {
        int n = arr.Length;
        int i = 0;

        while (i + 1 < n && arr[i] < arr[i + 1])
        {
            i++;
        }

        if (i == 0 || i == n - 1)
        {
            return false;
        }

        while (i + 1 < n && arr[i] > arr[i + 1])
        {
            i++;
        }

        return i == n - 1;
    }
}
