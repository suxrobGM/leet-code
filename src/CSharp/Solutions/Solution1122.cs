using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1122
{
    /// <summary>
    /// 1122. Relative Sort Array - Easy
    /// <a href="https://leetcode.com/problems/relative-sort-array">See the problem</a>
    /// </summary>
    public int[] RelativeSortArray(int[] arr1, int[] arr2)
    {
        var count = new int[1001];
        var result = new int[arr1.Length];
        var index = 0;

        foreach (var num in arr1)
        {
            count[num]++;
        }

        foreach (var num in arr2)
        {
            while (count[num]-- > 0)
            {
                result[index++] = num;
            }
        }

        for (var i = 0; i < count.Length; i++)
        {
            while (count[i]-- > 0)
            {
                result[index++] = i;
            }
        }

        return result;
    }
}
