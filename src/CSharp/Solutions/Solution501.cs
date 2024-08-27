using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution501
{
    /// <summary>
    /// 501. Find Mode in Binary Search Tree - Easy
    /// <a href="https://leetcode.com/problems/find-mode-in-binary-search-tree">See the problem</a>
    /// </summary>
    public int[] FindMode(TreeNode root)
    {
        Dictionary<int, int> map = new();
        int max = 0;

        void Traverse(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            if (map.ContainsKey(node.val))
            {
                map[node.val]++;
            }
            else
            {
                map[node.val] = 1;
            }

            max = Math.Max(max, map[node.val]);

            Traverse(node.left);
            Traverse(node.right);
        }

        Traverse(root);

        List<int> result = new();

        foreach (var pair in map)
        {
            if (pair.Value == max)
            {
                result.Add(pair.Key);
            }
        }

        return result.ToArray();
    }
}
