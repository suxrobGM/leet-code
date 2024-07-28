namespace LeetCode.Solutions;

public class Solution430
{
    public class Node
    {
        public int val;
        public Node prev;
        public Node next;
        public Node child;

        public Node()
        {
        }

        public Node(int val)
        {
            this.val = val;
        }

        public Node(int val, Node prev, Node next, Node child)
        {
            this.val = val;
            this.prev = prev;
            this.next = next;
            this.child = child;
        }
    }

    /// <summary>
    /// 430. Flatten a Multilevel Doubly Linked List - Medium
    /// <a href="https://leetcode.com/problems/flatten-a-multilevel-doubly-linked-list">See the problem</a>
    /// </summary>
    public Node Flatten(Node head)
    {
        if (head == null)
        {
            return null;
        }

        var dummy = new Node(0, null, head, null);
        FlattenDfs(dummy, head);
        dummy.next.prev = null;
        return dummy.next;
    }

    private Node FlattenDfs(Node prev, Node current)
    {
        if (current == null)
        {
            return prev;
        }

        current.prev = prev;
        prev.next = current;

        var next = current.next;
        var tail = FlattenDfs(current, current.child);
        current.child = null;

        return FlattenDfs(tail, next);
    }
}
