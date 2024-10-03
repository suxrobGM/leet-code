namespace LeetCode.Solutions;

public class Solution598
{
    /// <summary>
    /// 598. Range Addition II - Easy
    /// <a href="https://leetcode.com/problems/range-addition-ii">See the problem</a>
    /// </summary>
    public int MaxCount(int m, int n, int[][] ops)
    {
        var minRow = m;
        var minCol = n;
        foreach (var op in ops)
        {
            minRow = Math.Min(minRow, op[0]);
            minCol = Math.Min(minCol, op[1]);
        }
        return minRow * minCol;
    }
}
