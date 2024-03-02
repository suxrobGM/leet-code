// using LeetCode.Algorithms;
// using LeetCode.Solutions;
//
// var solution = new Solution68();
// var output = solution.FullJustify(["This", "is", "an", "example", "of", "text", "justification."], 16);

using LeetCode.Algorithms;
using LeetCode.DataStructures;

var binaryTree = new BinaryTree<char>('a')
{
    Root =
    {
        Left = new BinaryTree<char>.Node('b')
        {
            Left = new BinaryTree<char>.Node('d'),
            Right = new BinaryTree<char>.Node('e')
        },
        Right = new BinaryTree<char>.Node('c')
        {
            Left = new BinaryTree<char>.Node('f')
            {
                Left = new BinaryTree<char>.Node('h')
                {
                    Left = new BinaryTree<char>.Node('l'),
                    Right = new BinaryTree<char>.Node('m')
                    {
                        Left = new BinaryTree<char>.Node('q')
                    }
                },
                Right = new BinaryTree<char>.Node('i')
            },
            Right = new BinaryTree<char>.Node('g')
            {
                Left = new BinaryTree<char>.Node('j')
                {
                    Left = new BinaryTree<char>.Node('n'),
                    Right = new BinaryTree<char>.Node('o')
                },
                Right = new BinaryTree<char>.Node('k')
                {
                    Right = new BinaryTree<char>.Node('p')
                }
            }
        }
    }
};

Console.WriteLine("In-Order Traversal:");
binaryTree.InOrderTraversal(binaryTree.Root, data => Console.Write($"{data} "));
Console.WriteLine("\nPre-Order Traversal:");
binaryTree.PreOrderTraversal(binaryTree.Root, data => Console.Write($"{data} "));
Console.WriteLine("\nPost-Order Traversal:");
binaryTree.PostOrderTraversal(binaryTree.Root, data => Console.Write($"{data} "));

PartitioningUtils.HoarePartition([1, 2, 7, 8, 9, 6, 3, 4, 5], 0, 8);
Console.ReadLine();
