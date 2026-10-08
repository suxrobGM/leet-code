using System.Text;

namespace LeetCode.Solutions;

public class Solution2306
{
    /// <summary>
    /// 2306. Naming a Company - Hard
    /// <a href="https://leetcode.com/problems/naming-a-company">See the problem</a>
    /// </summary>
    public long DistinctNames(string[] ideas)
    {
        // Group suffixes by their first letter
        var groups = new HashSet<string>[26];
        for (int i = 0; i < 26; i++)
        {
            groups[i] = [];
        }

        foreach (var idea in ideas)
        {
            groups[idea[0] - 'a'].Add(idea[1..]);
        }

        long result = 0;

        for (int i = 0; i < 26; i++)
        {
            for (int j = i + 1; j < 26; j++)
            {
                // Suffixes shared by both groups produce an existing name after swapping
                int common = 0;
                foreach (var suffix in groups[i])
                {
                    if (groups[j].Contains(suffix))
                    {
                        common++;
                    }
                }

                // Each valid pair can be ordered two ways (A B and B A)
                result += 2L * (groups[i].Count - common) * (groups[j].Count - common);
            }
        }

        return result;
    }
}
