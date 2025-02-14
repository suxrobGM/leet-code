using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution990
{
    /// <summary>
    /// 990. Satisfiability of Equality Equations - Medium
    /// <a href="https://leetcode.com/problems/satisfiability-of-equality-equations">See the problem</a>
    /// </summary>
    public bool EquationsPossible(string[] equations)
    {
        var parent = new int[26];

        for (int i = 0; i < 26; i++)
        {
            parent[i] = i;
        }

        foreach (var equation in equations)
        {
            if (equation[1] == '=')
            {
                var x = equation[0] - 'a';
                var y = equation[3] - 'a';

                Union(parent, x, y);
            }
        }

        foreach (var equation in equations)
        {
            if (equation[1] == '!')
            {
                var x = equation[0] - 'a';
                var y = equation[3] - 'a';

                if (Find(parent, x) == Find(parent, y))
                {
                    return false;
                }
            }
        }

        return true;
    }

    private void Union(int[] parent, int x, int y)
    {
        parent[Find(parent, x)] = Find(parent, y);
    }

    private int Find(int[] parent, int x)
    {
        if (parent[x] != x)
        {
            parent[x] = Find(parent, parent[x]);
        }

        return parent[x];
    }
}
