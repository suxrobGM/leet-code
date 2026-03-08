namespace LeetCode.Solutions;

public class Solution2056
{
    /// <summary>
    /// 2056. Number of Valid Move Combinations On Chessboard - Hard
    /// <a href="https://leetcode.com/problems/number-of-valid-move-combinations-on-chessboard">See the problem</a>
    /// </summary>
    private static readonly int[][] RookDirs = [[0, 1], [0, -1], [1, 0], [-1, 0]];
    private static readonly int[][] BishopDirs = [[1, 1], [1, -1], [-1, 1], [-1, -1]];
    private static readonly int[][] QueenDirs = [[0, 1], [0, -1], [1, 0], [-1, 0], [1, 1], [1, -1], [-1, 1], [-1, -1]];

    public int CountCombinations(string[] pieces, int[][] positions)
    {
        var n = pieces.Length;
        var moves = new List<(int r, int c, int dr, int dc, int steps)>[n];

        for (var i = 0; i < n; i++)
        {
            moves[i] = [];
            var r = positions[i][0];
            var c = positions[i][1];
            moves[i].Add((r, c, 0, 0, 0));

            var dirs = pieces[i] switch
            {
                "rook" => RookDirs,
                "bishop" => BishopDirs,
                _ => QueenDirs
            };

            foreach (var d in dirs)
            {
                for (var s = 1; s <= 7; s++)
                {
                    var nr = r + s * d[0];
                    var nc = c + s * d[1];
                    if (nr < 1 || nr > 8 || nc < 1 || nc > 8) break;
                    moves[i].Add((r, c, d[0], d[1], s));
                }
            }
        }

        var chosen = new (int r, int c, int dr, int dc, int steps)[n];
        return Backtrack(0, n, moves, chosen);
    }

    private static int Backtrack(int idx, int n,
        List<(int r, int c, int dr, int dc, int steps)>[] moves,
        (int r, int c, int dr, int dc, int steps)[] chosen)
    {
        if (idx == n) return 1;

        var count = 0;
        foreach (var move in moves[idx])
        {
            if (IsValid(idx, move, chosen))
            {
                chosen[idx] = move;
                count += Backtrack(idx + 1, n, moves, chosen);
            }
        }

        return count;
    }

    private static bool IsValid(int idx,
        (int r, int c, int dr, int dc, int steps) move,
        (int r, int c, int dr, int dc, int steps)[] chosen)
    {
        for (var i = 0; i < idx; i++)
        {
            var other = chosen[i];
            for (var t = 0; t <= 7; t++)
            {
                var r1 = move.r + Math.Min(t, move.steps) * move.dr;
                var c1 = move.c + Math.Min(t, move.steps) * move.dc;
                var r2 = other.r + Math.Min(t, other.steps) * other.dr;
                var c2 = other.c + Math.Min(t, other.steps) * other.dc;
                if (r1 == r2 && c1 == c2) return false;
            }
        }

        return true;
    }
}
