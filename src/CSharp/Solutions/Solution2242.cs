namespace LeetCode.Solutions;

public class Solution2242
{
    /// <summary>
    /// 2242. Maximum Score of a Node Sequence - Hard
    /// <a href="https://leetcode.com/problems/maximum-score-of-a-node-sequence">See the problem</a>
    /// </summary>
    public int MaximumScore(int[] scores, int[][] edges)
    {
        // For every node keep only its three highest-scoring neighbours: a valid
        // sequence a-b-c-d uses at most two distinct neighbours of b (a and c),
        // so one of the top three is always available.
        var top = new List<int>[scores.Length];

        for (var i = 0; i < top.Length; i++)
        {
            top[i] = new List<int>(4);
        }

        foreach (var edge in edges)
        {
            AddNeighbor(top[edge[0]], edge[1], scores);
            AddNeighbor(top[edge[1]], edge[0], scores);
        }

        var best = -1;

        // Every sequence has a middle edge (b, c); extend it on both sides.
        foreach (var edge in edges)
        {
            var b = edge[0];
            var c = edge[1];

            foreach (var a in top[b])
            {
                if (a == c)
                {
                    continue;
                }

                foreach (var d in top[c])
                {
                    if (d == b || d == a)
                    {
                        continue;
                    }

                    best = Math.Max(best, scores[a] + scores[b] + scores[c] + scores[d]);
                }
            }
        }

        return best;
    }

    private static void AddNeighbor(List<int> neighbors, int node, int[] scores)
    {
        neighbors.Add(node);

        for (var i = neighbors.Count - 1; i > 0 && scores[neighbors[i]] > scores[neighbors[i - 1]]; i--)
        {
            (neighbors[i], neighbors[i - 1]) = (neighbors[i - 1], neighbors[i]);
        }

        if (neighbors.Count > 3)
        {
            neighbors.RemoveAt(neighbors.Count - 1);
        }
    }
}
