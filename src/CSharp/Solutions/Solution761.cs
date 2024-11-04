using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution761
{
    /// <summary>
    /// 761. Special Binary String - Hard
    /// <a href="https://leetcode.com/problems/special-binary-string">See the problem</a>
    /// </summary>
    public string MakeLargestSpecial(string s)
    {
        var specialStrings = new List<string>();
        var count = 0;
        var start = 0;

        for (var i = 0; i < s.Length; i++)
        {
            count += s[i] == '1' ? 1 : -1;
            if (count == 0)
            {
                specialStrings.Add("1" + MakeLargestSpecial(s.Substring(start + 1, i - start - 1)) + "0");
                start = i + 1;
            }
        }

        specialStrings.Sort((a, b) => b.CompareTo(a));
        return string.Join("", specialStrings);
    }
}
