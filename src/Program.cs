using LeetCode;
using LeetCode.Solutions;

var solution = new Solution();

var l1 = new ListNode(1);
l1.next = new ListNode(2);
l1.next.next = new ListNode(4);

var l2 = new ListNode(1);
l2.next = new ListNode(3);
l2.next.next = new ListNode(4);

var output = solution.MergeTwoLists(l1, l2);
Console.WriteLine(output);
Console.ReadLine();
