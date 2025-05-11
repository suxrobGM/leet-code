using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1345
{
    /// <summary>
    /// 1345. Jump Game IV - Hard
    /// <a href="https://leetcode.com/problems/jump-game-iv">See the problem</a>
    /// </summary>
    public int MinJumps(int[] arr)
    {
        int n = arr.Length;
        if (n == 1) return 0;

        // Dictionary to store indices of each value
        var valueIndices = new Dictionary<int, List<int>>();
        for (int i = 0; i < n; i++)
        {
            if (!valueIndices.ContainsKey(arr[i]))
            {
                valueIndices[arr[i]] = [];
            }
            valueIndices[arr[i]].Add(i);
        }

        // BFS initialization
        var queue = new Queue<int>();
        var visited = new bool[n];
        queue.Enqueue(0);
        visited[0] = true;
        int jumps = 0;

        while (queue.Count > 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                int index = queue.Dequeue();

                // Check if we reached the last index
                if (index == n - 1) return jumps;

                // Check the next index
                if (index + 1 < n && !visited[index + 1])
                {
                    visited[index + 1] = true;
                    queue.Enqueue(index + 1);
                }

                // Check the previous index
                if (index - 1 >= 0 && !visited[index - 1])
                {
                    visited[index - 1] = true;
                    queue.Enqueue(index - 1);
                }

                // Check all indices with the same value
                if (valueIndices.ContainsKey(arr[index]))
                {
                    foreach (int nextIndex in valueIndices[arr[index]])
                    {
                        if (!visited[nextIndex])
                        {
                            visited[nextIndex] = true;
                            queue.Enqueue(nextIndex);
                        }
                    }
                    valueIndices.Remove(arr[index]); // Remove to prevent redundant checks
                }
            }
            jumps++;
        }

        return -1; // This line should never be reached
    }
}
