using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution779
{
    /// <summary>
    /// 779. K-th Symbol in Grammar - Medium
    /// <a href="https://leetcode.com/problems/swim-in-rising-water">See the problem</a>
    /// </summary>
    public int KthGrammar(int n, int k)
    {
        // Base case: The first row always starts with '0'
        if (n == 1) {
            return 0;
        }

        // Calculate the midpoint of the row
        int half = 1 << (n - 2); // 2^(n-2)

        // Determine if k is in the first or second half
        if (k <= half) {
            return KthGrammar(n - 1, k); // First half, same as previous row
        } else {
            return 1 - KthGrammar(n - 1, k - half); // Second half, complement
        }
    }
}
