using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution968
{
    private int cameras = 0;

    /// <summary>
    /// 968. Binary Tree Cameras - Hard
    /// <a href="https://leetcode.com/problems/binary-tree-cameras">See the problem</a>
    /// </summary>
    public int MinCameraCover(TreeNode root)
    {
        // If root is uncovered, place a camera at root
        if (DFS(root) == 0)
        {
            cameras++;
        }
        return cameras;
    }

    private int DFS(TreeNode node)
    {
        if (node == null) return 1; // Null nodes are already covered

        int left = DFS(node.left);
        int right = DFS(node.right);

        // If any child is not covered, place a camera here
        if (left == 0 || right == 0)
        {
            cameras++;
            return 2; // This node has a camera
        }

        // If either child has a camera, this node is covered
        if (left == 2 || right == 2)
        {
            return 1; // Covered but no camera
        }

        // If children are covered but have no camera, this node is not covered
        return 0;
    }
}
