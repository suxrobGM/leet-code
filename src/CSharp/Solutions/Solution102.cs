using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution102
{
    /// <summary>
    /// 102. Binary Tree Level Order Traversal - Medium
    /// <a href="https://leetcode.com/problems/binary-tree-level-order-traversal">See the problem</a>
    /// </summary>
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        var result = new List<IList<int>>();
        
        if (root is null)
        {
            return result;
        }
        
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while (queue.Count > 0)
        {
            var level = new List<int>();
            var size = queue.Count;
            
            for (var i = 0; i < size; i++)
            {
                var node = queue.Dequeue();
                level.Add(node.val);
                
                if (node.left is not null)
                {
                    queue.Enqueue(node.left);
                }
                
                if (node.right is not null)
                {
                    queue.Enqueue(node.right);
                }
            }
            
            result.Add(level);
        }
        
        return result;
    }
}
