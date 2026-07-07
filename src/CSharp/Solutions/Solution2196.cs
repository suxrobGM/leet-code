using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution2196
{
    /// <summary>
    /// 2196. Create Binary Tree From Descriptions - Medium
    /// <a href="https://leetcode.com/problems/create-binary-tree-from-descriptions">See the problem</a>
    /// </summary>
    public TreeNode CreateBinaryTree(int[][] descriptions)
    {
        var nodes = new Dictionary<int, TreeNode>();
        var hasParent = new HashSet<int>();

        foreach (var description in descriptions)
        {
            var parentVal = description[0];
            var childVal = description[1];
            var isLeft = description[2] == 1;

            if (!nodes.TryGetValue(parentVal, out var parent))
            {
                parent = new TreeNode(parentVal);
                nodes[parentVal] = parent;
            }

            if (!nodes.TryGetValue(childVal, out var child))
            {
                child = new TreeNode(childVal);
                nodes[childVal] = child;
            }

            if (isLeft)
            {
                parent.left = child;
            }
            else
            {
                parent.right = child;
            }

            hasParent.Add(childVal);
        }

        // The root is the only node that never appears as a child.
        foreach (var (val, node) in nodes)
        {
            if (!hasParent.Contains(val))
            {
                return node;
            }
        }

        return null;
    }
}
