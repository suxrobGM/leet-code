namespace LeetCode.Solutions;

public class Solution2092
{
    /// <summary>
    /// 2092. Find All People With Secret - Hard
    /// <a href="https://leetcode.com/problems/find-all-people-with-secret">See the problem</a>
    /// </summary>
    public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson)
    {
        var parent = new int[n];
        var rank = new int[n];
        for (var i = 0; i < n; i++) parent[i] = i;

        Union(parent, rank, 0, firstPerson);

        Array.Sort(meetings, (a, b) => a[2] - b[2]);

        var i2 = 0;
        while (i2 < meetings.Length)
        {
            var time = meetings[i2][2];
            var start = i2;
            while (i2 < meetings.Length && meetings[i2][2] == time)
            {
                Union(parent, rank, meetings[i2][0], meetings[i2][1]);
                i2++;
            }

            for (var j = start; j < i2; j++)
            {
                if (Find(parent, meetings[j][0]) != Find(parent, 0))
                {
                    parent[meetings[j][0]] = meetings[j][0];
                    rank[meetings[j][0]] = 0;
                }
                if (Find(parent, meetings[j][1]) != Find(parent, 0))
                {
                    parent[meetings[j][1]] = meetings[j][1];
                    rank[meetings[j][1]] = 0;
                }
            }
        }

        var result = new List<int>();
        for (var i = 0; i < n; i++)
            if (Find(parent, i) == Find(parent, 0))
                result.Add(i);

        return result;
    }

    private int Find(int[] parent, int x)
    {
        while (parent[x] != x)
        {
            parent[x] = parent[parent[x]];
            x = parent[x];
        }
        return x;
    }

    private void Union(int[] parent, int[] rank, int a, int b)
    {
        var ra = Find(parent, a);
        var rb = Find(parent, b);
        if (ra == rb) return;
        if (rank[ra] < rank[rb]) (ra, rb) = (rb, ra);
        parent[rb] = ra;
        if (rank[ra] == rank[rb]) rank[ra]++;
    }
}
