namespace LeetCode.Solutions;

public class Solution2275
{
    /// <summary>
    /// 2275. Largest Combination With Bitwise AND Greater Than Zero - Medium
    /// <a href="https://leetcode.com/problems/largest-combination-with-bitwise-and-greater-than-zero">See the problem</a>
    /// </summary>
    public int LargestCombination(int[] candidates)
    {
        var bitCounts = new int[32];

        foreach (var candidate in candidates)
        {
            for (var bit = 0; bit < bitCounts.Length; bit++)
            {
                if ((candidate & (1 << bit)) != 0)
                {
                    bitCounts[bit]++;
                }
            }
        }

        return bitCounts.Max();
    }
}
