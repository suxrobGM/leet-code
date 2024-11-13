using System.Text;

namespace LeetCode.Solutions;

public class Solution811
{
    /// <summary>
    /// 811. Subdomain Visit Count - Medium
    /// <a href="https://leetcode.com/problems/subdomain-visit-count">See the problem</a>
    /// </summary>
    public IList<string> SubdomainVisits(string[] cpdomains)
    {
        var result = new List<string>();
        var dict = new Dictionary<string, int>();

        foreach (var cpdomain in cpdomains)
        {
            var parts = cpdomain.Split(' ');
            var count = int.Parse(parts[0]);
            var domain = parts[1];

            for (var i = 0; i < domain.Length; i++)
            {
                if (domain[i] == '.')
                {
                    var subdomain = domain.Substring(i + 1);
                    dict[subdomain] = dict.GetValueOrDefault(subdomain) + count;
                }
            }

            dict[domain] = dict.GetValueOrDefault(domain) + count;
        }

        foreach (var (key, value) in dict)
        {
            result.Add($"{value} {key}");
        }

        return result;
    }
}
