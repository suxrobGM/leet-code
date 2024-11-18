using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution830
{
    /// <summary>
    /// 830. Positions of Large Groups - Easy
    /// <a href="https://leetcode.com/problems/positions-of-large-groups">See the problem</a>
    /// </summary>
    public IList<IList<int>> LargeGroupPositions(string s)
    {
        var result = new List<IList<int>>();
        var n = s.Length;
        var start = 0;
        var count = 1;

        for (var i = 1; i < n; i++)
        {
            if (s[i] == s[i - 1])
            {
                count++;
            }
            else
            {
                if (count >= 3)
                {
                    result.Add(new List<int> { start, i - 1 });
                }

                start = i;
                count = 1;
            }
        }

        if (count >= 3)
        {
            result.Add(new List<int> { start, n - 1 });
        }

        return result;
    }
}
