using LeetCode.Algorithms;
using LeetCode.Solutions;

// Create a new linked list
var list = new LeetCode.DataStructures.LinkedList<int>();

// Add some items to the list
LinkedListUtils.AddToList(list, 1);
LinkedListUtils.AddToList(list, 2);
LinkedListUtils.AddToList(list, 3);

// Print the list to the console
var currentNode = list.Head;
while (currentNode != null)
{
    Console.WriteLine(currentNode.Value);
    currentNode = currentNode.Next;
}
Console.ReadLine();
