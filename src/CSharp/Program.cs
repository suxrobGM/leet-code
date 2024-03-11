using LeetCode.Algorithms;
using LeetCode.Solutions;

var solution = new Solution452();
var output = solution.FindMinArrowShots([[-2147483646,-2147483645],[2147483646,2147483647]]);
Console.WriteLine(output);
// using LeetCode.Algorithms;
// using LeetCode.DataStructures;
//
// var binaryTree = new BinaryTree<char>('a')
// {
//     Root =
//     {
//         Left = new BinaryTree<char>.Node('b')
//         {
//             Left = new BinaryTree<char>.Node('d'),
//             Right = new BinaryTree<char>.Node('e')
//         },
//         Right = new BinaryTree<char>.Node('c')
//         {
//             Left = new BinaryTree<char>.Node('f')
//             {
//                 Left = new BinaryTree<char>.Node('h')
//                 {
//                     Left = new BinaryTree<char>.Node('l'),
//                     Right = new BinaryTree<char>.Node('m')
//                     {
//                         Left = new BinaryTree<char>.Node('q')
//                     }
//                 },
//                 Right = new BinaryTree<char>.Node('i')
//             },
//             Right = new BinaryTree<char>.Node('g')
//             {
//                 Left = new BinaryTree<char>.Node('j')
//                 {
//                     Left = new BinaryTree<char>.Node('n'),
//                     Right = new BinaryTree<char>.Node('o')
//                 },
//                 Right = new BinaryTree<char>.Node('k')
//                 {
//                     Right = new BinaryTree<char>.Node('p')
//                 }
//             }
//         }
//     }
// };
//
// var bst = new BinaryTree<char>('E')
// {
//     Root =
//     {
//         Left = new BinaryTree<char>.Node('C')
//         {
//             Left = new BinaryTree<char>.Node('A')
//             {
//                 Right = new BinaryTree<char>.Node('B'),
//             },
//             Right = new BinaryTree<char>.Node('D')
//         },
//         Right = new BinaryTree<char>.Node('H')
//         {
//             Left = new BinaryTree<char>.Node('F')
//             {
//                 Right = new BinaryTree<char>.Node('G')
//             },
//             Right = new BinaryTree<char>.Node('J')
//             {
//                 Left = new BinaryTree<char>.Node('I')
//             }
//         }
//     }
// };
//
// Console.WriteLine("Preorder Traversal: ");
// binaryTree.PreOrderTraversal(binaryTree.Root, c => Console.Write($"{c} "));

Console.ReadLine();
