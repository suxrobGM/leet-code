using LeetCode.DataStructures;
using LeetCode.Solutions;

var solution = new Solution24();
var linkedList1 = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4))));

var output = solution.SwapPairs1(linkedList1);
Console.WriteLine(output.ToString());
Console.ReadLine();
