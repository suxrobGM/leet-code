using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1869
{
    /// <summary>
    /// 1869. Longer Contiguous Segments of Ones than Zeros - Easy
    /// <a href="https://leetcode.com/problems/longer-contiguous-segments-of-ones-than-zeros">See the problem</a>
    /// </summary>
    public bool CheckZeroOnes(string s)
    {
        int maxOnes = 0;
        int maxZeros = 0;

        int currentOnes = 0;
        int currentZeros = 0;

        foreach (char c in s)
        {
            if (c == '1')
            {
                currentOnes++;
                currentZeros = 0;
                maxOnes = Math.Max(maxOnes, currentOnes);
            }
            else // c == '0'
            {
                currentZeros++;
                currentOnes = 0;
                maxZeros = Math.Max(maxZeros, currentZeros);
            }
        }

        return maxOnes > maxZeros;
    }
}
