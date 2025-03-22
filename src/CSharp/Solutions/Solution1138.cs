using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1138
{
    /// <summary>
    /// 1138. Alphabet Board Path - Medium
    /// <a href="https://leetcode.com/problems/alphabet-board-path">See the problem</a>
    /// </summary>
    public string AlphabetBoardPath(string target)
    {
        var sb = new StringBuilder();
        var x = 0;
        var y = 0;

        foreach (var c in target)
        {
            var targetX = (c - 'a') / 5;
            var targetY = (c - 'a') % 5;

            while (x > targetX)
            {
                sb.Append('U');
                x--;
            }

            while (y > targetY)
            {
                sb.Append('L');
                y--;
            }

            while (x < targetX)
            {
                sb.Append('D');
                x++;
            }

            while (y < targetY)
            {
                sb.Append('R');
                y++;
            }

            sb.Append('!');
        }

        return sb.ToString();
    }
}
