using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1001
{
    /// <summary>
    /// 1001. Grid Illumination - Hard
    /// <a href="https://leetcode.com/problems/grid-illumination</a>
    /// </summary>
    public int[] GridIllumination(int n, int[][] lamps, int[][] queries)
    {
        var rowMap = new Dictionary<int, int>();
        var colMap = new Dictionary<int, int>();
        var diagMap1 = new Dictionary<int, int>();
        var diagMap2 = new Dictionary<int, int>();
        var lampSet = new HashSet<(int, int)>();

        // Step 1: Initialize lamp positions
        foreach (var lamp in lamps)
        {
            int r = lamp[0], c = lamp[1];
            if (lampSet.Contains((r, c))) continue;

            lampSet.Add((r, c));
            if (!rowMap.ContainsKey(r)) rowMap[r] = 0;
            rowMap[r]++;
            if (!colMap.ContainsKey(c)) colMap[c] = 0;
            colMap[c]++;
            if (!diagMap1.ContainsKey(r - c)) diagMap1[r - c] = 0;
            diagMap1[r - c]++;
            if (!diagMap2.ContainsKey(r + c)) diagMap2[r + c] = 0;
            diagMap2[r + c]++;
        }

        int[] result = new int[queries.Length];
        int[][] directions = { new[] { 0, 0 }, new[] { 0, 1 }, new[] { 0, -1 }, new[] { 1, 0 }, new[] { -1, 0 }, 
                               new[] { 1, 1 }, new[] { 1, -1 }, new[] { -1, 1 }, new[] { -1, -1 } };

        // Step 2: Process each query
        for (int i = 0; i < queries.Length; i++)
        {
            int r = queries[i][0], c = queries[i][1];

            // Query if the cell is illuminated
            if (rowMap.ContainsKey(r) || colMap.ContainsKey(c) || diagMap1.ContainsKey(r - c) || diagMap2.ContainsKey(r + c))
                result[i] = 1;
            else
                result[i] = 0;

            // Step 3: Turn off lamp at (r, c) and its adjacent lamps
            foreach (var dir in directions)
            {
                int nr = r + dir[0], nc = c + dir[1];
                if (lampSet.Contains((nr, nc)))
                {
                    lampSet.Remove((nr, nc));
                    if (--rowMap[nr] == 0) rowMap.Remove(nr);
                    if (--colMap[nc] == 0) colMap.Remove(nc);
                    if (--diagMap1[nr - nc] == 0) diagMap1.Remove(nr - nc);
                    if (--diagMap2[nr + nc] == 0) diagMap2.Remove(nr + nc);
                }
            }
        }

        return result;
    }
}
