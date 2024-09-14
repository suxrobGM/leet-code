using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution547
{
    /// <summary>
    /// 547. Number of Provinces - Medium
    /// <a href="https://leetcode.com/problems/number-of-provinces">See the problem</a>
    /// </summary>
    public int FindCircleNum(int[][] isConnected)
    {
        int n = isConnected.Length;
        var visited = new bool[n];
        int provinces = 0;

        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                provinces++;
                DFS(isConnected, visited, i);
            }
        }

        return provinces;
    }

    private void DFS(int[][] isConnected, bool[] visited, int i)
    {
        visited[i] = true;

        for (int j = 0; j < isConnected.Length; j++)
        {
            if (isConnected[i][j] == 1 && !visited[j])
            {
                DFS(isConnected, visited, j);
            }
        }
    }
}
