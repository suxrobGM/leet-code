namespace LeetCode.Solutions;

public class Solution2027
{
    /// <summary>
    /// 2027. Minimum Moves to Convert String - Easy
    /// <a href="https://leetcode.com/problems/minimum-moves-to-convert-string">See the problem</a>
    /// </summary>
    public int MinimumMoves(string s)
    {
        var moves = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == 'X')
            {
                moves++;
                i += 2; // Skip next two characters as they will be converted to 'O'
            }
        }
        return moves;
    }
}
