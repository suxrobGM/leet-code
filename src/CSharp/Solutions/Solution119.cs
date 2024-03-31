namespace LeetCode.Solutions;

public class Solution119
{
    /// <summary>
    /// 119. Pascal's Triangle II - Easy
    /// <a href="https://leetcode.com/problems/pascals-triangle-ii">See the problem</a>
    /// </summary>
    public IList<int> GetRow(int rowIndex)
    {
        var triangle = new List<int[]>();

        for (var i = 0; i < rowIndex + 1; i++)
        {
            var row = new int[i + 1];
            Array.Fill(row, 1);
            
            for (var j = 1; j < i; j++)
            {
                row[j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
            }

            if (i == rowIndex)
            {
                return row;
            }
            
            triangle.Add(row);
        }
        
        return [0];
    }
}
