using LeetCode.DataStructures;
using LeetCode.Solutions;

var solution = new Solution21();
var linkedList1 = new ListNode(1, new ListNode(4, new ListNode(5)));
var linkedList2 = new ListNode(1, new ListNode(3, new ListNode(4)));
var linkedList3 = new ListNode(2, new ListNode(6));

var lists = new[]
{
    linkedList1,
    linkedList2,
    linkedList3
};

var output = solution.MergeTwoLists(linkedList1, linkedList2);
Console.WriteLine(output.ToString());
Console.ReadLine();
