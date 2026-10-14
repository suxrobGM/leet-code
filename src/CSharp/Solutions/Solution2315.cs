using System.Text;

namespace LeetCode.Solutions;

public class Solution2315
{
    /// <summary>
    /// 2315. Count Asterisks - Easy
    /// <a href="https://leetcode.com/problems/count-asterisks">See the problem</a>
    /// </summary>
    public int CountAsterisks(string s)
    {
        var count = 0;
        var inPair = false;

        foreach (var c in s)
        {
            if (c == '|')
            {
                inPair = !inPair;
            }
            else if (c == '*' && !inPair)
            {
                count++;
            }
        }

        return count;
    }
}
