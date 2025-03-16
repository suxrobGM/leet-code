using System.Text;

namespace LeetCode.Solutions;

public class Solution1108
{
    /// <summary>
    /// 1108. Defanging an IP Address - Easy
    /// <a href="https://leetcode.com/problems/defanging-an-ip-address">See the problem</a>
    /// </summary>
    public string DefangIPaddr(string address)
    {
        var sb = new StringBuilder();
        foreach (var c in address)
        {
            if (c == '.')
            {
                sb.Append("[.]");
            }
            else
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }
}
