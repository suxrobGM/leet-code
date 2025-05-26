using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1476
{
    /// <summary>
    /// 1476. Subrectangle Queries - Medium
    /// <a href="https://leetcode.com/problems/subrectangle-queries">See the problem</a>
    /// </summary>
    public class SubrectangleQueries
    {
        private readonly int[][] rectangle;

        public SubrectangleQueries(int[][] rectangle)
        {
            this.rectangle = rectangle;
        }

        public void UpdateSubrectangle(int row1, int col1, int row2, int col2, int newValue)
        {
            for (int i = row1; i <= row2; i++)
            {
                for (int j = col1; j <= col2; j++)
                {
                    rectangle[i][j] = newValue;
                }
            }
        }

        public int GetValue(int row, int col)
        {
            return rectangle[row][col];
        }
    }
}
