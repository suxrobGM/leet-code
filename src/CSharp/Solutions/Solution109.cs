using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution109
{
    /// <summary>
    /// 109. Convert Sorted List to Binary Search Tree - Medium
    /// <a href="https://leetcode.com/problems/convert-sorted-list-to-binary-search-tree">See the problem</a>
    /// </summary>
    public TreeNode SortedListToBST(ListNode head)
    {
        if (head is null)
        {
            return null;
        }
        
        var list = new List<int>();
        
        while (head is not null)
        {
            list.Add(head.val);
            head = head.next;
        }
        
        return BuildTree(list, 0, list.Count - 1);
    }
    
    private TreeNode BuildTree(List<int> list, int start, int end)
    {
        if (start > end)
        {
            return null;
        }
        
        var mid = start + (end - start) / 2;
        
        var root = new TreeNode(list[mid])
        {
            left = BuildTree(list, start, mid - 1),
            right = BuildTree(list, mid + 1, end)
        };

        return root;
    }
}
