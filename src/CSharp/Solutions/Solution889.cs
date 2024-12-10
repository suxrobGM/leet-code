using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution889
{
    /// <summary>
    /// 889. Construct Binary Tree from Preorder and Postorder Traversal - Medium
    /// <a href="https://leetcode.com/problems/construct-binary-tree-from-preorder-and-postorder-traversal">See the problem</a>
    /// </summary>
    public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
    {
        var preIndex = 0;
        var postIndex = 0;

        TreeNode Construct()
        {
            var root = new TreeNode(preorder[preIndex++]);

            if (root.val != postorder[postIndex])
            {
                root.left = Construct();
            }

            if (root.val != postorder[postIndex])
            {
                root.right = Construct();
            }

            postIndex++;

            return root;
        }

        return Construct();
    }
}
