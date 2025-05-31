using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1496
{
    /// <summary>
    /// 1496. Path Crossing - Easy
    /// <a href="https://leetcode.com/problems/path-crossing">See the problem</a>
    /// </summary>
    public bool IsPathCrossing(string path)
    {
        if (string.IsNullOrEmpty(path))
            return false;

        var visited = new HashSet<(int, int)>();
        int x = 0, y = 0;
        visited.Add((x, y));

        foreach (char direction in path)
        {
            switch (direction)
            {
                case 'N':
                    y++;
                    break;
                case 'S':
                    y--;
                    break;
                case 'E':
                    x++;
                    break;
                case 'W':
                    x--;
                    break;
            }

            if (!visited.Add((x, y)))
            {
                return true; // Path crosses itself
            }
        }

        return false; // No crossing detected
    }
}
