using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1284
{
    /// <summary>
    /// 1284. Minimum Number of Flips to Convert Binary Matrix to Zero Matrix - Hard
    /// <a href="https://leetcode.com/problems/minimum-number-of-flips-to-convert-binary-matrix-to-zero-matrix">See the problem</a>
    /// </summary>
    public int MinFlips(int[][] mat)
    {
        int m = mat.Length, n = mat[0].Length;
        int target = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                target |= mat[i][j] << (i * n + j);
            }
        }

        var queue = new Queue<int>();
        var visited = new HashSet<int>();
        queue.Enqueue(target);
        visited.Add(target);

        int flips = 0;
        while (queue.Count > 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                int current = queue.Dequeue();
                if (current == 0) return flips;

                foreach (var next in GetNextStates(current, m, n))
                {
                    if (!visited.Contains(next))
                    {
                        visited.Add(next);
                        queue.Enqueue(next);
                    }
                }
            }
            flips++;
        }

        return -1;
    }

    private IEnumerable<int> GetNextStates(int state, int m, int n)
    {
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int nextState = state ^ (1 << (i * n + j));
                if (i > 0) nextState ^= (1 << ((i - 1) * n + j));
                if (i < m - 1) nextState ^= (1 << ((i + 1) * n + j));
                if (j > 0) nextState ^= (1 << (i * n + j - 1));
                if (j < n - 1) nextState ^= (1 << (i * n + j + 1));
                yield return nextState;
            }
        }
    }
}
