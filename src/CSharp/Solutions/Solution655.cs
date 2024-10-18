using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution655
{
    /// <summary>
    /// 655. Print Binary Tree - Medium
    /// <a href="https://leetcode.com/problems/print-binary-tree">See the problem</a>
    /// </summary>
    public IList<IList<string>> PrintTree(TreeNode root)
    {
        var height = GetHeight(root);
        var width = (int)Math.Pow(2, height) - 1;
        var result = new List<IList<string>>();
        
        for (var i = 0; i < height; i++)
        {
            result.Add(Enumerable.Repeat("", width).ToList());
        }

        Fill(root, result, 0, 0, width - 1);
        return result;
    }

    private int GetHeight(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        return 1 + Math.Max(GetHeight(root.left), GetHeight(root.right));
    }

    private void Fill(TreeNode root, IList<IList<string>> result, int row, int left, int right)
    {
        if (root == null)
        {
            return;
        }

        var mid = left + (right - left) / 2;
        result[row][mid] = root.val.ToString();
        Fill(root.left, result, row + 1, left, mid - 1);
        Fill(root.right, result, row + 1, mid + 1, right);
    }
}
