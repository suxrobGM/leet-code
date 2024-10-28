namespace LeetCode.Solutions;

public class Solution707
{
    /// <summary>
    /// 707. Design Linked List - Medium
    /// <a href="https://leetcode.com/problems/design-linked-list">See the problem</a>
    /// </summary>
    public class MyLinkedList
    {
        private class Node
        {
            public int val;
            public Node next;

            public Node(int val = 0, Node next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        private Node head = null;
        private int size = 0;

        public int Get(int index)
        {
            if (index < 0 || index >= size)
            {
                return -1;
            }

            var current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }

            return current.val;
        }

        public void AddAtHead(int val)
        {
            var newNode = new Node(val, head);
            head = newNode;
            size++;
        }

        public void AddAtTail(int val)
        {
            var newNode = new Node(val);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                var current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = newNode;
            }
            size++;
        }

        public void AddAtIndex(int index, int val)
        {
            if (index < 0 || index > size)
            {
                return;
            }

            if (index == 0)
            {
                AddAtHead(val);
            }
            else
            {
                var current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.next;
                }
                var newNode = new Node(val, current.next);
                current.next = newNode;
                size++;
            }
        }

        public void DeleteAtIndex(int index)
        {
            if (index < 0 || index >= size)
            {
                return;
            }

            if (index == 0)
            {
                head = head.next;
            }
            else
            {
                var current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.next;
                }
                current.next = current.next.next;
            }
            size--;
        }
    }
}
