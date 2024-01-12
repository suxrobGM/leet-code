using LeetCode.DataStructures;
using LeetCode.Solutions;

var solution = new Solution19();

var head = new ListNode(1);
head.next = new ListNode(2);
head.next.next = new ListNode(3);
head.next.next.next = new ListNode(4);
head.next.next.next.next = new ListNode(5);
var output = solution.RemoveNthFromEnd(head, 2);
Console.WriteLine(output);
Console.ReadLine();
