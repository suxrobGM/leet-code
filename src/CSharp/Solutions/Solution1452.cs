using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1452
{
    /// <summary>
    /// 1452. People Whose List of Favorite Companies Is Not a Subset of Another List - Medium
    /// <a href="https://leetcode.com/problems/people-whose-list-of-favorite-companies-is-not-a-subset-of-another-list">See the problem</a>
    /// </summary>
    public IList<int> PeopleIndexes(IList<IList<string>> favoriteCompanies)
    {
        var result = new List<int>();
        var n = favoriteCompanies.Count;
        var companySets = new HashSet<string>[n];

        // Convert each person's favorite companies to a HashSet
        for (int i = 0; i < n; i++)
        {
            companySets[i] = new HashSet<string>(favoriteCompanies[i]);
        }

        // Check each person against all others
        for (int i = 0; i < n; i++)
        {
            bool isSubset = false;
            for (int j = 0; j < n; j++)
            {
                if (i != j && companySets[i].IsSubsetOf(companySets[j]))
                {
                    isSubset = true;
                    break;
                }
            }
            if (!isSubset)
            {
                result.Add(i);
            }
        }

        return result;
    }
}
