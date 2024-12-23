using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution913
{
    /// <summary>
    /// 913. Cat and Mouse - Hard
    /// <a href="https://leetcode.com/problems/cat-and-mouse">See the problem</a>
    /// </summary>
    public int CatMouseGame(int[][] graph)
    {
        var n = graph.Length;
        var dp = new int[n, n, 2]; // dp[mouse][cat][turn]
        var degree = new int[n, n];
        var queue = new Queue<(int, int, int)>();

        // Initialize degrees for each state
        for (int mouse = 0; mouse < n; mouse++)
        {
            for (int cat = 0; cat < n; cat++)
            {
                degree[mouse, cat] = graph[mouse].Length + (cat == 0 ? 0 : graph[cat].Length);
            }
        }

        // Terminal states initialization
        for (int i = 0; i < n; i++)
        {
            for (int turn = 0; turn < 2; turn++)
            {
                dp[0, i, turn] = 1; // Mouse wins if it reaches the hole
                dp[i, i, turn] = 2; // Cat wins if it catches the mouse
                queue.Enqueue((0, i, turn));
                queue.Enqueue((i, i, turn));
            }
        }

        // BFS backward propagation
        while (queue.Count > 0)
        {
            var (mouse, cat, turn) = queue.Dequeue();
            int result = dp[mouse, cat, turn];
            int prevTurn = 1 - turn;

            foreach (var prevState in GetPrevStates(mouse, cat, turn, graph))
            {
                int prevMouse = prevState.Item1, prevCat = prevState.Item2, prevTurnState = prevState.Item3;

                if (dp[prevMouse, prevCat, prevTurnState] > 0) continue;

                if (result == prevTurnState + 1)
                {
                    dp[prevMouse, prevCat, prevTurnState] = result;
                    queue.Enqueue((prevMouse, prevCat, prevTurnState));
                }
                else
                {
                    degree[prevMouse, prevCat]--;
                    if (degree[prevMouse, prevCat] == 0)
                    {
                        dp[prevMouse, prevCat, prevTurnState] = 3 - result;
                        queue.Enqueue((prevMouse, prevCat, prevTurnState));
                    }
                }
            }
        }

        return dp[1, 2, 0];
    }

    private List<(int, int, int)> GetPrevStates(int mouse, int cat, int turn, int[][] graph)
    {
        var prevStates = new List<(int, int, int)>();
        if (turn == 0)
        { // Mouse's turn
            foreach (var prevMouse in graph[mouse])
            {
                prevStates.Add((prevMouse, cat, 1));
            }
        }
        else
        { // Cat's turn
            foreach (var prevCat in graph[cat])
            {
                if (prevCat != 0)
                { // Cat can't move to the hole
                    prevStates.Add((mouse, prevCat, 0));
                }
            }
        }
        return prevStates;
    }
}
