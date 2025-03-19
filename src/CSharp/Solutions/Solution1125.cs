using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1125
{
    /// <summary>
    /// 1125. Smallest Sufficient Team - Hard
    /// <a href="https://leetcode.com/problems/smallest-sufficient-team">See the problem</a>
    /// </summary>
    public int[] SmallestSufficientTeam(string[] req_skills, IList<IList<string>> people)
    {
        var n = req_skills.Length;
        var m = people.Count;
        var dp = new Dictionary<int, List<int>> { [0] = [] };
        var skillMap = new Dictionary<string, int>();

        for (var i = 0; i < n; i++)
        {
            skillMap[req_skills[i]] = i;
        }

        for (var i = 0; i < m; i++)
        {
            var skill = 0;

            foreach (var s in people[i])
            {
                skill |= 1 << skillMap[s];
            }

            foreach (var (key, value) in new Dictionary<int, List<int>>(dp))
            {
                var newSkill = key | skill;

                if (!dp.ContainsKey(newSkill) || dp[newSkill].Count > value.Count + 1)
                {
                    dp[newSkill] = [.. value, i];
                }
            }
        }

        return [.. dp[(1 << n) - 1]];
    }
}
