using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution23
{
    /// <summary>
    /// 23. Merge k Sorted Lists
    /// <a href="https://leetcode.com/problems/merge-k-sorted-lists">See the problem</a>
    /// </summary>
    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists.Length == 0)
        {
            return null;
        }

        if (lists.Length == 1)
        {
            return lists[0];
        }

        return MergeKListsInternal(lists, 0, lists.Length - 1);
    }
    
    private ListNode MergeKListsInternal(ListNode[] lists, int start, int end) 
    {
        if (start == end)
        {
            return lists[start];
        }
        
        var mid = start + (end - start) / 2;
        
        var list1 = MergeKListsInternal(lists, start, mid);
        var list2 = MergeKListsInternal(lists, mid + 1, end);
        return MergeTwoLists(list1, list2);
    }
    
    private ListNode MergeTwoLists(ListNode list1, ListNode list2) 
    {
        var dummy = new ListNode();
        var head = dummy;

        while (list1 != null && list2 != null) 
        {
            if (list1.val < list2.val) 
            {
                head.next = list1;
                list1 = list1.next;
            }
            else 
            {
                head.next = list2;
                list2 = list2.next;
            }
            head = head.next;
        }

        head.next = list1 ?? list2;
        return dummy.next;
    }
}
