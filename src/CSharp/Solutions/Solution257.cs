using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution257
{
    /// <summary>
    /// 257. Binary Tree Paths - Easy
    /// <a href="https://leetcode.com/problems/binary-tree-paths">See the problem</a>
    /// </summary>
    public IList<string> BinaryTreePaths(TreeNode root)
    {
        var result = new List<string>();
        var path = new List<string>();

        void Dfs(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            path.Add(node.val.ToString());

            if (node.left == null && node.right == null)
            {
                result.Add(string.Join("->", path));
            }
            else
            {
                Dfs(node.left);
                Dfs(node.right);
            }

            path.RemoveAt(path.Count - 1);
        }

        Dfs(root);

        return result;
    }
}
