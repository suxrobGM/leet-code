using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution859
{
    /// <summary>
    /// 859. Buddy Strings - Easy
    /// <a href="https://leetcode.com/problems/buddy-strings">See the problem</a>
    /// </summary>
    public bool BuddyStrings(string s, string goal)
    {
        if (s.Length != goal.Length)
        {
            return false;
        }

        if (s == goal)
        {
            int[] count = new int[26];
            foreach (char c in s)
            {
                count[c - 'a']++;
            }

            foreach (int c in count)
            {
                if (c > 1)
                {
                    return true;
                }
            }

            return false;
        }

        int first = -1;
        int second = -1;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != goal[i])
            {
                if (first == -1)
                {
                    first = i;
                }
                else if (second == -1)
                {
                    second = i;
                }
                else
                {
                    return false;
                }
            }
        }

        return second != -1 && s[first] == goal[second] && s[second] == goal[first];
    }
}
