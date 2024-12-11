using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution893
{
    /// <summary>
    /// 893. Groups of Special-Equivalent Strings - Medium
    /// <a href="https://leetcode.com/problems/groups-of-special-equivalent-strings">See the problem</a>
    /// </summary>
    public int NumSpecialEquivGroups(string[] words)
    {
        var set = new HashSet<string>();

        foreach (var word in words)
        {
            var even = new int[26];
            var odd = new int[26];

            for (int i = 0; i < word.Length; i++)
            {
                if (i % 2 == 0)
                {
                    even[word[i] - 'a']++;
                }
                else
                {
                    odd[word[i] - 'a']++;
                }
            }

            var key = string.Join(",", even) + "," + string.Join(",", odd);
            set.Add(key);
        }

        return set.Count;
    }
}
