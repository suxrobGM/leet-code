using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution868
{
    /// <summary>
    /// 868. Binary Gap - Easy
    /// <a href="https://leetcode.com/problems/binary-gap">See the problem</a>
    /// </summary>
    public int BinaryGap(int n)
    {
        int result = 0;
        int last = -1;
        int i = 0;

        while (n > 0)
        {
            if ((n & 1) == 1)
            {
                if (last != -1)
                {
                    result = Math.Max(result, i - last);
                }

                last = i;
            }

            n >>= 1;
            i++;
        }

        return result;
    }
}
