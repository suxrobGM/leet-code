using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1329
{
    /// <summary>
    /// 1329. Sort the Matrix Diagonally - Medium
    /// <a href="https://leetcode.com/problems/sort-the-matrix-diagonally">See the problem</a>
    /// </summary>
    public int[][] DiagonalSort(int[][] mat)
    {
        int m = mat.Length;
        int n = mat[0].Length;
        var diagonals = new Dictionary<int, List<int>>();

        // Collect elements in each diagonal
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int diagKey = i - j;
                if (!diagonals.ContainsKey(diagKey))
                {
                    diagonals[diagKey] = new List<int>();
                }
                diagonals[diagKey].Add(mat[i][j]);
            }
        }

        // Sort each diagonal
        foreach (var key in diagonals.Keys)
        {
            diagonals[key].Sort();
        }

        // Reassign sorted values back to the matrix
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int diagKey = i - j;
                mat[i][j] = diagonals[diagKey][0];
                diagonals[diagKey].RemoveAt(0);
            }
        }

        return mat;
    }
}
