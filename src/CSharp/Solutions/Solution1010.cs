using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1010
{
    /// <summary>
    /// 1010. Pairs of Songs With Total Durations Divisible by 60 - Medium
    /// <a href="https://leetcode.com/problems/pairs-of-songs-with-total-durations-divisible-by-60</a>
    /// </summary>
    public int NumPairsDivisibleBy60(int[] time)
    {
        var count = 0;
        var remainders = new int[60];

        foreach (var t in time)
        {
            var remainder = t % 60;
            var complement = (60 - remainder) % 60;
            count += remainders[complement];
            remainders[remainder]++;
        }

        return count;
    }
}
