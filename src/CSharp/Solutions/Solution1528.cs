using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1528
{
    /// <summary>
    /// 1528. Shuffle String - Easy
    /// <a href="https://leetcode.com/problems/shuffle-string">See the problem</a>
    /// </summary>
    public string RestoreString(string s, int[] indices)
    {
        var result = new char[s.Length];

        for (int i = 0; i < s.Length; i++)
        {
            result[indices[i]] = s[i];
        }

        return new string(result);
    }
}
