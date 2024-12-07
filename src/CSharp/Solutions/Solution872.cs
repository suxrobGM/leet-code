using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution872
{
    /// <summary>
    /// 872. Leaf-Similar Trees - Easy
    /// <a href="https://leetcode.com/problems/leaf-similar-trees">See the problem</a>
    /// </summary>
    public bool LeafSimilar(TreeNode root1, TreeNode root2)
    {
        var leaves1 = new List<int>();
        var leaves2 = new List<int>();

        Traverse(root1, leaves1);
        Traverse(root2, leaves2);

        return leaves1.SequenceEqual(leaves2);
    }

    private void Traverse(TreeNode node, List<int> leaves)
    {
        if (node == null)
        {
            return;
        }

        if (node.left == null && node.right == null)
        {
            leaves.Add(node.val);
        }

        Traverse(node.left, leaves);
        Traverse(node.right, leaves);
    }
}
