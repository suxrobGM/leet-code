using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution789
{
    /// <summary>
    /// 789. Escape The Ghosts - Medium
    /// <a href="https://leetcode.com/problems/escape-the-ghosts">See the problem</a>
    /// </summary>
    public bool EscapeGhosts(int[][] ghosts, int[] target)
    {
        var distance = Math.Abs(target[0]) + Math.Abs(target[1]);
        foreach (var ghost in ghosts)
        {
            var ghostDistance = Math.Abs(ghost[0] - target[0]) + Math.Abs(ghost[1] - target[1]);
            if (ghostDistance <= distance)
            {
                return false;
            }
        }

        return true;
    }
}
