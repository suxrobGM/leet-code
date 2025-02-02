using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution971
{
    /// <summary>
    /// 971. Flip Binary Tree To Match Preorder Traversal - Medium
    /// <a href="https://leetcode.com/problems/flip-binary-tree-to-match-preorder-traversal">See the problem</a>
    /// </summary>
    public IList<int> FlipMatchVoyage(TreeNode root, int[] voyage)
    {
        var result = new List<int>();
        var index = 0;
        return FlipMatchVoyage(root, voyage, ref index, result) ? result : new List<int> { -1 };
    }

    private bool FlipMatchVoyage(TreeNode root, int[] voyage, ref int index, List<int> result)
    {
        if (root == null) return true;

        if (root.val != voyage[index++]) return false;

        if (root.left != null && root.left.val != voyage[index])
        {
            result.Add(root.val);
            return FlipMatchVoyage(root.right, voyage, ref index, result) && FlipMatchVoyage(root.left, voyage, ref index, result);
        }

        return FlipMatchVoyage(root.left, voyage, ref index, result) && FlipMatchVoyage(root.right, voyage, ref index, result);
    }
}
