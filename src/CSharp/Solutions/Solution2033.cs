namespace LeetCode.Solutions;

public class Solution2033
{
    /// <summary>
    /// 2033. Minimum Operations to Make a Uni-Value Grid - Medium
    /// <a href="https://leetcode.com/problems/minimum-operations-to-make-a-uni-value-grid">See the problem</a>
    /// </summary>
    public int MinOperations(int[][] grid, int x)
    {
        var flat = new List<int>();
        foreach (var row in grid)
            foreach (var cell in row)
                flat.Add(cell);

        flat.Sort();

        var median = flat[flat.Count / 2];
        var operations = 0;
        foreach (var value in flat)
        {
            if (Math.Abs(value - median) % x != 0)
                return -1;

            operations += Math.Abs(value - median) / x;
        }

        return operations;
    }
}
