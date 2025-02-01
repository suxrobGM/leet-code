using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution969
{
    private int cameras = 0;

    /// <summary>
    /// 969. Pancake Sorting - Medium
    /// <a href="https://leetcode.com/problems/pancake-sorting">See the problem</a>
    /// </summary>
    public IList<int> PancakeSort(int[] arr)
    {
        var result = new List<int>();
        PancakeSort(arr, arr.Length, result);
        return result;
    }

    private void PancakeSort(int[] arr, int n, List<int> result)
    {
        if (n == 1) return;

        var maxIndex = 0;
        var max = arr[0];
        for (var i = 1; i < n; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
                maxIndex = i;
            }
        }

        if (maxIndex != n - 1)
        {
            Reverse(arr, 0, maxIndex);
            result.Add(maxIndex + 1);
            Reverse(arr, 0, n - 1);
            result.Add(n);
        }

        PancakeSort(arr, n - 1, result);
    }

    private void Reverse(int[] arr, int start, int end)
    {
        while (start < end)
        {
            (arr[end], arr[start]) = (arr[start], arr[end]);
            start++;
            end--;
        }
    }
}
