namespace LeetCode.Solutions;

public class Solution785
{
    /// <summary>
    /// 785. Is Graph Bipartite?
    /// <a href="https://leetcode.com/problems/is-graph-bipartite">See the problem</a>
    /// </summary>
    public bool IsBipartite(int[][] graph)
    {
        var colors = new int[graph.Length]; // 0: uncolored, 1: color A, -1: color B
        var queue = new Queue<int>(); // Queue for BFS
        Array.Fill(colors, 0); // Initialize all nodes as uncolored

        // It's possible the graph is not fully connected, so check each node
        for (var start = 0; start < graph.Length; start++)
        {
            // If this node is already colored, it's already checked
            if (colors[start] != 0)
            {
                continue;
            }
            
            queue.Enqueue(start); // Start BFS from this node
            colors[start] = 1; // Assign a color

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                foreach (var neighbor in graph[node])
                {
                    // If the neighbor is uncolored, color it with opposite color
                    if (colors[neighbor] == 0)
                    {
                        colors[neighbor] = -colors[node];
                        queue.Enqueue(neighbor);
                    }
                    else if (colors[neighbor] == colors[node]) 
                    {
                        return false; // If the neighbor has the same color, the graph isn't bipartite
                    }
                }
            }
        }
        
        return true;
    }
}
