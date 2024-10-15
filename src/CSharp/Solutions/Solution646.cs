namespace LeetCode.Solutions;

public class Solution646
{
    /// <summary>
    /// 646. Maximum Length of Pair Chain - Medium
    /// <a href="https://leetcode.com/problems/maximum-length-of-pair-chain">See the problem</a>
    /// </summary>
    public int FindLongestChain(int[][] pairs)
    {
        // Sort pairs by the second element (righti)
        Array.Sort(pairs, (a, b) => a[1].CompareTo(b[1]));
        var count = 0;
        var currentEnd = int.MinValue;

        // Iterate through the pairs and form the longest chain
        foreach (var pair in pairs)
        {
            if (pair[0] > currentEnd)
            {
                // If the current pair can be added to the chain
                count++;
                currentEnd = pair[1]; // Update the end of the current chain
            }
        }

        return count;
    }
}
