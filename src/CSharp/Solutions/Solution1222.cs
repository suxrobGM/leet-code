using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1222
{
    /// <summary>
    /// 1222. Queens That Can Attack the King - Medium
    /// <a href="https://leetcode.com/problems/queens-that-can-attack-the-king">See the problem</a>
    /// </summary>
    public IList<IList<int>> QueensAttacktheKing(int[][] queens, int[] king)
    {
        var result = new List<IList<int>>();
        var queenSet = new HashSet<string>();
        foreach (var queen in queens)
        {
            queenSet.Add($"{queen[0]},{queen[1]}");
        }

        int[][] directions = [
            [0, 1], [1, 0], [0, -1], [-1, 0],
            [1, 1], [-1, -1], [-1, 1], [1, -1]
        ];

        foreach (var direction in directions)
        {
            int x = king[0], y = king[1];
            while (true)
            {
                x += direction[0];
                y += direction[1];
                if (x < 0 || x >= 8 || y < 0 || y >= 8) break;
                if (queenSet.Contains($"{x},{y}"))
                {
                    result.Add(new List<int> { x, y });
                    break;
                }
            }
        }

        return result;
    }
}
