using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1310
{
    /// <summar
    /// 1310. XOR Queries of a Subarray - Medium
    /// <a href="https://leetcode.com/problems/xor-queries-of-a-subarray">See the problem</a>
    /// </summary>
    public int[] XorQueries(int[] arr, int[][] queries)
    {
        int n = arr.Length;
        var prefixXor = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            prefixXor[i + 1] = prefixXor[i] ^ arr[i];
        }

        int m = queries.Length;
        var result = new int[m];
        for (int i = 0; i < m; i++)
        {
            int left = queries[i][0];
            int right = queries[i][1];
            result[i] = prefixXor[right + 1] ^ prefixXor[left];
        }

        return result;
    }
}
