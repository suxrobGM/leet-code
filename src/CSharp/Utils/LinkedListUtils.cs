#nullable enable
namespace LeetCode.Algorithms;

public static class LinkedListUtils
{
    public static void AddToList<T>(DataStructures.LinkedList<T> list, T item)
    {
        var newNode = new DataStructures.LinkedList<T>.Node(item);
        
        if (list.Head is null)
        {
            list.Head = newNode;
        }
        else
        {
            // Add the new node to the front of the list
            newNode.Next = list.Head;
            list.Head.Next = newNode; 
        }
    }
    
    public static int LinearSearch<T>(DataStructures.LinkedList<T> list, T value)
    {
        var currentNode = list.Head;
        var index = 0;
        
        while (currentNode is not null)
        {
            if (currentNode.Value != null && currentNode.Value.Equals(value))
            {
                return index;
            }
            
            currentNode = currentNode.Next;
            index++;
        }
        return -1;
    }
    
    public static void RemoveFromList<T>(DataStructures.LinkedList<T> list, T item)
    {
        if (list.Head is null)
        {
            // The list is empty
            return;
        }
        
        if (list.Head.Value is not null && list.Head.Value.Equals(item))
        {
            // The item to remove is the first node in the list
            list.Head = list.Head.Next;
            
            if (list.Head is null)
            {
                list.Tail = null; // The list is now empty
            }
            
            return;
        }
        
        // Traverse the list to find the node to remove
        var currentNode = list.Head;
        while (currentNode.Next is not null)
        {
            if (currentNode.Next.Value is not null && currentNode.Next.Value.Equals(item))
            {
                // Found the node to remove
                currentNode.Next = currentNode.Next.Next;
            
                // If removed node was the last, update the Tail
                if (currentNode.Next is null)
                {
                    list.Tail = currentNode;
                }
            }
            else
            {
                // Move to the next node if not removing
                currentNode = currentNode.Next;
            }
        }
    }
}
