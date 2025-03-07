using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1053
{
    /// <summary>
    /// 1053. Previous Permutation With One Swap - Medium
    /// <a href="https://leetcode.com/problems/previous-permutation-with-one-swap"</a>
    /// </summary>
    public int[] PrevPermOpt1(int[] arr)
    {
        var n = arr.Length;
        var i = n - 2;

        while (i >= 0 && arr[i] <= arr[i + 1])
        {
            i--;
        }

        if (i < 0)
        {
            return arr;
        }

        var j = n - 1;

        while (arr[j] >= arr[i])
        {
            j--;
        }

        while (arr[j] == arr[j - 1])
        {
            j--;
        }

        (arr[j], arr[i]) = (arr[i], arr[j]);
        return arr;
    }
}
