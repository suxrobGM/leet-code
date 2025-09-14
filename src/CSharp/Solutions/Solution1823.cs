using System.Text;

namespace LeetCode.Solutions;

public class Solution1823
{
    /// <summary>
    /// 1823. Find the Winner of the Circular Game - Medium
    /// <a href="https://leetcode.com/problems/find-the-winner-of-the-circular-game">See the problem</a>
    /// </summary>
    public int FindTheWinner(int n, int k)
    {
        int winner = 0; // base case: f(1, k) = 0
        for (int i = 2; i <= n; i++)
        {
            winner = (winner + k) % i;
        }
        return winner + 1; // convert to 1-based index
    }
}
