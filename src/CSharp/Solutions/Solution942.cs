using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution942
{
    /// <summary>
    /// 942. DI String Match - Easy
    /// <a href="https://leetcode.com/problems/di-string-match">See the problem</a>
    /// </summary>
    public int[] DiStringMatch(string s)
    {
        var n = s.Length;
        var result = new int[n + 1];
        var low = 0;
        var high = n;

        for (var i = 0; i < n; i++)
        {
            result[i] = s[i] == 'I' ? low++ : high--;
        }

        result[n] = low;
        return result;
    }
}
