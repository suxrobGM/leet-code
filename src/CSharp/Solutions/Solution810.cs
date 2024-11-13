using System.Text;

namespace LeetCode.Solutions;

public class Solution810
{
    /// <summary>
    /// 810. Chalkboard XOR Game - Hard
    /// <a href="https://leetcode.com/problems/chalkboard-xor-game">See the problem</a>
    /// </summary>
    public bool XorGame(int[] nums)
    {
        var xor = 0;

        foreach (var num in nums)
        {
            xor ^= num;
        }

        return xor == 0 || nums.Length % 2 == 0;
    }
}
