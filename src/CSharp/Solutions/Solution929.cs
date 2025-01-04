using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution929
{
    /// <summary>
    /// 929. Unique Email Addresses - Easy
    /// <a href="https://leetcode.com/problems/unique-email-addresses">See the problem</a>
    /// </summary>
    public int NumUniqueEmails(string[] emails)
    {
        var uniqueEmails = new HashSet<string>();

        foreach (string email in emails)
        {
            string[] parts = email.Split('@');
            string localName = parts[0];
            string domainName = parts[1];

            var sb = new StringBuilder();
            foreach (char c in localName)
            {
                if (c == '+')
                {
                    break;
                }

                if (c != '.')
                {
                    sb.Append(c);
                }
            }

            uniqueEmails.Add(sb.ToString() + "@" + domainName);
        }

        return uniqueEmails.Count;
    }
}
