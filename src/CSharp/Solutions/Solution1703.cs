using System.Text;


namespace LeetCode.Solutions;

public class Solution1703
{
    /// <summary>
    /// 1703. Minimum Adjacent Swaps for K Consecutive Ones - Hard
    /// <a href="https://leetcode.com/problems/minimum-adjacent-swaps-for-k-consecutive-ones">See the problem</a>
    /// </summary>
    public int MinMoves(int[] nums, int k)
    {
        if (k <= 1) return 0;

        // Collect positions of 1s
        var pos = new List<int>();
        for (int i = 0; i < nums.Length; i++)
            if (nums[i] == 1) pos.Add(i);

        int m = pos.Count;
        // Adjusted positions remove the arithmetic series penalty
        var adj = new long[m];
        for (int i = 0; i < m; i++) adj[i] = pos[i] - i;

        // Prefix sums of adjusted positions for fast window cost
        var ps = new long[m + 1];
        for (int i = 0; i < m; i++) ps[i + 1] = ps[i] + adj[i];

        long ans = long.MaxValue;

        for (int left = 0; left + k - 1 < m; left++)
        {
            int right = left + k - 1;
            int mid = left + k / 2;

            long median = adj[mid];

            // cost = sum |adj[j] - median| over j in [left..right]
            long leftCount = mid - left;
            long rightCount = right - mid;

            long leftSum = median * leftCount - (ps[mid] - ps[left]);
            long rightSum = (ps[right + 1] - ps[mid + 1]) - median * rightCount;

            long cost = leftSum + rightSum;

            // NOTE: With adjusted positions, no extra correction for even k needed.
            ans = Math.Min(ans, cost);
        }

        return (int)ans;
    }
}
