using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1325
{
    /// <summary>
    /// 1325. Delete Leaves With a Given Value - Medium
    /// <a href="https://leetcode.com/problems/delete-leaves-with-a-given-value">See the problem</a>
    /// </summary>
    public TreeNode RemoveLeafNodes(TreeNode root, int target)
    {
        if (root == null) return null;

        root.left = RemoveLeafNodes(root.left, target);
        root.right = RemoveLeafNodes(root.right, target);

        if (root.left == null && root.right == null && root.val == target)
            return null;

        return root;
    }
}
