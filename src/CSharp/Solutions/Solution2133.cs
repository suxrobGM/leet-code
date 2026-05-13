namespace LeetCode.Solutions;

public class Solution2133
{
    /// <summary>
    /// 2133. Check if Every Row and Column Contains All Numbers - Easy
    /// <a href="https://leetcode.com/problems/check-if-every-row-and-column-contains-all-numbers">See the problem</a>
    /// </summary>
    public bool CheckValid(int[][] matrix)
    {
        int n = matrix.Length;
        for (int i = 0; i < n; i++)
        {
            var rowSet = new HashSet<int>();
            var colSet = new HashSet<int>();
            for (int j = 0; j < n; j++)
            {
                rowSet.Add(matrix[i][j]);
                colSet.Add(matrix[j][i]);
            }

            if (rowSet.Count != n || colSet.Count != n)
            {
                return false;
            }
        }

        return true;
    }
}
