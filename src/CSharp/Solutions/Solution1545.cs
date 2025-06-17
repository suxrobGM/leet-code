using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1545
{
    /// <summary>
    /// 1545. Find Kth Bit in Nth Binary String - Medium
    /// <a href="https://leetcode.com/problems/find-kth-bit-in-nth-binary-string">See the problem</a>
    /// </summary>
    public char FindKthBit(int n, int k)
    {
        var s = "0";

        for (int i = 1; i < n; i++)
        {
            var reversed = new string([.. s.Reverse()]);
            s += "1" + reversed.Replace('0', '2').Replace('1', '0').Replace('2', '1');
        }

        return s[k - 1];
    }
}
