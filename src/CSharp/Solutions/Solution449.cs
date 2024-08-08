using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution449
{
    /// <summary>
    /// 449. Serialize and Deserialize BST - Medium
    /// <a href="https://leetcode.com/problems/serialize-and-deserialize-bst">See the problem</a>
    /// </summary>
    public class Codec
    {
        // Serialize a BST to a single string
        public string serialize(TreeNode root)
        {
            if (root == null) 
            {
                return "";
            }

            var result = new List<string>();
            SerializeHelper(root, result);
            return string.Join(",", result);
        }

        private void SerializeHelper(TreeNode node, List<string> result)
        {
            if (node == null) 
            {
                return;
            }

            result.Add(node.val.ToString());
            SerializeHelper(node.left, result);
            SerializeHelper(node.right, result);
        }

        // Deserialize your encoded data to a BST
        public TreeNode deserialize(string data)
        {
            if (string.IsNullOrEmpty(data)) 
            {
                return null;
            }

            var values = data.Split(',').Select(int.Parse).ToArray();
            var index = 0;
            return DeserializeHelper(values, ref index, int.MinValue, int.MaxValue);
        }

        private TreeNode DeserializeHelper(int[] values, ref int index, int lower, int upper)
        {
            if (index == values.Length) 
            {
                return null;
            }

            var val = values[index];

            if (val < lower || val > upper) 
            {
                return null;
            }

            index++;
            var node = new TreeNode(val)
            {
                left = DeserializeHelper(values, ref index, lower, val),
                right = DeserializeHelper(values, ref index, val, upper)
            };

            return node;
        }
    }
}
