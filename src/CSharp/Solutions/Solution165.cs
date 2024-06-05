namespace LeetCode.Solutions;

public class Solution165
{
    /// <summary>
    /// 165. Compare Version Numbers - Medium
    /// <a href="https://leetcode.com/problems/compare-version-numbers">See the problem</a>
    /// </summary>
    public int CompareVersion(string version1, string version2)
    {
        var v1 = version1.Split('.');
        var v2 = version2.Split('.');
        var n = Math.Max(v1.Length, v2.Length);

        for (var i = 0; i < n; i++)
        {
            var num1 = i < v1.Length ? int.Parse(v1[i]) : 0;
            var num2 = i < v2.Length ? int.Parse(v2[i]) : 0;

            if (num1 < num2)
            {
                return -1;
            }

            if (num1 > num2)
            {
                return 1;
            }
        }

        return 0;
    }
}
