using System.Text;

namespace LeetCode.Solutions;

public class Solution721
{
    /// <summary>
    /// 721. Accounts Merge - Medium
    /// <a href="https://leetcode.com/problems/accounts-merge">See the problem</a>
    /// </summary>
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
    {
        var emailToName = new Dictionary<string, string>();
        var uf = new UnionFind();

        // Step 1: Populate Union-Find and emailToName
        foreach (var account in accounts)
        {
            var name = account[0];
            for (var i = 1; i < account.Count; i++)
            {
                emailToName[account[i]] = name;
                uf.Union(account[1], account[i]);  // Union first email with all other emails in the account
            }
        }

        // Step 2: Group emails by their root representative
        var components = new Dictionary<string, List<string>>();
        foreach (var email in emailToName.Keys)
        {
            var rootEmail = uf.Find(email);
            if (!components.ContainsKey(rootEmail))
            {
                components[rootEmail] = new List<string>();
            }
            components[rootEmail].Add(email);
        }

        // Step 3: Format the result
        var mergedAccounts = new List<IList<string>>();
        foreach (var component in components)
        {
            var rootEmail = component.Key;
            var emails = component.Value;
            emails.Sort();  // Sort emails lexicographically
            emails.Insert(0, emailToName[rootEmail]);  // Insert name at the beginning
            mergedAccounts.Add(emails);
        }

        return mergedAccounts;
    }

    // Union-Find (Disjoint Set Union) with path compression
    public class UnionFind
    {
        private Dictionary<string, string> parent = [];

        public string Find(string x)
        {
            if (!parent.ContainsKey(x))
            {
                parent[x] = x;
            }
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]);  // Path compression
            }
            return parent[x];
        }

        public void Union(string x, string y)
        {
            var rootX = Find(x);
            var rootY = Find(y);
            if (rootX != rootY)
            {
                parent[rootX] = rootY;  // Union by setting root of one to the other
            }
        }
    }
}
