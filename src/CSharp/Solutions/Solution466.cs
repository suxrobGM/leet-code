using System.Text;

namespace LeetCode.Solutions;

public class Solution466
{
    /// <summary>
    /// 466. Count The Repetitions - Hard
    /// <a href="https://leetcode.com/problems/count-the-repetitions">See the problem</a>
    /// </summary>
    public int GetMaxRepetitions(string s1, int n1, string s2, int n2)
    {
        var s1Length = s1.Length;
        var s2Length = s2.Length;

        if (s1Length == 0 || s2Length == 0 || n1 == 0 || n2 == 0)
        {
            return 0;
        }

        var s1Count = 0;
        var s2Count = 0;
        var i = 0;
        var j = 0;

        while (s1Count < n1)
        {
            if (s1[i] == s2[j])
            {
                j++;
                if (j == s2Length)
                {
                    j = 0;
                    s2Count++;
                }
            }

            i++;
            if (i == s1Length)
            {
                i = 0;
                s1Count++;
            }
        }

        return s2Count / n2;
    }
}
