namespace LeetCode.Solutions;

public class Solution160
{
    public class ListNode 
    {
         public int val;
         public ListNode next;
         public ListNode(int x) { val = x; }
    }
    
    /// <summary>
    /// 160. Intersection of Two Linked Lists - Easy
    /// <a href="https://leetcode.com/problems/intersection-of-two-linked-lists">See the problem</a>
    /// </summary>
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        var a = headA;
        var b = headB;

        while (a != b)
        {
            a = a == null ? headB : a.next;
            b = b == null ? headA : b.next;
        }

        return a;
    }
}
