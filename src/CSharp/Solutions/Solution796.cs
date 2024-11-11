
namespace LeetCode.Solutions;

public class Solution796
{
    /// <summary>
    /// 796. Rotate String - Easy
    /// <a href="https://leetcode.com/problems/rotate-string">See the problem</a>
    /// </summary>
    public bool RotateString(string s, string goal)
    {
        if (s.Length != goal.Length)
        {
            return false;
        }

        return (s + s).Contains(goal);
    }
}
