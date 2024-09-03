using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution517
{
    /// <summary>
    /// 517. Super Washing Machines - Hard
    /// <a href="https://leetcode.com/problems/super-washing-machines">See the problem</a>
    /// </summary>
    public int FindMinMoves(int[] machines)
    {
        var sum = machines.Sum();
        var n = machines.Length;

        if (sum % n != 0)
        {
            return -1;
        }

        var target = sum / n;
        var result = 0;
        var leftSum = 0;
        var rightSum = sum;

        for (var i = 0; i < n; i++)
        {
            rightSum -= machines[i];
            var leftDiff = Math.Max(i * target - leftSum, 0);
            var rightDiff = Math.Max((n - i - 1) * target - rightSum, 0);
            result = Math.Max(result, leftDiff + rightDiff);
            leftSum += machines[i];
        }

        return result;
    }
}
