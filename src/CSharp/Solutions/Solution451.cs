using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution451
{
    /// <summary>
    /// 451. Sort Characters By Frequency - Medium
    /// <a href="https://leetcode.com/problems/sort-characters-by-frequency">See the problem</a>
    /// </summary>
    public string FrequencySort(string s)
    {
        var frequency = new Dictionary<char, int>();

        foreach (var c in s)
        {
            if (frequency.ContainsKey(c))
            {
                frequency[c]++;
            }
            else
            {
                frequency[c] = 1;
            }
        }

        var sorted = frequency.OrderByDescending(x => x.Value).Select(x => new string(x.Key, x.Value));
        return string.Concat(sorted);
    }
}
