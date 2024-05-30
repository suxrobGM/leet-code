using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution145
{
    /// <summary>
    /// 145. Binary Tree Postorder Traversal - Easy
    /// <a href="https://leetcode.com/problems/binary-tree-postorder-traversal">See the problem</a>
    /// </summary>
    public IList<int> PostorderTraversal(TreeNode root)
    {
        var result = new List<int>();
        PostorderTraversal(root, result);
        return result;
    }
    
    private void PostorderTraversal(TreeNode root, IList<int> result)
    {
        if (root == null)
        {
            return;
        }
        
        PostorderTraversal(root.left, result);
        PostorderTraversal(root.right, result);
        result.Add(root.val);
    }
}
