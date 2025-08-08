using System.Text;


namespace LeetCode.Solutions;

public class Solution1696
{
    /// <summary>
    /// 1696. Jump Game VI - Medium
    /// <a href="https://leetcode.com/problems/jump-game-vi">See the problem</a>
    /// </summary>
    public int MaxResult(int[] nums, int k)
    {
        int n = nums.Length;
        var dp = new int[n];
        dp[0] = nums[0];

        // Deque storing indices with decreasing dp values
        var dq = new LinkedList<int>();
        dq.AddLast(0);

        for (int i = 1; i < n; i++)
        {
            // Remove indices out of window [i-k, i-1]
            while (dq.Count > 0 && dq.First.Value < i - k)
                dq.RemoveFirst();

            // Best previous dp is at the front
            dp[i] = nums[i] + dp[dq.First.Value];

            // Maintain decreasing dp in deque
            while (dq.Count > 0 && dp[dq.Last.Value] <= dp[i])
                dq.RemoveLast();

            dq.AddLast(i);
        }

        return dp[n - 1];
    }
}
