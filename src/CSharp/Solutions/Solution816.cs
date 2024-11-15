using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution816
{
    /// <summary>
    /// 816. Ambiguous Coordinates - Medium
    /// <a href="https://leetcode.com/problems/ambiguous-coordinates">See the problem</a>
    /// </summary>
    public IList<string> AmbiguousCoordinates(string s)
    {
        var result = new List<string>();
        var n = s.Length;

        for (var i = 2; i < n - 1; i++)
        {
            var left = GetNumbers(s.Substring(1, i - 1));
            var right = GetNumbers(s.Substring(i, n - i - 1));

            foreach (var l in left)
            {
                foreach (var r in right)
                {
                    result.Add($"({l}, {r})");
                }
            }
        }

        return result;
    }

    private List<string> GetNumbers(string s)
    {
        var result = new List<string>();
        var n = s.Length;

        if (n == 1)
        {
            result.Add(s);
        }
        else if (s[0] == '0' && s[n - 1] == '0')
        {
            return result;
        }
        else if (s[0] == '0')
        {
            result.Add($"0.{s[1..]}");
        }
        else if (s[n - 1] == '0')
        {
            result.Add(s);
        }
        else
        {
            result.Add(s);

            for (var i = 1; i < n; i++)
            {
                result.Add($"{s.Substring(0, i)}.{s.Substring(i)}");
            }
        }

        return result;
    }
}
