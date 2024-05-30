using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution144
{
    /// <summary>
    /// 144. Binary Tree Preorder Traversal - Easy
    /// <a href="https://leetcode.com/problems/binary-tree-preorder-traversal">See the problem</a>
    /// </summary>
    public IList<int> PreorderTraversal(TreeNode root)
    {
        var result = new List<int>();
        PreorderTraversal(root, result);
        return result;
    }
    
    private void PreorderTraversal(TreeNode root, IList<int> result)
    {
        if (root == null)
        {
            return;
        }
        
        result.Add(root.val);
        PreorderTraversal(root.left, result);
        PreorderTraversal(root.right, result);
    }
}
