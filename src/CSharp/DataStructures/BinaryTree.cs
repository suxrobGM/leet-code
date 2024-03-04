using System.Text;

namespace LeetCode.DataStructures;

/// <summary>
/// Binary Tree
/// </summary>
/// <typeparam name="T">The datatype of items</typeparam>
public class BinaryTree<T>
{
    public BinaryTree()
    {
        Root = null;
    }
    
    public BinaryTree(T data)
    {
        Root = new Node(data);
    }
    
    public Node Root { get; set; }
    
    /// <summary>
    /// Performs a Breadth-First Search (BFS) on the binary tree.
    /// </summary>
    /// <param name="node">The starting node for the BFS. Typically, this is the root of the tree.</param>
    /// <param name="action">An action to perform on each node during the BFS.</param>
    public void BFS(Node node, Action<T> action)
    {
        if (node is null)
        {
            return;
        }
    
        // Initialize a queue and enqueue the starting node
        var queue = new Queue<Node>();
        queue.Enqueue(node);
    
        // Continue until all nodes have been visited
        while (queue.Count > 0)
        {
            // Dequeue a node and perform the action on its data
            var current = queue.Dequeue();
            action(current.Data);
        
            // If the current node has a left child, enqueue it
            if (current.Left is not null)
            {
                queue.Enqueue(current.Left);
            }
        
            // If the current node has a right child, enqueue it
            if (current.Right is not null)
            {
                queue.Enqueue(current.Right);
            }
        }
    }
    
    /// <summary>
    /// Performs a pre-order traversal of the binary tree.
    /// In a pre-order traversal, the root is visited first, then the left subtree and later the right subtree.
    /// (Root, Left, Right)
    /// </summary>
    /// <param name="node">The starting node for the traversal. Typically, this is the root of the tree.</param>
    /// <param name="action">An action to perform on each node during the traversal. This is typically a method that takes the node's data as a parameter.</param>
    public void PreOrderTraversal(Node node, Action<T> action)
    {
        if (node is null)
        {
            return;
        }
    
        action(node.Data);
        PreOrderTraversal(node.Left, action);
        PreOrderTraversal(node.Right, action);
    }
    
    
    /// <summary>
    /// Performs an in-order traversal of the binary tree.
    /// In an in-order traversal, the left subtree is visited first, then the root and later the right subtree.
    /// (Left, Root, Right)
    /// </summary>
    /// <param name="node">The starting node for the traversal. Typically, this is the root of the tree.</param>
    /// <param name="action">An action to perform on each node during the traversal. This is typically a method that takes the node's data as a parameter.</param>
    public void InOrderTraversal(Node node, Action<T> action)
    {
        if (node is null)
        {
            return;
        }
    
        InOrderTraversal(node.Left, action);
        action(node.Data);
        InOrderTraversal(node.Right, action);
    }

    /// <summary>
    /// Performs a post-order traversal of the binary tree.
    /// In a post-order traversal, both the left and right subtrees are visited before the root.
    /// (Left, Right, Root)
    /// </summary>
    /// <param name="node">The starting node for the traversal. Typically, this is the root of the tree.</param>
    /// <param name="action">An action to perform on each node during the traversal. This is typically a method that takes the node's data as a parameter.</param>
    public void PostOrderTraversal(Node node, Action<T> action)
    {
        if (node is null)
        {
            return;
        }
    
        PostOrderTraversal(node.Left, action);
        PostOrderTraversal(node.Right, action);
        action(node.Data);
    }
    
    /// <summary>
    /// Builds a binary tree from in-order and post-order traversals.
    /// </summary>
    /// <param name="inOrder"></param>
    /// <param name="postOrder"></param>
    /// <returns></returns>
    public static Node BuildTree(T[] inOrder, T[] postOrder)
    {
        var postOrderIndex = postOrder.Length - 1; // Initialize postOrderIndex to the last element
        var inOrderIndexMap = new Dictionary<T, int>();
        
        // Fill the dictionary with the in-order indices for quick lookup
        for (var i = 0; i < inOrder.Length; i++)
        {
            inOrderIndexMap[inOrder[i]] = i;
        }
    
        return BuildTreeRec(inOrder, postOrder, 0, inOrder.Length - 1, postOrderIndex, inOrderIndexMap);
    }
    
    private static Node BuildTreeRec(
        T[] inOrder,
        T[] postOrder,
        int inStart,
        int inEnd,
        int postOrderIndex,
        IDictionary<T, int> inOrderIndexMap)
    {
        if (inStart > inEnd || postOrderIndex < 0)
        {
            return null;
        }
    
        // The current root is the last element of the current postOrder segment
        var root = new Node(postOrder[postOrderIndex--]);
    
        // If the tree has only one node, no need to find the left and right subtrees
        if (inStart == inEnd)
        {
            return root;
        }
    
        // Find the index of this node in inOrder traversal to divide the inOrder array
        // into left and right subtrees
        var inIndex = inOrderIndexMap[root.Data];
    
        // Using index in inOrder traversal, construct right and then left subtree
        // Note: We build the right subtree first because we are decreasing postOrderIndex
        // and the right subtree is accessed first in postOrder
        root.Right = BuildTreeRec(inOrder, postOrder, inIndex + 1, inEnd, postOrderIndex, inOrderIndexMap);
        root.Left = BuildTreeRec(inOrder, postOrder, inStart, inIndex - 1, postOrderIndex, inOrderIndexMap);
    
        return root;
    }

    public override string ToString()
    {
        var strBuilder = new StringBuilder();
        strBuilder.Append("BFS: ");
        BFS(Root, data => strBuilder.Append(data).Append(' '));
        return strBuilder.ToString();
    }

    #region Binary node

    public class Node
    {
        public Node(T data)
        {
            Data = data;
        }
        
        public T Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }

    #endregion
}
