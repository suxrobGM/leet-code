using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution638
{
    /// <summary>
    /// 638. Shopping Offers - Medium
    /// <a href="https://leetcode.com/problems/shopping-offers">See the problem</a>
    /// </summary>
    public int ShoppingOffers(IList<int> price, IList<IList<int>> special, IList<int> needs)
    {
        // Dictionary for memoization
        var memo = new Dictionary<string, int>();

        // Helper function to calculate the minimum cost
        int DFS(IList<int> currNeeds)
        {
            // Convert current needs to a string key for memoization
            var key = string.Join(",", currNeeds);

            // If we have already computed the result for this set of needs, return it
            if (memo.ContainsKey(key))
            {
                return memo[key];
            }

            // Base case: Calculate the cost without any special offers
            int minCost = 0;
            for (int i = 0; i < currNeeds.Count; i++)
            {
                minCost += currNeeds[i] * price[i];
            }

            // Try each special offer and see if it can be applied
            foreach (var offer in special)
            {
                // Check if we can apply this offer
                var valid = true;
                var newNeeds = new List<int>(currNeeds.Count);
                for (var i = 0; i < currNeeds.Count; i++)
                {
                    if (currNeeds[i] < offer[i])
                    {
                        valid = false;
                        break;
                    }
                    newNeeds.Add(currNeeds[i] - offer[i]);
                }

                // If the offer is valid, recursively calculate the cost after applying the offer
                if (valid)
                {
                    minCost = Math.Min(minCost, offer[offer.Count - 1] + DFS(newNeeds));
                }
            }

            // Store the result in memoization dictionary and return it
            memo[key] = minCost;
            return minCost;
        }

        // Start the DFS with the initial needs
        return DFS(needs);
    }
}
