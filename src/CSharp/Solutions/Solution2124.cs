namespace LeetCode.Solutions;

public class Solution2124
{
    /// <summary>
    /// 2124. Check if All A's Appears Before All B's - Easy
    /// <a href="https://leetcode.com/problems/check-if-all-as-appears-before-all-bs">See the problem</a>
    /// </summary>
    public bool CheckString(string s)
    {
        var seenB = false;
        foreach (var c in s)
        {
            if (c == 'b')
            {
                seenB = true;
            }
            else if (seenB)
            {
                return false;
            }
        }

        return true;
    }
}
