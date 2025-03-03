using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1041
{
    /// <summary>
    /// 1041. Robot Bounded In Circle - Medium
    /// <a href="https://leetcode.com/problems/robot-bounded-in-circle</a>
    /// </summary>
    public bool IsRobotBounded(string instructions)
    {
        int x = 0, y = 0;
        int dir = 0;
        var dirs = new int[,] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };

        foreach (char c in instructions)
        {
            if (c == 'L')
            {
                dir = (dir + 3) % 4;
            }
            else if (c == 'R')
            {
                dir = (dir + 1) % 4;
            }
            else
            {
                x += dirs[dir, 0];
                y += dirs[dir, 1];
            }
        }

        return (x == 0 && y == 0) || dir != 0;
    }
}
