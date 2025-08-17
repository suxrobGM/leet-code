using System.Text;

namespace LeetCode.Solutions;

public class Solution1769
{
    /// <summary>
    /// 1769. Minimum Number of Operations to Move All Balls to Each Box - Medium
    /// <a href="https://leetcode.com/problems/minimum-number-of-operations-to-move-all-balls-to-each-box">See the problem</a>
    /// </summary>
    public int[] MinOperations(string boxes)
    {
        int n = boxes.Length;
        var ans = new int[n];

        // Left to right
        int balls = 0, moves = 0;
        for (int i = 0; i < n; i++)
        {
            ans[i] += moves;
            if (boxes[i] == '1') balls++;
            moves += balls;
        }

        // Right to left
        balls = 0; moves = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            ans[i] += moves;
            if (boxes[i] == '1') balls++;
            moves += balls;
        }

        return ans;
    }
}
