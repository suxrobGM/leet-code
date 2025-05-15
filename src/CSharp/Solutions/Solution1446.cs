namespace LeetCode.Solutions;

public class Solution1446
{
    /// <summary>
    /// 1446. Consecutive Characters - Easy
    /// <a href="https://leetcode.com/problems/consecutive-characters">See the problem</a>
    /// </summary>
    public int MaxPower(string s)
    {
        var maxPower = 1;
        var currentPower = 1;

        for (var i = 1; i < s.Length; i++)
        {
            if (s[i] == s[i - 1])
            {
                currentPower++;
            }
            else
            {
                maxPower = Math.Max(maxPower, currentPower);
                currentPower = 1;
            }
        }

        return Math.Max(maxPower, currentPower);
    }
}
