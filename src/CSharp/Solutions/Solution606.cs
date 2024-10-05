using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution606
{
    /// <summary>
    /// 606. Construct String from Binary Tree - Easy
    /// <a href="https://leetcode.com/problems/construct-string-from-binary-tree">See the problem</a>
    /// </summary>
    public string Tree2str(TreeNode root)
    {
        if (root == null)
        {
            return string.Empty;
        }
        
        if (root.left == null && root.right == null)
        {
            return root.val.ToString();
        }
        
        if (root.right == null)
        {
            return $"{root.val}({Tree2str(root.left)})";
        }
        
        return $"{root.val}({Tree2str(root.left)})({Tree2str(root.right)})";
    }
}
