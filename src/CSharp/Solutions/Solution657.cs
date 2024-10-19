using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution657
{
    /// <summary>
    /// 657. Robot Return to Origin - Easy
    /// <a href="https://leetcode.com/problems/robot-return-to-origin">See the problem</a>
    /// </summary>
    public bool JudgeCircle(string moves)
    {
        var x = 0;
        var y = 0;

        foreach (var move in moves)
        {
            switch (move)
            {
                case 'U':
                    y++;
                    break;
                case 'D':
                    y--;
                    break;
                case 'L':
                    x--;
                    break;
                case 'R':
                    x++;
                    break;
            }
        }

        return x == 0 && y == 0;
    }
}
