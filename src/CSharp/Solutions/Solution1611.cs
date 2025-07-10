using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1611
{
    /// <summary>
    /// 1611. Minimum One Bit Operations to Make Integers Zero - Hard
    /// <a href="https://leetcode.com/problems/minimum-one-bit-operations-to-make-integers-zero">See the problem</a>
    /// </summary>
    public int MinimumOneBitOperations(int n)
    {
        int count = 0;
        while (n > 0)
        {
            count ^= n;
            n >>= 1;
        }
        return count;
    }
}
