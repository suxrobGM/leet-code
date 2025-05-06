using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1305
{
    /// <summary>
    /// 1305. All Elements in Two Binary Search Trees - Medium
    /// <a href="https://leetcode.com/problems/all-elements-in-two-binary-search-trees">See the problem</a>
    /// </summary>
    public IList<int> GetAllElements(TreeNode root1, TreeNode root2)
    {
        var list1 = new List<int>();
        var list2 = new List<int>();

        InOrderTraversal(root1, list1);
        InOrderTraversal(root2, list2);

        return MergeSortedLists(list1, list2);
    }

    private void InOrderTraversal(TreeNode node, List<int> list)
    {
        if (node == null) return;

        InOrderTraversal(node.left, list);
        list.Add(node.val);
        InOrderTraversal(node.right, list);
    }

    private IList<int> MergeSortedLists(List<int> list1, List<int> list2)
    {
        var mergedList = new List<int>();
        int i = 0, j = 0;

        while (i < list1.Count && j < list2.Count)
        {
            if (list1[i] < list2[j])
            {
                mergedList.Add(list1[i]);
                i++;
            }
            else
            {
                mergedList.Add(list2[j]);
                j++;
            }
        }

        while (i < list1.Count)
        {
            mergedList.Add(list1[i]);
            i++;
        }

        while (j < list2.Count)
        {
            mergedList.Add(list2[j]);
            j++;
        }

        return mergedList;
    }
}
