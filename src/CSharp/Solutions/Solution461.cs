using System.Text;

namespace LeetCode.Solutions;

public class Solution461
{
    /// <summary>
    /// 461. Hamming Distance - Easy
    /// <a href="https://leetcode.com/problems/hamming-distance">See the problem</a>
    /// </summary>
    public int HammingDistance(int x, int y)
    {
        var xor = x ^ y;
        var distance = 0;

        while (xor > 0)
        {
            distance += xor & 1;
            xor >>= 1;
        }

        return distance;
    }
}
