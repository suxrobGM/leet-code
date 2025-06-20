using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1557
{
    /// <summary>
    /// 1557. Minimum Number of Vertices to Reach All Nodes - Medium
    /// <a href="https://leetcode.com/problems/minimum-number-of-vertices-to-reach-all-nodes">See the problem</a>
    /// </summary>
    public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
    {
        var indegree = new int[n];
        foreach (var edge in edges)
        {
            indegree[edge[1]]++;
        }

        var result = new List<int>();
        for (int i = 0; i < n; i++)
        {
            if (indegree[i] == 0)
            {
                result.Add(i);
            }
        }

        return result;
    }
}
