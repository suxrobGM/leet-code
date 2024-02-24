#nullable enable
namespace LeetCode.DataStructures;

public class LinkedList<T>
{
    public class Node(T value)
    {
        public T? Value { get; } = value;
        public Node? Next { get; set; }
    }

    public LinkedList()
    {
        Head = Tail = null;
    }
    
    public Node? Head { get; set; }
    public Node? Tail { get; set; }
    
    /// <summary>
    /// Adds a new node with the specified value to the beginning of the LinkedList.
    /// </summary>
    /// <param name="value">The value to add to the LinkedList.</param>
    public void AddFirst(T value)
    {
        var newNode = new Node(value);
        if (Head is not null)
        {
            newNode.Next = Head;
        }
        Head = newNode;
        Tail ??= newNode;
    }

    /// <summary>
    /// Adds a new node with the specified value to the end of the LinkedList.
    /// </summary>
    /// <param name="value">The value to add to the LinkedList.</param>
    public void AddLast(T value)
    {
        var newNode = new Node(value);
        if (Tail is not null)
        {
            Tail.Next = newNode;
        }
        Tail = newNode;
        Head ??= newNode;
    }

    /// <summary>
    /// Removes the first node from the list and returns its value.
    /// </summary>
    /// <returns>The value of the first node if it exists, otherwise default value of T.</returns>
    public T? RemoveFirst()
    {
        if (Head is null)
        {
            return default;
        }
        
        var value = Head.Value;
        Head = Head.Next;
        
        if (Head is null)
        {
            Tail = null;
        }
        return value;
    }
    
    /// <summary>
    /// Removes the first occurrence of the specified item from the LinkedList.
    /// </summary>
    /// <param name="item">The item to remove from the LinkedList.</param>
    public void Remove(T item)
    {
        if (Head is null)
        {
            // The list is empty
            return;
        }
        
        if (Head.Value != null && Head.Value.Equals(item))
        {
            // The item to remove is the first node in the list
            Head = Head.Next;
            
            if (Head is null)
            {
                Tail = null; // The list is now empty
            }
            
            return;
        }
        
        // Traverse the list to find the node to remove
        var currentNode = Head;
        while (currentNode.Next != null)
        {
            if (currentNode.Next.Value != null && currentNode.Next.Value.Equals(item))
            {
                // Found the node to remove
                currentNode.Next = currentNode.Next.Next;
            
                // If removed node was the last, update the Tail
                if (currentNode.Next == null)
                {
                    Tail = currentNode;
                }
            }
            else
            {
                // Move to the next node if not removing
                currentNode = currentNode.Next;
            }
        }
    }

    /// <summary>
    /// Determines whether the LinkedList is empty.
    /// </summary>
    public bool IsEmpty()
    {
        return Head is null;
    }
}
