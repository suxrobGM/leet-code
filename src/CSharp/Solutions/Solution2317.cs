namespace LeetCode.Solutions;

public class Solution2317
{
    /// <summary>
    /// 2317. Maximum XOR After Operations - Medium
    /// <a href="https://leetcode.com/problems/maximum-xor-after-operations">See the problem</a>
    /// </summary>
    public int MaximumXOR(int[] nums)
    {
        var result = 0;

        // Operations can clear set bits, so keep each available bit in exactly one number.
        foreach (var num in nums)
        {
            result |= num;
        }

        return result;
    }
}
