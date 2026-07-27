namespace LeetCode.Solutions;

public class Solution2220
{
    /// <summary>
    /// 2220. Minimum Bit Flips to Convert Number - Easy
    /// <a href="https://leetcode.com/problems/minimum-bit-flips-to-convert-number">See the problem</a>
    /// </summary>
    public int MinBitFlips(int start, int goal)
    {
        int xor = start ^ goal;
        int count = 0;

        while (xor > 0)
        {
            count += xor & 1;
            xor >>= 1;
        }

        return count;
    }
}
