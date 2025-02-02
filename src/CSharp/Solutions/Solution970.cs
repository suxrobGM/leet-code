using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution970
{
    /// <summary>
    /// 970. Powerful Integers - Medium
    /// <a href="https://leetcode.com/problems/powerful-integers">See the problem</a>
    /// </summary>
    public IList<int> PowerfulIntegers(int x, int y, int bound)
    {
        var result = new List<int>();
        var set = new HashSet<int>();

        for (var i = 0; i < 20 && Math.Pow(x, i) <= bound; i++)
        {
            for (var j = 0; j < 20 && Math.Pow(y, j) <= bound; j++)
            {
                var sum = (int)Math.Pow(x, i) + (int)Math.Pow(y, j);
                if (sum <= bound)
                {
                    set.Add(sum);
                }
            }
        }

        result.AddRange(set);
        return result;
    }
}
