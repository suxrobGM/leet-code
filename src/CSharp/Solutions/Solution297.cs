using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution297
{
    /// <summary>
    /// 297. Serialize and Deserialize Binary Tree - Hard
    /// <a href="https://leetcode.com/problems/serialize-and-deserialize-binary-tree">See the problem</a>
    /// </summary>
    public class Codec 
    {
        public string Serialize(TreeNode root) 
        {
            var sb = new StringBuilder();
            Serialize(root, sb);
            return sb.ToString();
        }

        private void Serialize(TreeNode root, StringBuilder sb)
        {
            if (root == null)
            {
                sb.Append("null,");
                return;
            }
            sb.Append(root.val).Append(',');
            Serialize(root.left, sb);
            Serialize(root.right, sb);
        }

        public TreeNode Deserialize(string data) 
        {
            var queue = new Queue<string>(data.Split(','));
            return Deserialize(queue);
        }

        private TreeNode Deserialize(Queue<string> queue)
        {
            var val = queue.Dequeue();
            if (val == "null")
            {
                return null;
            }
            var node = new TreeNode(int.Parse(val))
            {
                left = Deserialize(queue),
                right = Deserialize(queue)
            };
            return node;
        }
    }
}
