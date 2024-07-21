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

        char[] hexChars = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f'];
        var number = (uint)num; // Treat num as unsigned to handle two's complement automatically.
        var result = "";

        while (number != 0)
        {
            result = hexChars[number & 15] + result; // Get the last 4 bits and find the corresponding hex char.
            number >>= 4; // Shift the number 4 bits to the right.
        }

        return result;
    }
}
