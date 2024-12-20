using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution909
{
    /// <summary>
    /// 909. Snakes and Ladders - Medium
    /// <a href="https://leetcode.com/problems/snakes-and-ladders">See the problem</a>
    /// </summary>
    public int SnakesAndLadders(int[][] board)
    {
        var n = board.Length;
        var visited = new bool[n * n];
        var queue = new Queue<int>();
        queue.Enqueue(1);
        visited[0] = true;
        var steps = 0;
        while (queue.Count > 0)
        {
            var size = queue.Count;
            for (var i = 0; i < size; i++)
            {
                var current = queue.Dequeue();
                if (current == n * n)
                {
                    return steps;
                }
                for (var j = 1; j <= 6 && current + j <= n * n; j++)
                {
                    var next = current + j;
                    var row = n - 1 - (next - 1) / n;
                    var col = (n - 1 - row) % 2 == 0 ? (next - 1) % n : n - 1 - (next - 1) % n;
                    if (board[row][col] != -1)
                    {
                        next = board[row][col];
                    }
                    if (!visited[next - 1])
                    {
                        visited[next - 1] = true;
                        queue.Enqueue(next);
                    }
                }
            }
            steps++;
        }
        return -1;
    }
}
