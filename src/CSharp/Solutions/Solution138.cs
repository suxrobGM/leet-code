namespace LeetCode.Solutions;

public class Solution138
{
    public class Node {
        public int val;
        public Node next;
        public Node random;
    
        public Node(int _val) {
            val = _val;
            next = null;
            random = null;
        }
    }
    
    /// <summary>
    /// 138. Copy List with Random Pointer - Medium
    /// <a href="https://leetcode.com/problems/copy-list-with-random-pointer">See the problem</a>
    /// </summary>
    public Node CopyRandomList(Node head)
    {
        if (head == null) 
        {
            return null;
        }

        var map = new Dictionary<Node, Node>();
        var current = head;

        // First pass: create a new node for each original node and map original nodes to new nodes
        while (current != null) 
        {
            map[current] = new Node(current.val);
            current = current.next;
        }

        // Second pass: assign next and random pointers for the new nodes
        current = head;
        while (current != null) 
        {
            var cloned = map[current];
            cloned.next = (current.next != null) ? map[current.next] : null;
            cloned.random = (current.random != null) ? map[current.random] : null;
            current = current.next;
        }

        return map[head];
    }
}
