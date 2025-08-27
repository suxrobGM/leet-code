using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1760
{
    /// <summary>
    /// 1760. Minimum Limit of Balls in a Bag - Medium
    /// <a href="https://leetcode.com/problems/minimum-limit-of-balls-in-a-bag">See the problem</a>
    /// </summary>
    public int MinimumSize(int[] nums, int maxOperations)
    {
        int left = 1; // smallest possible penalty
        int right = nums.Max(); // largest possible penalty

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (CanDivide(nums, maxOperations, mid))
            {
                right = mid; // try smaller penalty
            }
            else
            {
                left = mid + 1; // need larger penalty
            }
        }

        return left;
    }

    private bool CanDivide(int[] nums, int maxOps, int penalty)
    {
        long ops = 0;
        foreach (int num in nums)
        {
            ops += (num - 1) / penalty;
            // equivalent to ceil(num/penalty) - 1 but avoids overflow
            if (ops > maxOps) return false;
        }
        return ops <= maxOps;
    }
}
