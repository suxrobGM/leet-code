using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution2096
{
    /// <summary>
    /// 2096. Step-By-Step Directions From a Binary Tree Node to Another - Medium
    /// <a href="https://leetcode.com/problems/step-by-step-directions-from-a-binary-tree-node-to-another">See the problem</a>
    /// </summary>
    public string GetDirections(TreeNode root, int startValue, int destValue)
    {
        var startPath = new List<char>();
        var destPath = new List<char>();

        FindPath(root, startValue, startPath);
        FindPath(root, destValue, destPath);

        int i = 0;
        while (i < startPath.Count && i < destPath.Count && startPath[i] == destPath[i])
            i++;

        var result = new StringBuilder();
        for (int j = i; j < startPath.Count; j++)
            result.Append('U');
        for (int j = i; j < destPath.Count; j++)
            result.Append(destPath[j]);

        return result.ToString();

        static bool FindPath(TreeNode node, int value, List<char> path)
        {
            if (node.val == value)
                return true;

            if (node.left != null)
            {
                path.Add('L');
                if (FindPath(node.left, value, path))
                    return true;
                path.RemoveAt(path.Count - 1);
            }

            if (node.right != null)
            {
                path.Add('R');
                if (FindPath(node.right, value, path))
                    return true;
                path.RemoveAt(path.Count - 1);
            }

            return false;
        }
    }
}
