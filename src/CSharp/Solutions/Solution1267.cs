using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1267
{
    /// <summary>
    /// 1267. Count Servers that Communicate - Medium
    /// <a href="https://leetcode.com/problems/count-servers-that-communicate">See the problem</a>
    /// </summary>
    public int CountServers(int[][] grid)
    {
        int rows = grid.Length, cols = grid[0].Length;
        int[] rowCount = new int[rows], colCount = new int[cols];
        for (int r = 0; r < rows; ++r)
        {
            for (int c = 0; c < cols; ++c)
            {
                if (grid[r][c] == 1)
                {
                    rowCount[r]++;
                    colCount[c]++;
                }
            }
        }

        int count = 0;
        for (int r = 0; r < rows; ++r)
        {
            for (int c = 0; c < cols; ++c)
            {
                if (grid[r][c] == 1 && (rowCount[r] > 1 || colCount[c] > 1))
                {
                    count++;
                }
            }
        }

        return count;
    }
}
