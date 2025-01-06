using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution932
{
    /// <summary>
    /// 932. Beautiful Array - Medium
    /// <a href="https://leetcode.com/problems/beautiful-array">See the problem</a>
    /// </summary>
    public int[] BeautifulArray(int n)
    {
        var result = new List<int> { 1 };

        while (result.Count < n)
        {
            var temp = new List<int>();
            foreach (int x in result)
            {
                if (x * 2 - 1 <= n)
                {
                    temp.Add(x * 2 - 1); // Odd positions
                }
            }
            foreach (int x in result)
            {
                if (x * 2 <= n)
                {
                    temp.Add(x * 2); // Even positions
                }
            }
            result = temp;
        }

        return [.. result];
    }
}
