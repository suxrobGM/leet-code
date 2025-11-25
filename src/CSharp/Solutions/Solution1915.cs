using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1915
{
    /// <summary>
    /// 1915. Number of Wonderful Substrings - Medium
    /// <a href="https://leetcode.com/problems/number-of-wonderful-substrings">See the problem</a>
    /// </summary>
    public long WonderfulSubstrings(string word)
    {
        long result = 0;
        var count = new Dictionary<int, long>();
        int mask = 0;
        count[0] = 1;

        foreach (char c in word)
        {
            int bit = c - 'a';
            mask ^= (1 << bit);

            if (count.ContainsKey(mask))
                result += count[mask];

            for (int i = 0; i < 10; i++)
            {
                int toggledMask = mask ^ (1 << i);
                if (count.ContainsKey(toggledMask))
                    result += count[toggledMask];
            }

            if (!count.ContainsKey(mask))
                count[mask] = 0;
            count[mask]++;
        }

        return result;
    }
}
