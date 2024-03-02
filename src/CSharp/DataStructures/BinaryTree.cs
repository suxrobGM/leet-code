namespace LeetCode.DataStructures;

/// <summary>
/// Binary Tree
/// </summary>
/// <typeparam name="T">The datatype of items</typeparam>
public class BinaryTree<T>
{
    private int _postOrderIndex;
    private Dictionary<T, int> _inOrderIndexMap;
    
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
    /// Performs a pre-order traversal of the binary tree.
    /// In a pre-order traversal, the root is visited first, then the left subtree and later the right subtree.
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
    
    // Function to build the tree from in-order and post-order traversals
    /// <summary>
    /// Builds a binary tree from in-order and post-order traversals.
    /// </summary>
    /// <param name="inOrder"></param>
    /// <param name="postOrder"></param>
    /// <returns></returns>
    // public Node BuildTree(T[] inOrder, T[] postOrder)
    // {
    //     _postOrderIndex = postOrder.Length - 1; // Initialize postOrderIndex to the last element
    //     // Fill the dictionary with the in-order indices for quick lookup
    //     for (var i = 0; i < inOrder.Length; i++)
    //     {
    //         _inOrderIndexMap[inOrder[i]] = i;
    //     }
    //
    //     return BuildTreeUtil(inOrder, postOrder, 0, inOrder.Length - 1);
    // }
    //
    // private Node BuildTreeUtil(char[] inOrder, char[] postOrder, int inStart, int inEnd)
    // {
    //     // Base case
    //     if (inStart > inEnd) return null;
    //
    //     // The current root is the last element of the current postOrder segment
    //     var root = new Node(postOrder[_postOrderIndex--]);
    //
    //     // If the tree has only one node, no need to find the left and right subtrees
    //     if (inStart == inEnd) return root;
    //
    //     // Find the index of this node in inOrder traversal to divide the inOrder array
    //     // into left and right subtrees
    //     int inIndex = _inOrderIndexMap[root.Data];
    //
    //     // Using index in inOrder traversal, construct right and then left subtree
    //     // Note: We build the right subtree first because we are decreasing postOrderIndex
    //     // and the right subtree is accessed first in postOrder
    //     root.Right = BuildTreeUtil(inOrder, postOrder, inIndex + 1, inEnd);
    //     root.Left = BuildTreeUtil(inOrder, postOrder, inStart, inIndex - 1);
    //
    //     return root;
    // }
    
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
