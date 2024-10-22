using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution672
{
    /// <summary>
    /// 672. Bulb Switcher II - Medium
    /// <a href="https://leetcode.com/problems/bulb-switcher-ii">See the problem</a>
    /// </summary>
    public int FlipLights(int n, int presses)
    {
        if (presses == 0)
        {
            return 1;
        }

        if (n == 1)
        {
            return 2;
        }

        if (n == 2)
        {
            return presses == 1 ? 3 : 4;
        }

        if (presses == 1)
        {
            return 4;
        }

        return presses == 2 ? 7 : 8;
    }
}
