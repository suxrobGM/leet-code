using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution107
{
    /// <summary>
    /// 107. Binary Tree Level Order Traversal II - Medium
    /// <a href="https://leetcode.com/problems/binary-tree-level-order-traversal-ii">See the problem</a>
    /// </summary>
    public IList<IList<int>> LevelOrderBottom(TreeNode root)
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
                var current = queue.Dequeue();
                
                level.Add(current.val);
                
                if (current.left is not null)
                {
                    queue.Enqueue(current.left);
                }
                
                if (current.right is not null)
                {
                    queue.Enqueue(current.right);
                }
            }
            
            result.Insert(0, level);
        }
        
        return result;
    }
}
