using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1252
{
    /// <summary>
    /// 1252. Cells with Odd Values in a Matrix - Easy
    /// <a href="https://leetcode.com/problems/cells-with-odd-values-in-a-matrix">See the problem</a>
    /// </summary>
    public int OddCells(int m, int n, int[][] indices)
    {
        var matrix = new int[m, n];
        foreach (var index in indices)
        {
            for (int i = 0; i < n; i++)
                matrix[index[0], i]++;
            for (int i = 0; i < m; i++)
                matrix[i, index[1]]++;
        }

        int count = 0;
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                if (matrix[i, j] % 2 != 0) count++;

        return count;
    }
}
