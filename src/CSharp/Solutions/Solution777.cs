using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution777
{
    /// <summary>
    /// 777. Swap Adjacent in LR String - Medium
    /// <a href="https://leetcode.com/problems/swap-adjacent-in-lr-string">See the problem</a>
    /// </summary>
    public bool CanTransform(string start, string end)
    {
        int n = start.Length;

        // First, check that the non-'X' characters are in the same order and count
        if (start.Replace("X", "") != end.Replace("X", ""))
        {
            return false;
        }

        // Now check the relative positions of 'L' and 'R'
        int i = 0, j = 0;

        while (i < n && j < n)
        {
            // Move i and j to the next non-'X' characters in start and end, respectively
            while (i < n && start[i] == 'X') i++;
            while (j < n && end[j] == 'X') j++;

            // If both i and j reach the end, we are done
            if (i == n && j == n) return true;
            // If one of them reaches the end first, they don't match
            if (i == n || j == n) return false;

            // Check if characters match
            if (start[i] != end[j]) return false;

            // Check direction constraints
            if (start[i] == 'L' && i < j) return false;  // 'L' can't move right
            if (start[i] == 'R' && i > j) return false;  // 'R' can't move left

            // Move to the next character
            i++;
            j++;
        }

        return true;
    }
}
