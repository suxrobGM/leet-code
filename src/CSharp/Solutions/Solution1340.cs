using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1340
{
    /// <summary>
    /// 1340. Jump Game V - Hard
    /// <a href="https://leetcode.com/problems/jump-game-v">See the problem</a>
    /// </summary>
    public int MaxJumps(int[] arr, int d)
    {
        int n = arr.Length;
        int[] memo = new int[n];
        Array.Fill(memo, -1);

        int result = 0;
        for (int i = 0; i < n; i++)
        {
            result = Math.Max(result, Dfs(i, arr, d, memo));
        }

        return result;
    }

    private int Dfs(int i, int[] arr, int d, int[] memo)
    {
        if (memo[i] != -1)
            return memo[i];

        int max = 1; // at least you can stay at index i

        // Go right
        for (int j = i + 1; j <= i + d && j < arr.Length && arr[j] < arr[i]; j++)
        {
            max = Math.Max(max, 1 + Dfs(j, arr, d, memo));
            if (arr[j] >= arr[i]) break; // no further jump possible
        }

        // Go left
        for (int j = i - 1; j >= i - d && j >= 0 && arr[j] < arr[i]; j--)
        {
            max = Math.Max(max, 1 + Dfs(j, arr, d, memo));
            if (arr[j] >= arr[i]) break; // no further jump possible
        }

        memo[i] = max;
        return max;
    }
}
