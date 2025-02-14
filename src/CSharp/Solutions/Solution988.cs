using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution988
{
    /// <summary>
    /// 988. Smallest String Starting From Leaf - Medium
    /// <a href="https://leetcode.com/problems/smallest-string-starting-from-leaf">See the problem</a>
    /// </summary>
    public string SmallestFromLeaf(TreeNode root)
    {
        var sb = new StringBuilder();
        var result = new List<string>();

        void Dfs(TreeNode node, StringBuilder path)
        {
            if (node == null)
            {
                return;
            }

            path.Insert(0, (char)('a' + node.val));

            if (node.left == null && node.right == null)
            {
                result.Add(path.ToString());
            }

            Dfs(node.left, path);
            Dfs(node.right, path);

            path.Remove(0, 1);
        }

        Dfs(root, sb);

        return result.OrderBy(x => x).FirstOrDefault();
    }
}
