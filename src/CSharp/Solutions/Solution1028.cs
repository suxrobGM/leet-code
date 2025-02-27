using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1028
{
    /// <summary>
    /// 1028. Recover a Tree From Preorder Traversal - Hard
    /// <a href="https://leetcode.com/problems/recover-a-tree-from-preorder-traversal</a>
    /// </summary>
    public TreeNode RecoverFromPreorder(string traversal)
    {
        var stack = new Stack<TreeNode>();
        int i = 0;

        while (i < traversal.Length)
        {
            int level = 0;
            while (traversal[i] == '-')
            {
                level++;
                i++;
            }

            int value = 0;
            while (i < traversal.Length && traversal[i] != '-')
            {
                value = value * 10 + (traversal[i] - '0');
                i++;
            }

            var node = new TreeNode(value);

            while (stack.Count > level)
            {
                stack.Pop();
            }

            if (stack.Count > 0)
            {
                if (stack.Peek().left == null)
                {
                    stack.Peek().left = node;
                }
                else
                {
                    stack.Peek().right = node;
                }
            }

            stack.Push(node);
        }

        while (stack.Count > 1)
        {
            stack.Pop();
        }

        return stack.Pop();
    }
}
