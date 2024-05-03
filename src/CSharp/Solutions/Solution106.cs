using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution106
{
    /// <summary>
    /// 106. Construct Binary Tree from Inorder and Postorder Traversal - Medium
    /// <a href="https://leetcode.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal">See the problem</a>
    /// </summary>
    public TreeNode BuildTree(int[] inorder, int[] postorder)
    {
        return BuildTree(postorder, 0, postorder.Length - 1, inorder, 0, inorder.Length - 1);
    }
    
    private TreeNode BuildTree(int[] postorder, int postStart, int postEnd, int[] inorder, int inStart, int inEnd)
    {
        if (postStart > postEnd || inStart > inEnd)
        {
            return null;
        }
        
        var root = new TreeNode(postorder[postEnd]);
        
        var inRootIndex = 0;
        
        for (var i = inStart; i <= inEnd; i++)
        {
            if (inorder[i] == root.val)
            {
                inRootIndex = i;
                break;
            }
        }
        
        var rightTreeSize = inEnd - inRootIndex;
        
        root.left = BuildTree(postorder, postStart, postEnd - rightTreeSize - 1, inorder, inStart, inRootIndex - 1);
        root.right = BuildTree(postorder, postEnd - rightTreeSize, postEnd - 1, inorder, inRootIndex + 1, inEnd);
        
        return root;
    }
}
