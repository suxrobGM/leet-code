using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1886
{
    /// <summary>
    /// 1886. Determine Whether Matrix Can Be Obtained By Rotation - Easy
    /// <a href="https://leetcode.com/problems/determine-whether-matrix-can-be-obtained-by-rotation">See the problem</a>
    /// </summary>
    public bool FindRotation(int[][] mat, int[][] target)
    {
        int n = mat.Length;

        for (int rotation = 0; rotation < 4; rotation++)
        {
            bool match = true;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (mat[i][j] != target[i][j])
                    {
                        match = false;
                        break;
                    }
                }
                if (!match)
                    break;
            }

            if (match)
                return true;

            // Rotate the matrix 90 degrees clockwise
            mat = Rotate90Degrees(mat);
        }

        return false;
    }

    private int[][] Rotate90Degrees(int[][] matrix)
    {
        int n = matrix.Length;
        int[][] rotated = new int[n][];

        for (int i = 0; i < n; i++)
        {
            rotated[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                rotated[i][j] = matrix[n - j - 1][i];
            }
        }

        return rotated;
    }
}
