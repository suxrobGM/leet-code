using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution133
{
    /// <summary>
    /// 133. Clone Graph
    /// <a href="https://leetcode.com/problems/clone-graph">See the problem</a>
    /// </summary>
    public Node CloneGraph(Node node)
    {
        if (node is null)
        {
            return null;
        }
        
        // Dictionary to keep track of cloned nodes
        var clones = new Dictionary<Node, Node>
        {
            // Initialize the dictionary with the first node
            [node] = new(node.val)
        };

        // Stack for DFS traversal
        var stack = new Stack<Node>();
        stack.Push(node);

        while (stack.Count > 0) 
        {
            var curr = stack.Pop();

            // Iterate through all neighbors of the current node
            foreach (var neighbor in curr.neighbors) 
            {
                // If the neighbor hasn't been cloned yet
                if (!clones.ContainsKey(neighbor)) 
                {
                    clones[neighbor] = new Node(neighbor.val); // Clone the neighbor and add it to the dictionary
                    stack.Push(neighbor); // Push the neighbor onto the stack for further traversal
                }
                
                // Add the cloned neighbor to the current node's clone's neighbors list
                clones[curr].neighbors.Add(clones[neighbor]);
            }
        }

        return clones[node];
    }
    
    public Node CloneGraph2(Node node)
    {
        if (node is null)
        {
            return null;
        }

        // Dictionary to keep track of cloned nodes
        var clones = new Dictionary<Node, Node>
        {
            [node] = new(node.val) // Initialize the dictionary with the first node's clone
        };

        // Queue for BFS traversal
        var queue = new Queue<Node>();
        queue.Enqueue(node);

        while (queue.Count > 0)
        {
            var curr = queue.Dequeue();

            // Iterate through all neighbors of the current node
            foreach (var neighbor in curr.neighbors)
            {
                // If the neighbor hasn't been cloned yet
                if (!clones.ContainsKey(neighbor))
                {
                    clones[neighbor] = new Node(neighbor.val); // Clone the neighbor and add it to the dictionary
                    queue.Enqueue(neighbor); // Enqueue the neighbor onto the queue for further traversal
                }

                // Add the cloned neighbor to the current node's clone's neighbors list
                clones[curr].neighbors.Add(clones[neighbor]);
            }
        }

        return clones[node];
    }
}
