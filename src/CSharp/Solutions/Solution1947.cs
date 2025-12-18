using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1947
{
    /// <summary>
    /// 1947. Maximum Compatibility Score Sum - Medium
    /// <a href="https://leetcode.com/problems/maximum-compatibility-score-sum">See the problem</a>
    /// </summary>
    public int MaxCompatibilitySum(int[][] students, int[][] mentors)
    {
        var n = students.Length;
        var m = students[0].Length;
        var used = new bool[n];
        return Dfs(students, mentors, used, 0, n, m);
    }

    private int Dfs(int[][] students, int[][] mentors, bool[] used, int index, int n, int m)
    {
        if (index == n)
        {
            return 0;
        }

        var maxScore = 0;

        for (var i = 0; i < n; i++)
        {
            if (used[i])
            {
                continue;
            }

            used[i] = true;
            var score = CalculateCompatibilityScore(students[index], mentors[i], m);
            maxScore = Math.Max(maxScore, score + Dfs(students, mentors, used, index + 1, n, m));
            used[i] = false;
        }

        return maxScore;
    }

    private int CalculateCompatibilityScore(int[] student, int[] mentor, int m)
    {
        var score = 0;

        for (var i = 0; i < m; i++)
        {
            if (student[i] == mentor[i])
            {
                score++;
            }
        }

        return score;
    }
}
