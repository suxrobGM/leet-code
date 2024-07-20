using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution405
{
    /// <summary>
    /// 405. Convert a Number to Hexadecimal - Easy
    /// <a href="https://leetcode.com/problems/convert-a-number-to-hexadecimal">See the problem</a>
    /// </summary>
    public string ToHex(int num)
    {
        if (num == 0)
        {
            return "0";
        }

        var result = new StringBuilder();

        while (num != 0)
        {
            var hex = num & 15;

            result.Insert(0, hex < 10 ? (char)(hex + '0') : (char)(hex - 10 + 'a'));

            num >>= 4;
        }

        return result.ToString();
    }
}
