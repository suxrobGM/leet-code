using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1036
{
    /// <summary>
    /// 1036. Escape a Large Maze - Hard
    /// <a href="https://leetcode.com/problems/escape-a-large-maze</a>
    /// </summary>
    public bool IsEscapePossible(int[][] blocked, int[] source, int[] target)
    {
        int N = 1_000_000;
        var blockedSet = new HashSet<(int, int)>();
        foreach (var block in blocked)
        {
            blockedSet.Add((block[0], block[1]));
        }

        return IsEscapePossible(blockedSet, source, target, N) && IsEscapePossible(blockedSet, target, source, N);
    }

    private bool IsEscapePossible(HashSet<(int, int)> blocked, int[] source, int[] target, int N)
    {
        var visited = new HashSet<(int, int)>();
        var queue = new Queue<(int, int)>();
        queue.Enqueue((source[0], source[1]));

        int[][] directions = [[0, 1], [0, -1], [1, 0], [-1, 0]];

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            visited.Add(current);

            if (current.Item1 == target[0] && current.Item2 == target[1])
            {
                return true;
            }

            foreach (var dir in directions)
            {
                int r = current.Item1 + dir[0], c = current.Item2 + dir[1];
                if (r >= 0 && r < N && c >= 0 && c < N && !visited.Contains((r, c)) && !blocked.Contains((r, c)))
                {
                    queue.Enqueue((r, c));
                    visited.Add((r, c));
                }
            }

            if (visited.Count == 20000)
            {
                return true;
            }
        }

        return false;
    }
}
