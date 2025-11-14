using System.Numerics;
using System.Text;

namespace LeetCode.Solutions;

public class Solution1900
{
    /// <summary>
    /// 1900. The Earliest and Latest Rounds Where Players Compete - Hard
    /// <a href="https://leetcode.com/problems/the-earliest-and-latest-rounds-where-players-compete">See the problem</a>
    /// </summary>
    public int[] EarliestAndLatest(int n, int firstPlayer, int secondPlayer)
    {
        int a = firstPlayer, b = secondPlayer;
        if (a > b) (a, b) = (b, a);

        // bit i (0-based) represents player (i+1) is still in
        int fullMask = (n == 32) ? -1 : ((1 << n) - 1);

        int earliest = int.MaxValue;
        int latest = int.MinValue;

        // visited[round] = set of masks we've already processed at this round
        var visitedByRound = new Dictionary<int, HashSet<int>>();

        void Dfs(int mask, int round)
        {
            // avoid revisiting same mask at same round
            if (!visitedByRound.TryGetValue(round, out var seen))
            {
                seen = [];
                visitedByRound[round] = seen;
            }
            if (!seen.Add(mask)) return;

            // Build the current list of active players in ascending order
            var alive = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (((mask >> i) & 1) != 0) alive.Add(i + 1);
            }

            // Pair from both ends; collect all next-round masks that do NOT meet this round
            var nextMasks = new HashSet<int>();

            void BuildNext(int i, int j, int nextMask)
            {
                if (i > j)
                {
                    nextMasks.Add(nextMask);
                    return;
                }

                if (i == j)
                {
                    int p = alive[i];
                    nextMask |= (1 << (p - 1));
                    nextMasks.Add(nextMask);
                    return;
                }

                int L = alive[i];
                int R = alive[j];

                // If they meet in this round, record and do not continue this branch
                if ((L == a && R == b) || (L == b && R == a))
                {
                    earliest = Math.Min(earliest, round);
                    latest = Math.Max(latest, round);
                    return;
                }

                // If a/b is in this pair (but not both), the winner is forced
                if (L == a || L == b)
                {
                    BuildNext(i + 1, j - 1, nextMask | (1 << (L - 1)));
                }
                else if (R == a || R == b)
                {
                    BuildNext(i + 1, j - 1, nextMask | (1 << (R - 1)));
                }
                else
                {
                    // Free match: either can win; branch both ways
                    BuildNext(i + 1, j - 1, nextMask | (1 << (L - 1)));
                    BuildNext(i + 1, j - 1, nextMask | (1 << (R - 1)));
                }
            }

            BuildNext(0, alive.Count - 1, 0);

            // If all branches met in this round, we're done at this node
            if (nextMasks.Count == 0) return;

            // Otherwise, continue to next round for all distinct next masks
            foreach (var nm in nextMasks)
                Dfs(nm, round + 1);
        }

        Dfs(fullMask, 1);

        return [earliest, latest];
    }
}
