using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution103
{
    /// <summary>
    /// 103. Binary Tree Zigzag Level Order Traversal - Medium
    /// <a href="https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal">See the problem</a>
    /// </summary>
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        var result = new List<IList<int>>();
        
        if (root is null)
        {
            return result;
        }
        
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        var isLeftToRight = true;
        
        while (queue.Count > 0)
        {
            var level = new List<int>();
            var size = queue.Count;
            
            for (var i = 0; i < size; i++)
            {
                var node = queue.Dequeue();
                
                if (isLeftToRight)
                {
                    level.Add(node.val);
                }
                else
                {
                    level.Insert(0, node.val);
                }
                
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
            isLeftToRight = !isLeftToRight;
        }
        
        return result;
    }
}
