using System.Text;

namespace LeetCode.Solutions;

public class Solution468
{
    /// <summary>
    /// 468. Validate IP Address - Medium
    /// <a href="https://leetcode.com/problems/validate-ip-address">See the problem</a>
    /// </summary>
    public string ValidIPAddress(string queryIP)
    {
        if (IsValidIPv4(queryIP))
        {
            return "IPv4";
        }

        if (IsValidIPv6(queryIP))
        {
            return "IPv6";
        }

        return "Neither";
    }

    private bool IsValidIPv4(string ip)
    {
        var parts = ip.Split('.');
        if (parts.Length != 4)
        {
            return false;
        }

        foreach (var part in parts)
        {
            if (part.Length == 0 || part.Length > 3)
            {
                return false;
            }

            if (part[0] == '0' && part.Length > 1)
            {
                return false;
            }

            if (!int.TryParse(part, out var num) || num < 0 || num > 255)
            {
                return false;
            }
        }

        return true;
    }

    private bool IsValidIPv6(string ip)
    {
        var parts = ip.Split(':');
        if (parts.Length != 8)
        {
            return false;
        }

        foreach (var part in parts)
        {
            if (part.Length == 0 || part.Length > 4)
            {
                return false;
            }

            foreach (var ch in part)
            {
                if (!char.IsDigit(ch) && (ch < 'a' || ch > 'f') && (ch < 'A' || ch > 'F'))
                {
                    return false;
                }
            }
        }

        return true;
    }
}
