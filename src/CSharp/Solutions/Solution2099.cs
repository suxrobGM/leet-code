using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution2099
{
    /// <summary>
    /// 2099. Find Subsequence of Length K With the Largest Sum - Easy
    /// <a href="https://leetcode.com/problems/find-subsequence-of-length-k-with-the-largest-sum">See the problem</a>
    /// </summary>
    public int[] MaxSubsequence(int[] nums, int k)
    {
        var indexedNums = nums.Select((num, index) => (num, index)).ToArray();
        Array.Sort(indexedNums, (a, b) => b.num.CompareTo(a.num)); // Sort by value descending

        var topK = indexedNums.Take(k).OrderBy(x => x.index).ToArray(); // Take top k and sort by original index
        return topK.Select(x => x.num).ToArray();
    }
}
