using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1654
{
    /// <summary>
    /// 1654. Minimum Jumps to Reach Home - Medium
    /// <a href="https://leetcode.com/problems/minimum-jumps-to-reach-home">See the problem</a>
    /// </summary>
    public int MinimumJumps(int[] forbidden, int a, int b, int x)
    {
        var forbiddenSet = new HashSet<int>(forbidden);
        var visited = new HashSet<(int pos, bool back)>();
        var queue = new Queue<(int pos, bool back)>();

        queue.Enqueue((0, false));
        visited.Add((0, false));

        int jumps = 0;
        int maxLimit = 6000; // Safe upper bound

        while (queue.Count > 0)
        {
            int size = queue.Count;
            while (size-- > 0)
            {
                var (pos, back) = queue.Dequeue();

                if (pos == x) return jumps;

                // Forward jump
                int nextF = pos + a;
                if (nextF <= maxLimit && !forbiddenSet.Contains(nextF) && !visited.Contains((nextF, false)))
                {
                    visited.Add((nextF, false));
                    queue.Enqueue((nextF, false));
                }

                // Backward jump (only if last wasn't a backward jump)
                int nextB = pos - b;
                if (!back && nextB >= 0 && !forbiddenSet.Contains(nextB) && !visited.Contains((nextB, true)))
                {
                    visited.Add((nextB, true));
                    queue.Enqueue((nextB, true));
                }
            }

            jumps++;
        }

        return -1;
    }
}
