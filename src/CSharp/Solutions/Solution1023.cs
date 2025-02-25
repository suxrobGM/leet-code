using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1023
{
    /// <summary>
    /// 1023. Camelcase Matching - Medium
    /// <a href="https://leetcode.com/problems/camelcase-matching</a>
    /// </summary>
    public IList<bool> CamelMatch(string[] queries, string pattern)
    {
        var result = new List<bool>();
        foreach (var query in queries)
        {
            result.Add(IsMatch(query, pattern));
        }

        return result;
    }

    private bool IsMatch(string query, string pattern)
    {
        var i = 0;
        var j = 0;
        while (i < query.Length && j < pattern.Length)
        {
            if (query[i] == pattern[j])
            {
                i++;
                j++;
            }
            else if (char.IsUpper(query[i]))
            {
                return false;
            }
            else
            {
                i++;
            }
        }

        while (i < query.Length)
        {
            if (char.IsUpper(query[i]))
            {
                return false;
            }
            i++;
        }

        return j == pattern.Length;
    }
}
