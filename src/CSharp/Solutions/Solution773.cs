using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution773
{
    /// <summary>
    /// 773. Sliding Puzzle - Hard
    /// <a href="https://leetcode.com/problems/sliding-puzzle">See the problem</a>
    /// </summary>
    public int SlidingPuzzle(int[][] board)
    {
        var target = "123450";
        var start = "";

        // Flatten the board to a string
        for (var i = 0; i < 2; i++)
        {
            for (var j = 0; j < 3; j++)
            {
                start += board[i][j].ToString();
            }
        }

        // If the starting state is already the target
        if (start == target) return 0;

        // Map of possible moves for each position in the 2x3 board
        int[][] moves = [
            [1, 3],
            [0, 2, 4],
            [1, 5],
            [0, 4],
            [1, 3, 5],
            [2, 4]
        ];

        var queue = new Queue<(string, int)>(); // (board configuration, move count)
        var visited = new HashSet<string>();

        queue.Enqueue((start, 0));
        visited.Add(start);

        while (queue.Count > 0)
        {
            var (current, steps) = queue.Dequeue();
            var zeroIndex = current.IndexOf('0');

            // Generate all possible moves
            foreach (var move in moves[zeroIndex])
            {
                var newConfig = Swap(current, zeroIndex, move);

                if (newConfig == target)
                {
                    return steps + 1; // Found solution
                }

                if (!visited.Contains(newConfig))
                {
                    visited.Add(newConfig);
                    queue.Enqueue((newConfig, steps + 1));
                }
            }
        }

        return -1; // Unsolvable case
    }

    private string Swap(string s, int i, int j)
    {
        var arr = s.ToCharArray();
        var temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
        return new string(arr);
    }
}
