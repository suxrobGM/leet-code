using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution838
{
    /// <summary>
    /// 838. Push Dominoes - Medium
    /// <a href="https://leetcode.com/problems/push-dominoes">See the problem</a>
    /// </summary>
    public string PushDominoes(string dominoes)
    {
        var n = dominoes.Length;
        var forces = new int[n];

        var force = 0;
        for (var i = 0; i < n; i++)
        {
            if (dominoes[i] == 'R') force = n;
            else if (dominoes[i] == 'L') force = 0;
            else force = Math.Max(force - 1, 0);
            forces[i] += force;
        }

        force = 0;
        for (var i = n - 1; i >= 0; i--)
        {
            if (dominoes[i] == 'L') force = n;
            else if (dominoes[i] == 'R') force = 0;
            else force = Math.Max(force - 1, 0);
            forces[i] -= force;
        }

        var sb = new StringBuilder();
        foreach (var f in forces)
        {
            sb.Append(f > 0 ? 'R' : f < 0 ? 'L' : '.');
        }

        return sb.ToString();
    }
}
