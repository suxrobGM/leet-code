namespace LeetCode.Solutions;

public class Solution2193
{
    /// <summary>
    /// 2193. Minimum Number of Moves to Make Palindrome - Hard
    /// <a href="https://leetcode.com/problems/minimum-number-of-moves-to-make-palindrome">See the problem</a>
    /// </summary>
    public int MinMovesToMakePalindrome(string s)
    {
        var chars = s.ToList();
        var moves = 0;

        while (chars.Count > 1)
        {
            var left = 0;
            var right = chars.Count - 1;
            var match = right;

            while (match > left && chars[match] != chars[left])
            {
                match--;
            }

            if (match == left)
            {
                moves += chars.Count / 2;
                chars.RemoveAt(left);
                continue;
            }

            moves += right - match;
            chars.RemoveAt(match);
            chars.RemoveAt(left);
        }

        return moves;
    }
}
