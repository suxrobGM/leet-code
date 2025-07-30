using System.Text;


namespace LeetCode.Solutions;

public class Solution1674
{
    /// <summary>
    /// 1674. Minimum Moves to Make Array Complementary - Medium
    /// <a href="https://leetcode.com/problems/minimum-moves-to-make-array-complementary">See the problem</a>
    /// </summary>
    public int MinMoves(int[] nums, int limit)
    {
        int n = nums.Length;
        int[] delta = new int[2 * limit + 2];

        for (int i = 0; i < n / 2; i++)
        {
            int a = nums[i], b = nums[n - 1 - i];
            int low = Math.Min(a, b) + 1;
            int high = Math.Max(a, b) + limit;
            int sum = a + b;

            // Default 2 moves for everything
            delta[2] += 2;

            // One move region
            delta[low] -= 1;
            delta[high + 1] += 1;

            // Zero move point
            delta[sum] -= 1;
            delta[sum + 1] += 1;
        }

        int minMoves = int.MaxValue, curr = 0;
        for (int t = 2; t <= 2 * limit; t++)
        {
            curr += delta[t];
            minMoves = Math.Min(minMoves, curr);
        }

        return minMoves;
    }
}
