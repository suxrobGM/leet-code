using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution105
{
    /// <summary>
    /// 105. Construct Binary Tree from Preorder and Inorder Traversal - Medium
    /// <a href="https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal">See the problem</a>
    /// </summary>
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        return BuildTree(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
    }
    
    private TreeNode BuildTree(int[] preorder, int preStart, int preEnd, int[] inorder, int inStart, int inEnd)
    {
        if (preStart > preEnd || inStart > inEnd)
        {
            return null;
        }
        
        var root = new TreeNode(preorder[preStart]);
        
        var inRootIndex = 0;
        
        for (var i = inStart; i <= inEnd; i++)
        {
            if (inorder[i] == root.val)
            {
                inRootIndex = i;
                break;
            }
        }
        
        var leftTreeSize = inRootIndex - inStart;
        
        root.left = BuildTree(preorder, preStart + 1, preStart + leftTreeSize, inorder, inStart, inRootIndex - 1);
        root.right = BuildTree(preorder, preStart + leftTreeSize + 1, preEnd, inorder, inRootIndex + 1, inEnd);
        
        return root;
    }
}
