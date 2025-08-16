using System.Text;
using LeetCode.DataStructures;


namespace LeetCode.Solutions;

public class Solution1728
{
    private const int MOUSE_WIN = 1;
    private const int CAT_WIN = 2;

    /// <summary>
    /// 1728. Cat and Mouse II - Hard
    /// <a href="https://leetcode.com/problems/cat-and-mouse-ii">See the problem</a>
    /// </summary>
    public bool CanMouseWin(string[] grid, int catJump, int mouseJump)
    {
        int R = grid.Length, C = grid[0].Length;
        int N = R * C;

        int Id(int r, int c) => r * C + c;
        (int r, int c) RC(int id) => (id / C, id % C);

        // Identify walkable cells and positions
        bool[] walk = new bool[N];
        int mouseStart = -1, catStart = -1, food = -1;

        for (int r = 0; r < R; r++)
        {
            for (int c = 0; c < C; c++)
            {
                char ch = grid[r][c];
                if (ch != '#')
                {
                    walk[Id(r, c)] = true;
                    if (ch == 'M') mouseStart = Id(r, c);
                    else if (ch == 'C') catStart = Id(r, c);
                    else if (ch == 'F') food = Id(r, c);
                }
            }
        }

        // Precompute moves for each cell for mouse and cat (including "stay")
        var mouseMoves = new List<int>[N];
        var catMoves = new List<int>[N];
        var mouseRev = new List<int>[N];
        var catRev = new List<int>[N];
        for (int i = 0; i < N; i++)
        {
            mouseMoves[i] = new List<int>();
            catMoves[i] = new List<int>();
            mouseRev[i] = new List<int>();
            catRev[i] = new List<int>();
        }

        int[] dr = { 1, -1, 0, 0 };
        int[] dc = { 0, 0, 1, -1 };

        void AddMoves(List<int>[] moves, List<int>[] rev, int jump)
        {
            for (int id = 0; id < N; id++)
            {
                if (!walk[id]) continue;
                moves[id].Add(id); // staying put
                var (r0, c0) = RC(id);
                for (int d = 0; d < 4; d++)
                {
                    for (int step = 1; step <= jump; step++)
                    {
                        int r = r0 + dr[d] * step;
                        int c = c0 + dc[d] * step;
                        if (r < 0 || r >= R || c < 0 || c >= C) break;
                        int nid = Id(r, c);
                        if (!walk[nid]) break; // can't jump over wall
                        moves[id].Add(nid);
                    }
                }
            }
            // Build reverse edges
            for (int from = 0; from < N; from++)
            {
                if (!walk[from]) continue;
                foreach (var to in moves[from])
                {
                    rev[to].Add(from);
                }
            }
        }

        AddMoves(mouseMoves, mouseRev, mouseJump);
        AddMoves(catMoves, catRev, catJump);

        // Map 3D state to 1D
        int V = N * N * 2;
        int Index(int m, int c, int turn) => ((m * N) + c) * 2 + turn;

        var color = new byte[V]; // 0 unknown, 1 mouse win, 2 cat win
        var degree = new short[V];

        // Initialize degrees (depend only on mover position)
        for (int m = 0; m < N; m++)
        {
            if (!walk[m]) continue;
            for (int c = 0; c < N; c++)
            {
                if (!walk[c]) continue;
                degree[Index(m, c, 0)] = (short)mouseMoves[m].Count; // mouse turn
                degree[Index(m, c, 1)] = (short)catMoves[c].Count;   // cat turn
            }
        }

        var q = new Queue<int>();

        void EnqueueTerminal(int m, int c, int winColor)
        {
            // Set both turns since terminal regardless of who moves
            int a = Index(m, c, 0);
            int b = Index(m, c, 1);
            if (color[a] == 0) { color[a] = (byte)winColor; q.Enqueue(a); }
            if (color[b] == 0) { color[b] = (byte)winColor; q.Enqueue(b); }
        }

        // Initialize terminal states
        for (int m = 0; m < N; m++)
        {
            if (!walk[m]) continue;
            for (int c = 0; c < N; c++)
            {
                if (!walk[c]) continue;

                if (m == food) EnqueueTerminal(m, c, MOUSE_WIN);
                else if (c == food || c == m) EnqueueTerminal(m, c, CAT_WIN);
            }
        }

        // Reverse BFS
        while (q.Count > 0)
        {
            int s = q.Dequeue();
            int turn = s & 1;
            int cc = s >> 1;
            int cPos = cc % N;
            int mPos = cc / N;

            int result = color[s];

            // Enumerate predecessors (the player who moved in predecessor leads to 's')
            if (turn == 0)
            {
                // s is a MOUSE turn state -> predecessor was CAT turn
                // Cat moved from cp to cPos, mouse stayed mPos
                foreach (var cp in catRev[cPos])
                {
                    if (!walk[cp]) continue;
                    int p = Index(mPos, cp, 1);
                    if (color[p] != 0) continue;

                    if (result == CAT_WIN)
                    {
                        // If child is CAT_WIN and it is mouse's turn there,
                        // then parent (cat's turn) can move to a winning (for cat) child -> parent CAT_WIN
                        color[p] = CAT_WIN;
                        q.Enqueue(p);
                    }
                    else
                    {
                        // Child is MOUSE_WIN: bad for cat. Reduce degree; if no moves avoid MOUSE_WIN, parent loses
                        degree[p]--;
                        if (degree[p] == 0)
                        {
                            color[p] = MOUSE_WIN;
                            q.Enqueue(p);
                        }
                    }
                }
            }
            else
            {
                // s is a CAT turn state -> predecessor was MOUSE turn
                // Mouse moved from mp to mPos, cat stayed cPos
                foreach (var mp in mouseRev[mPos])
                {
                    if (!walk[mp]) continue;
                    int p = Index(mp, cPos, 0);
                    if (color[p] != 0) continue;

                    if (result == MOUSE_WIN)
                    {
                        // Child MOUSE_WIN on cat's turn -> parent (mouse's turn) can move to win
                        color[p] = MOUSE_WIN;
                        q.Enqueue(p);
                    }
                    else
                    {
                        // Child CAT_WIN: bad for mouse
                        degree[p]--;
                        if (degree[p] == 0)
                        {
                            color[p] = CAT_WIN;
                            q.Enqueue(p);
                        }
                    }
                }
            }
        }

        // Initial state: mouse moves first
        int start = Index(mouseStart, catStart, 0);
        return color[start] == MOUSE_WIN;
    }
}
