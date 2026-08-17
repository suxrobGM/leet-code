namespace LeetCode.Solutions;

public class Solution2246
{
    /// <summary>
    /// 2246. Longest Path With Different Adjacent Characters - Hard
    /// <a href="https://leetcode.com/problems/longest-path-with-different-adjacent-characters">See the problem</a>
    /// </summary>
    public int LongestPath(int[] parent, string s)
    {
        var n = parent.Length;

        // Children as linked lists to avoid allocating a list per node
        var firstChild = new int[n];
        var nextSibling = new int[n];
        Array.Fill(firstChild, -1);
        Array.Fill(nextSibling, -1);
        for (var node = n - 1; node >= 1; node--)
        {
            nextSibling[node] = firstChild[parent[node]];
            firstChild[parent[node]] = node;
        }

        // BFS from the root so parents can be processed after their children
        var order = new int[n];
        var count = 0;
        order[count++] = 0;
        for (var i = 0; i < count; i++)
        {
            for (var child = firstChild[order[i]]; child != -1; child = nextSibling[child])
            {
                order[count++] = child;
            }
        }

        // longest[node] = longest downward chain starting at node with distinct adjacent characters
        var longest = new int[n];
        var best = 1;
        for (var i = n - 1; i >= 0; i--)
        {
            var node = order[i];
            var top1 = 0;
            var top2 = 0;
            for (var child = firstChild[node]; child != -1; child = nextSibling[child])
            {
                if (s[child] == s[node])
                {
                    continue;
                }

                var chain = longest[child];
                if (chain > top1)
                {
                    top2 = top1;
                    top1 = chain;
                }
                else if (chain > top2)
                {
                    top2 = chain;
                }
            }

            longest[node] = top1 + 1;
            best = Math.Max(best, top1 + top2 + 1);
        }

        return best;
    }
}
