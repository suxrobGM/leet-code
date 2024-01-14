using System.Text;

namespace LeetCode.DataStructures;

/// <summary>
/// Definition for singly-linked list.
/// </summary>
public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }

    public override string ToString()
    {
        var strBuilder = new StringBuilder();
        var head = this;
        
        while (head != null)
        {
            strBuilder.Append(head.val);

            if (head.next != null)
            {
                strBuilder.Append(" => ");
            }
            
            head = head.next;
        }
        
        return strBuilder.ToString();
    }
}
