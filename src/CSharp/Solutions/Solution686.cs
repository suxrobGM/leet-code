using System.Text;

namespace LeetCode.Solutions;

public class Solution686
{
    /// <summary>
    /// 686. Repeated String Match - Medium
    /// <a href="https://leetcode.com/problems/repeated-string-match">See the problem</a>
    /// </summary>
    public int RepeatedStringMatch(string a, string b)
    {
        var n = a.Length;
        var m = b.Length;

        var sb = new StringBuilder();
        var count = 0;

        while (sb.Length < m + n)
        {
            sb.Append(a);
            count++;
            if (sb.ToString().Contains(b))
            {
                return count;
            }
        }

        return -1;
    }
}
