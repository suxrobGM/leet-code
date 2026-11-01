namespace LeetCode.Solutions;

public class Solution2337
{
    /// <summary>
    /// 2337. Move Pieces to Obtain a String - Medium
    /// <a href="https://leetcode.com/problems/move-pieces-to-obtain-a-string">See the problem</a>
    /// </summary>
    public bool CanChange(string start, string target)
    {
        int n = start.Length;
        int i = 0;
        int j = 0;

        while (i < n || j < n)
        {
            while (i < n && start[i] == '_') i++;
            while (j < n && target[j] == '_') j++;

            if (i == n || j == n)
            {
                return i == n && j == n;
            }

            // Pieces cannot pass each other, so their order must match.
            if (start[i] != target[j]) return false;

            // L can only move left, and R can only move right.
            if (start[i] == 'L' && i < j) return false;
            if (start[i] == 'R' && i > j) return false;

            i++;
            j++;
        }

        return true;
    }
}
