using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution99
{
    /// <summary>
    /// 99. Recover Binary Search Tree - Medium
    /// <a href="https://leetcode.com/problems/recover-binary-search-tree">See the problem</a>
    /// </summary>
    public void RecoverTree(TreeNode root)
    {
        var nodes = new List<TreeNode>();
        var values = new List<int>();
        
        InOrderTraversal(root, nodes, values);
        
        values.Sort();
        
        for (var i = 0; i < nodes.Count; i++)
        {
            nodes[i].val = values[i];
        }
    }
    
    private void InOrderTraversal(TreeNode node, List<TreeNode> nodes, List<int> values)
    {
        if (node is null)
        {
            return;
        }
        
        InOrderTraversal(node.left, nodes, values);
        
        nodes.Add(node);
        values.Add(node.val);
        
        InOrderTraversal(node.right, nodes, values);
    }
}
