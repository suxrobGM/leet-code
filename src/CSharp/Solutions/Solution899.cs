using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution899
{
    /// <summary>
    /// 899. Orderly Queue - Hard
    /// <a href="https://leetcode.com/problems/orderly-queue">See the problem</a>
    /// </summary>
    public string OrderlyQueue(string s, int k)
    {
        if (k == 1)
        {
            var result = s;
            for (var i = 1; i < s.Length; i++)
            {
                var current = s.Substring(i) + s.Substring(0, i);
                if (string.CompareOrdinal(current, result) < 0)
                {
                    result = current;
                }
            }
            return result;
        }
        else
        {
            var chars = s.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }
    }
}
