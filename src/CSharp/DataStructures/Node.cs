namespace LeetCode.DataStructures;

/// <summary>
/// Definition for a Node for Graph.
/// This class is from LeetCode.
/// </summary>
public class Node {
    public int val;
    public IList<Node> neighbors = new List<Node>();
    
    public Node(int val, IList<Node> neighbors) {
        this.val = val;
        this.neighbors = neighbors;
    }

    public Node(int val) {
        this.val = val;
    }
}
