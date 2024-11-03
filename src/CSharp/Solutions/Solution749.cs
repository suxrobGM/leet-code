using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution749
{
    private static readonly int[][] directions = [
        [1, 0], [-1, 0], [0, 1], [0, -1]
    ];

    /// <summary>
    /// 749. Contain Virus - Hard
    /// <a href="https://leetcode.com/problems/contain-virus">See the problem</a>
    /// </summary>
    public int ContainVirus(int[][] isInfected)
    {
        int m = isInfected.Length, n = isInfected[0].Length;
        int totalWalls = 0;

        while (true)
        {
            // Identify each infected region and calculate walls and threats
            var regions = new List<HashSet<(int, int)>>();
            var threats = new List<HashSet<(int, int)>>();
            var walls = new List<int>();
            var visited = new bool[m, n];

            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (isInfected[i][j] == 1 && !visited[i, j])
                    {
                        var region = new HashSet<(int, int)>();
                        var threat = new HashSet<(int, int)>();
                        var wallCount = 0;

                        DFS(isInfected, i, j, visited, region, threat, ref wallCount);
                        regions.Add(region);
                        threats.Add(threat);
                        walls.Add(wallCount);
                    }
                }
            }

            if (regions.Count == 0) break;

            // Find the most dangerous region
            var maxThreatIdx = 0;
            for (var i = 1; i < threats.Count; i++)
            {
                if (threats[i].Count > threats[maxThreatIdx].Count)
                {
                    maxThreatIdx = i;
                }
            }

            // Add walls to contain the most dangerous region
            totalWalls += walls[maxThreatIdx];
            foreach (var cell in regions[maxThreatIdx])
            {
                isInfected[cell.Item1][cell.Item2] = -1;  // Quarantine this region
            }

            // Spread virus in other regions
            var anySpread = false;
            for (int i = 0; i < regions.Count; i++)
            {
                if (i == maxThreatIdx) continue; // Skip quarantined region

                foreach (var cell in threats[i])
                {
                    isInfected[cell.Item1][cell.Item2] = 1;
                    anySpread = true;
                }
            }

            if (!anySpread) break; // If no spread, we are done
        }

        return totalWalls;
    }

    private void DFS(int[][] isInfected, int x, int y, bool[,] visited, HashSet<(int, int)> region, HashSet<(int, int)> threat, ref int wallCount)
    {
        int m = isInfected.Length, n = isInfected[0].Length;
        visited[x, y] = true;
        region.Add((x, y));

        foreach (var dir in directions)
        {
            int nx = x + dir[0], ny = y + dir[1];

            if (nx < 0 || ny < 0 || nx >= m || ny >= n) continue;

            if (isInfected[nx][ny] == 1 && !visited[nx, ny])
            {
                DFS(isInfected, nx, ny, visited, region, threat, ref wallCount);
            }
            else if (isInfected[nx][ny] == 0)
            {
                threat.Add((nx, ny));
                wallCount++;
            }
        }
    }
}
