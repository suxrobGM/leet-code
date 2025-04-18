using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1263
{
    private readonly int[] dr = [-1, 1, 0, 0];
    private readonly int[] dc = [0, 0, -1, 1];

    /// <summary>
    /// 1263. Minimum Moves to Move a Box to Their Target Location - Hard
    /// <a href="https://leetcode.com/problems/minimum-moves-to-move-a-box-to-their-target-location">See the problem</a>
    /// </summary>
    public int MinPushBox(char[][] grid)
    {
        int rows = grid.Length, cols = grid[0].Length;
        (int r, int c) box = (0, 0), player = (0, 0), target = (0, 0);

        // 1. locate S, B, T
        for (int r = 0; r < rows; ++r)
        {
            for (int c = 0; c < cols; ++c)
            {
                switch (grid[r][c])
                {
                    case 'S': player = (r, c); break;
                    case 'B': box = (r, c); break;
                    case 'T': target = (r, c); break;
                }
            }
        }

        // visited[boxR, boxC, playerR, playerC]
        bool[,,,] seen = new bool[rows, cols, rows, cols];
        var dq = new System.Collections.Generic.LinkedList<State>();
        dq.AddLast(new State(box.r, box.c, player.r, player.c, 0));
        seen[box.r, box.c, player.r, player.c] = true;

        while (dq.Count > 0)
        {
            var cur = dq.First.Value;
            dq.RemoveFirst();

            if (cur.BoxR == target.r && cur.BoxC == target.c)
                return cur.Pushes;

            // 0‑cost edges: move player alone
            for (int k = 0; k < 4; ++k)
            {
                int nr = cur.PlayerR + dr[k], nc = cur.PlayerC + dc[k];
                if (!Inside(nr, nc, rows, cols)) continue;
                if (grid[nr][nc] == '#') continue;
                if (nr == cur.BoxR && nc == cur.BoxC) continue; // can't walk through box

                if (!seen[cur.BoxR, cur.BoxC, nr, nc])
                {
                    seen[cur.BoxR, cur.BoxC, nr, nc] = true;
                    dq.AddFirst(new State(cur.BoxR, cur.BoxC, nr, nc, cur.Pushes)); // cost 0
                }
            }

            // 1‑cost edges: push box
            for (int k = 0; k < 4; ++k)
            {
                int needR = cur.BoxR - dr[k], needC = cur.BoxC - dc[k]; // player must stand here
                int newBoxR = cur.BoxR + dr[k], newBoxC = cur.BoxC + dc[k];

                if (!Inside(needR, needC, rows, cols) || !Inside(newBoxR, newBoxC, rows, cols))
                    continue;
                if (grid[needR][needC] == '#' || grid[newBoxR][newBoxC] == '#')
                    continue;

                // player must be exactly at needR, needC
                if (cur.PlayerR != needR || cur.PlayerC != needC) continue;

                if (!seen[newBoxR, newBoxC, cur.BoxR, cur.BoxC])
                {
                    seen[newBoxR, newBoxC, cur.BoxR, cur.BoxC] = true;
                    dq.AddLast(new State(newBoxR, newBoxC, cur.BoxR, cur.BoxC, cur.Pushes + 1)); // cost 1
                }
            }
        }
        return -1;
    }

    private bool Inside(int r, int c, int rows, int cols) =>
        r >= 0 && r < rows && c >= 0 && c < cols;

    private readonly record struct State(int BoxR, int BoxC, int PlayerR, int PlayerC, int Pushes);
}
