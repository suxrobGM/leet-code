using System.Text;


namespace LeetCode.Solutions;

public class Solution1688
{
    /// <summary>
    /// 1688. Count of Matches in Tournament - Easy
    /// <a href="https://leetcode.com/problems/count-of-matches-in-tournament">See the problem</a>
    /// </summary>
    public int NumberOfMatches(int n)
    {
        // The number of matches is always n - 1
        // because each match eliminates one team.
        return n - 1;
    }
}
