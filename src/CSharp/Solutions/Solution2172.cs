namespace LeetCode.Solutions;

public class Solution2172
{
    /// <summary>
    /// 2172. Maximum AND Sum of Array - Hard
    /// <a href="https://leetcode.com/problems/maximum-and-sum-of-array">See the problem</a>
    /// </summary>
    public int MaximumANDSum(int[] nums, int numSlots)
    {
        // Each slot holds at most 2 numbers, so encode the occupancy of all
        // slots as a base-3 number (0, 1, or 2 items per slot). The number of
        // items already placed equals the sum of the digits, which tells us
        // which number from nums to place next.
        var pow3 = new int[numSlots + 1];
        pow3[0] = 1;
        for (int i = 1; i <= numSlots; i++)
        {
            pow3[i] = pow3[i - 1] * 3;
        }

        int totalStates = pow3[numSlots];
        var dp = new int[totalStates];

        for (int mask = 0; mask < totalStates; mask++)
        {
            // Count how many numbers have been placed so far (sum of digits).
            int placed = 0;
            int temp = mask;
            for (int i = 0; i < numSlots; i++)
            {
                placed += temp % 3;
                temp /= 3;
            }

            if (placed >= nums.Length)
            {
                continue;
            }

            int num = nums[placed];
            // Try placing the next number into any slot with room left.
            for (int slot = 0; slot < numSlots; slot++)
            {
                int digit = mask / pow3[slot] % 3;
                if (digit < 2)
                {
                    int next = mask + pow3[slot];
                    int gain = num & (slot + 1);
                    dp[next] = Math.Max(dp[next], dp[mask] + gain);
                }
            }
        }

        return dp.Max();
    }
}
