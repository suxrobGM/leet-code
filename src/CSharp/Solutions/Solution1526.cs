using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1526
{
    /// <summary>
    /// 1526. Minimum Number of Increments on Subarrays to Form a Target Array - Hard
    /// <a href="https://leetcode.com/problems/minimum-number-of-increments-on-subarrays-to-form-a-target-array">See the problem</a>
    /// </summary>
    public int MinNumberOperations(int[] target)
    {
        int operations = target[0];

        for (int i = 1; i < target.Length; i++)
        {
            if (target[i] > target[i - 1])
            {
                operations += target[i] - target[i - 1];
            }
        }

        return operations;
    }
}
