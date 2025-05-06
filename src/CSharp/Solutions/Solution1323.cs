using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1323
{
    /// <summary>
    /// 1323. Maximum 69 Number - Easy
    /// <a href="https://leetcode.com/problems/maximum-69-number">See the problem</a>
    /// </summary>
    public int Maximum69Number(int num)
    {
        var sb = new StringBuilder(num.ToString());
        for (int i = 0; i < sb.Length; i++)
        {
            if (sb[i] == '6')
            {
                sb[i] = '9';
                break;
            }
        }

        return int.Parse(sb.ToString());
    }
}
