namespace LeetCode.Solutions;

public class Solution2049
{
    /// <summary>
    /// 2049. Count Nodes With the Highest Score - Medium
    /// <a href="https://leetcode.com/problems/count-nodes-with-the-highest-score">See the problem</a>
    /// </summary>
    public int CountHighestScoreNodes(int[] parents)
    {
        var n = parents.Length;
        var children = new List<int>[n];
        for (var i = 0; i < n; i++)
            children[i] = new List<int>();

        for (var i = 1; i < n; i++)
            children[parents[i]].Add(i);

        var maxScore = 0L;
        var count = 0;
        Dfs(0);
        return count;

        long Dfs(int node)
        {
            var score = 1L;
            var size = 1L;
            foreach (var child in children[node])
            {
                var childSize = Dfs(child);
                score *= childSize;
                size += childSize;
            }

            if (node != 0)
                score *= Math.Max(1, n - size);

            if (score > maxScore)
            {
                maxScore = score;
                count = 1;
            }
            else if (score == maxScore)
                count++;

            return size;
        }
    }
}
