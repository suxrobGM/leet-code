using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1268
{
    /// <summary>
    /// 1268. Search Suggestions System - Medium
    /// <a href="https://leetcode.com/problems/search-suggestions-system">See the problem</a>
    /// </summary>
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
    {
        Array.Sort(products);
        var result = new List<IList<string>>();
        int n = products.Length, m = searchWord.Length;
        for (int i = 0; i < m; ++i)
        {
            string prefix = searchWord.Substring(0, i + 1);
            var suggestions = new List<string>();
            for (int j = 0; j < n && suggestions.Count < 3; ++j)
            {
                if (products[j].StartsWith(prefix))
                {
                    suggestions.Add(products[j]);
                }
            }
            result.Add(suggestions);
        }
        return result;
    }
}
