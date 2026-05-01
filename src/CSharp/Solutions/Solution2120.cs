using System.Numerics;

namespace LeetCode.Solutions;

public class Solution2120
{
    /// <summary>
    /// 2120. Execution of All Suffix Instructions Staying in a Grid - Medium
    /// <a href="https://leetcode.com/problems/execution-of-all-suffix-instructions-staying-in-a-grid">See the problem</a>
    /// </summary>
    public int[] ExecuteInstructions(int n, int[] startPos, string s)
    {
        var result = new int[s.Length];
        for (var i = 0; i < s.Length; i++)
        {
            var x = startPos[0];
            var y = startPos[1];
            for (var j = i; j < s.Length; j++)
            {
                switch (s[j])
                {
                    case 'L':
                        y--;
                        break;
                    case 'R':
                        y++;
                        break;
                    case 'U':
                        x--;
                        break;
                    case 'D':
                        x++;
                        break;
                }

                if (x < 0 || x >= n || y < 0 || y >= n)
                {
                    break;
                }

                result[i]++;
            }
        }

        return result;
    }
}
