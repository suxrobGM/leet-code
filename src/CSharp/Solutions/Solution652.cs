using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution652
{
    /// <summary>
    /// 652. Find Duplicate Subtrees - Medium
    /// <a href="https://leetcode.com/problems/find-duplicate-subtrees">See the problem</a>
    /// </summary>
    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
    {
        var stack = new Stack<TreeNode>();
        var visited = new Dictionary<TreeNode, string>();
        var duplicates = new Dictionary<string, List<TreeNode>>();
        stack.Push(root);

        while (stack.Count != 0)
        {
            var top = stack.Peek();
            if (top.left != null && !visited.ContainsKey(top.left))
            {
                stack.Push(top.left);
                continue;
            }

            if (top.right != null && !visited.ContainsKey(top.right))
            {
                stack.Push(top.right);
                continue;
            }

            var newStructure = $"{top.val}";
            if (top.left != null && visited.ContainsKey(top.left))
            {
                newStructure = $"{visited[top.left]} < {newStructure}";
            }

            if (top.right != null && visited.ContainsKey(top.right))
            {
                newStructure = $"{newStructure} > {visited[top.right]}";
            }

            visited.Add(stack.Pop(), newStructure);
            if (duplicates.ContainsKey(newStructure))
            {
                duplicates[newStructure].Add(top);
            }
            else
            {
                duplicates.Add(newStructure, [top]);
            }

        }

        return duplicates.Values.Where(v => v.Count > 1).Select(v => v[0]).ToList();
    }
}
