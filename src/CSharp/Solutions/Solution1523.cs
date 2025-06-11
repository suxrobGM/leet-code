using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1523
{
    /// <summary>
    /// 1523. Count Odd Numbers in an Interval Range - Easy
    /// <a href="https://leetcode.com/problems/count-odd-numbers-in-an-interval-range">See the problem</a>
    /// </summary>
    public int CountOdds(int low, int high)
    {
        // The count of odd numbers in the range [low, high] can be calculated as follows:
        // If low is odd, we include it; if high is odd, we include it.
        // The total count of numbers in the range is (high - low + 1).
        // If the count is even, half will be odd; if odd, half + 1 will be odd.

        return (high - low + 1 + (low % 2 == 1 ? 1 : 0) + (high % 2 == 1 ? 1 : 0)) / 2;
    }
}
