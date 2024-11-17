using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution823
{
    /// <summary>
    /// 823. Binary Trees With Factors - Medium
    /// <a href="https://leetcode.com/problems/binary-trees-with-factors">See the problem</a>
    /// </summary>
    public int NumFactoredBinaryTrees(int[] arr)
    {
        var mod = 1_000_000_007;

        // Sort the array
        Array.Sort(arr);

        // Dictionary to store the number of trees for each value
        var dp = new Dictionary<int, long>();

        // Fill the dictionary
        for (var i = 0; i < arr.Length; i++)
        {
            dp[arr[i]] = 1; // Each value can at least form a single node tree

            for (var j = 0; j < i; j++)
            {
                if (arr[i] % arr[j] == 0)
                { // Check if arr[j] is a factor
                    var other = arr[i] / arr[j];
                    if (dp.ContainsKey(other))
                    {
                        dp[arr[i]] = (dp[arr[i]] + dp[arr[j]] * dp[other]) % mod;
                    }
                }
            }
        }

        // Sum up all the trees
        long result = 0;
        foreach (var value in dp.Values)
        {
            result = (result + value) % mod;
        }

        return (int)result;
    }
}
