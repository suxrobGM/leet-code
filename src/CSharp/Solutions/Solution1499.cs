using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1499
{
    /// <summary>
    /// 1499. Max Value of Equation - Hard
    /// <a href="https://leetcode.com/problems/max-value-of-equation">See the problem</a>
    /// </summary>
    public int FindMaxValueOfEquation(int[][] points, int k)
    {
        int maxValue = int.MinValue;
        var deque = new System.Collections.Generic.LinkedList<int>();

        for (int i = 0; i < points.Length; i++)
        {
            // Remove points that are out of the range of k
            while (deque.Count > 0 && points[i][0] - points[deque.First.Value][0] > k)
            {
                deque.RemoveFirst();
            }

            // If deque is not empty, calculate the value
            if (deque.Count > 0)
            {
                int j = deque.First.Value;
                maxValue = Math.Max(maxValue, points[i][0] + points[i][1] + points[j][1] - points[j][0]);
            }

            // Maintain the deque in decreasing order of y - x
            while (deque.Count > 0 && points[deque.Last.Value][1] - points[deque.Last.Value][0] <= points[i][1] - points[i][0])
            {
                deque.RemoveLast();
            }

            deque.AddLast(i);
        }

        return maxValue;
    }
}
