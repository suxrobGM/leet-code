using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution944
{
    /// <summary>
    /// 944. Delete Columns to Make Sorted - Easy
    /// <a href="https://leetcode.com/problems/delete-columns-to-make-sorted">See the problem</a>
    /// </summary>
    public int MinDeletionSize(string[] strs)
    {
        int n = strs.Length;
        int m = strs[0].Length;
        int count = 0;

        for (int j = 0; j < m; j++)
        {
            for (int i = 1; i < n; i++)
            {
                if (strs[i][j] < strs[i - 1][j])
                {
                    count++;
                    break;
                }
            }
        }

        return count;
    }
}
