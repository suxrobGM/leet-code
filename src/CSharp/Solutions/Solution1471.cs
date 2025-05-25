using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1471
{
    /// <summary>
    /// 1471. The k Strongest Values in an Array - Medium
    /// <a href="https://leetcode.com/problems/the-k-strongest-values-in-an-array">See the problem</a>
    /// </summary>
    public int[] GetStrongest(int[] arr, int k)
    {
        Array.Sort(arr);
        int n = arr.Length;
        int median = arr[(n - 1) / 2];
        var result = new int[k];
        int left = 0, right = n - 1;

        for (int i = 0; i < k; i++)
        {
            if (Math.Abs(arr[left] - median) > Math.Abs(arr[right] - median))
            {
                result[i] = arr[left++];
            }
            else
            {
                result[i] = arr[right--];
            }
        }

        return result;
    }
}
