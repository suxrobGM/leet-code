using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1042
{
    /// <summary>
    /// 1042. Flower Planting With No Adjacent - Medium
    /// <a href="https://leetcode.com/problems/flower-planting-with-no-adjacent</a>
    /// </summary>
    public int[] GardenNoAdj(int n, int[][] paths)
    {
        var graph = new Dictionary<int, List<int>>();
        for (int i = 0; i < n; i++)
        {
            graph[i] = [];
        }

        foreach (var path in paths)
        {
            graph[path[0] - 1].Add(path[1] - 1);
            graph[path[1] - 1].Add(path[0] - 1);
        }

        var result = new int[n];
        for (int i = 0; i < n; i++)
        {
            var colors = new bool[5];
            foreach (var neighbor in graph[i])
            {
                colors[result[neighbor]] = true;
            }

            for (int j = 1; j <= 4; j++)
            {
                if (!colors[j])
                {
                    result[i] = j;
                    break;
                }
            }
        }

        return result;
    }
}
