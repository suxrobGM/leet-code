using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution862
{
    /// <summary>
    /// 862. Shortest Subarray with Sum at Least K - Hard
    /// <a href="https://leetcode.com/problems/shortest-subarray-with-sum-at-least-k">See the problem</a>
    /// </summary>
    public int ShortestSubarray(int[] nums, int k)
    {
        var n = nums.Length;
        var prefix = new long[n + 1];
        
        for (int i = 0; i < n; i++)
        {
            prefix[i + 1] = prefix[i] + nums[i];
        }

        int minLength = int.MaxValue;
        var deque = new System.Collections.Generic.LinkedList<int>();

        for (int j = 0; j <= n; j++)
        {
            // Remove indices from the front if they satisfy the condition
            while (deque.Count > 0 && prefix[j] - prefix[deque.First.Value] >= k)
            {
                minLength = Math.Min(minLength, j - deque.First.Value);
                deque.RemoveFirst();
            }

            // Remove indices from the back if they are not useful
            while (deque.Count > 0 && prefix[j] <= prefix[deque.Last.Value])
            {
                deque.RemoveLast();
            }

            // Add the current index to the deque
            deque.AddLast(j);
        }

        return minLength == int.MaxValue ? -1 : minLength;
    }
}
