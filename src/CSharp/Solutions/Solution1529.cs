using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1529
{
    /// <summary>
    /// 1529. Minimum Suffix Flips - Medium
    /// <a href="https://leetcode.com/problems/minimum-suffix-flips">See the problem</a>
    /// </summary>
    public int MinFlips(string target)
    {
        int flips = 0;
        char currentChar = '0'; // Start with '0' since we can flip to '1' or '0'

        foreach (char c in target)
        {
            if (c != currentChar)
            {
                flips++;
                currentChar = c; // Update the current character to the new one
            }
        }

        return flips;
    }
}
