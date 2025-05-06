using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1318
{
    /// <summary>
    /// 1318. Minimum Flips to Make a OR b Equal to c - Medium
    /// <a href="https://leetcode.com/problems/minimum-flips-to-make-a-or-b-equal-to-c">See the problem</a>
    /// </summary>
    public int MinFlips(int a, int b, int c)
    {
        int flips = 0;
        for (int i = 0; i < 32; i++)
        {
            int bitA = (a >> i) & 1;
            int bitB = (b >> i) & 1;
            int bitC = (c >> i) & 1;

            if ((bitA | bitB) != bitC)
            {
                if (bitC == 1)
                {
                    flips += 1;
                }
                else
                {
                    flips += bitA + bitB;
                }
            }
        }
        return flips;
    }
}
