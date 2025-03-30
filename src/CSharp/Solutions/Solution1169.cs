using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1169
{
    /// <summary>
    /// 1169. Invalid Transactions - Medium
    /// <a href="https://leetcode.com/problems/invalid-transactions">See the problem</a>
    /// </summary>
    public IList<string> InvalidTransactions(string[] transactions)
    {
        int n = transactions.Length;
        var parsed = new List<(string name, int time, int amount, string city)>();
        var invalid = new bool[n];

        // Step 1: Parse all transactions
        for (int i = 0; i < n; i++)
        {
            var parts = transactions[i].Split(',');
            string name = parts[0];
            int time = int.Parse(parts[1]);
            int amount = int.Parse(parts[2]);
            string city = parts[3];

            parsed.Add((name, time, amount, city));

            // Rule 1: amount > 1000
            if (amount > 1000)
            {
                invalid[i] = true;
            }
        }

        // Step 2: Check for Rule 2: same name, diff city, ≤ 60 mins
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == j) continue;

                var t1 = parsed[i];
                var t2 = parsed[j];

                if (t1.name == t2.name &&
                    t1.city != t2.city &&
                    Math.Abs(t1.time - t2.time) <= 60)
                {
                    invalid[i] = true;
                    invalid[j] = true;
                }
            }
        }

        // Step 3: Collect invalid transactions (preserve duplicates)
        var result = new List<string>();
        for (int i = 0; i < n; i++)
        {
            if (invalid[i])
                result.Add(transactions[i]);
        }

        return result;
    }
}
