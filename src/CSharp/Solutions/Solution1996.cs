namespace LeetCode.Solutions;

public class Solution1996
{
    /// <summary>
    /// 1996. The Number of Weak Characters in the Game - Medium
    /// <a href="https://leetcode.com/problems/the-number-of-weak-characters-in-the-game">See the problem</a>
    /// </summary>
    public int NumberOfWeakCharacters(int[][] properties)
    {
        // Sort by attack ascending, and by defense descending for equal attacks
        Array.Sort(properties, (a, b) =>
        {
            if (a[0] != b[0])
                return a[0].CompareTo(b[0]);
            return b[1].CompareTo(a[1]);
        });

        int maxDefense = int.MinValue;
        int weakCount = 0;

        // Traverse from the end to the beginning
        for (int i = properties.Length - 1; i >= 0; i--)
        {
            int defense = properties[i][1];
            if (defense < maxDefense)
            {
                weakCount++;
            }
            else
            {
                maxDefense = defense;
            }
        }

        return weakCount;
    }
}
