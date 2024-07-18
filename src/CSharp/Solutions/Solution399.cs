namespace LeetCode.Solutions;

public class Solution399
{
    /// <summary>
    /// 399. Evaluate Division - Medium
    /// <a href="https://leetcode.com/problems/evaluate-division">See the problem</a>
    /// </summary>
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        var graph = new Dictionary<string, Dictionary<string, double>>();

        for (var i = 0; i < equations.Count; i++)
        {
            var dividend = equations[i][0];
            var divisor = equations[i][1];
            var value = values[i];

            if (!graph.ContainsKey(dividend))
            {
                graph[dividend] = new Dictionary<string, double>();
            }

            if (!graph.ContainsKey(divisor))
            {
                graph[divisor] = new Dictionary<string, double>();
            }

            graph[dividend][divisor] = value;
            graph[divisor][dividend] = 1 / value;
        }

        var result = new double[queries.Count];

        for (var i = 0; i < queries.Count; i++)
        {
            var dividend = queries[i][0];
            var divisor = queries[i][1];

            if (!graph.ContainsKey(dividend) || !graph.ContainsKey(divisor))
            {
                result[i] = -1;
            }
            else if (dividend == divisor)
            {
                result[i] = 1;
            }
            else
            {
                result[i] = Dfs(graph, dividend, divisor, new HashSet<string>());
            }
        }

        return result;
    }

    private double Dfs(Dictionary<string, Dictionary<string, double>> graph, string start, string end, HashSet<string> visited)
    {
        if (start == end)
        {
            return 1;
        }

        visited.Add(start);

        foreach (var neighbor in graph[start])
        {
            if (visited.Contains(neighbor.Key))
            {
                continue;
            }

            var result = Dfs(graph, neighbor.Key, end, visited);

            if (result != -1)
            {
                return result * neighbor.Value;
            }
        }

        return -1;
    }
}
