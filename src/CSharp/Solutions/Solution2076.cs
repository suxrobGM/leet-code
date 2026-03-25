namespace LeetCode.Solutions;

public class Solution2076
{
    /// <summary>
    /// 2076. Process Restricted Friend Requests - Hard
    /// <a href="https://leetcode.com/problems/process-restricted-friend-requests">See the problem</a>
    /// </summary>
    public bool[] FriendRequests(int n, int[][] restrictions, int[][] requests)
    {
        var parent = new int[n];
        var rank = new int[n];
        for (var i = 0; i < n; i++)
            parent[i] = i;

        var result = new bool[requests.Length];

        for (var i = 0; i < requests.Length; i++)
        {
            var pu = Find(parent, requests[i][0]);
            var pv = Find(parent, requests[i][1]);

            if (pu == pv)
            {
                result[i] = true;
                continue;
            }

            var violated = false;
            foreach (var r in restrictions)
            {
                var px = Find(parent, r[0]);
                var py = Find(parent, r[1]);
                if ((px == pu && py == pv) || (px == pv && py == pu))
                {
                    violated = true;
                    break;
                }
            }

            if (!violated)
            {
                Union(parent, rank, pu, pv);
                result[i] = true;
            }
        }

        return result;
    }

    private static int Find(int[] parent, int x)
    {
        while (parent[x] != x)
            x = parent[x] = parent[parent[x]];
        return x;
    }

    private static void Union(int[] parent, int[] rank, int x, int y)
    {
        if (rank[x] < rank[y]) (x, y) = (y, x);
        parent[y] = x;
        if (rank[x] == rank[y]) rank[x]++;
    }
}
