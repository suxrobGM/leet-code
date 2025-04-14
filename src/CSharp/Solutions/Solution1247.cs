using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1247
{
    /// <summary>
    /// 1247. Minimum Swaps to Make Strings Equal - Medium
    /// <a href="https://leetcode.com/problems/minimum-swaps-to-make-strings-equal">See the problem</a>
    /// </summary>
    public int MinimumSwap(string s1, string s2)
    {
        int xy = 0, yx = 0;
        for (int i = 0; i < s1.Length; i++)
        {
            if (s1[i] != s2[i])
            {
                if (s1[i] == 'x')
                    xy++;
                else
                    yx++;
            }
        }

        if ((xy + yx) % 2 != 0)
            return -1;

        return xy / 2 + yx / 2 + xy % 2 * 2;
    }
}
