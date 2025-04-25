using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1291
{
    /// <summary>
    /// 1291. Sequential Digits - Medium
    /// <a href="https://leetcode.com/problems/sequential-digits">See the problem</a>
    /// </summary>
    public IList<int> SequentialDigits(int low, int high)
    {
        var result = new List<int>();
        var sb = new StringBuilder();
        for (int i = 1; i <= 9; i++)
        {
            sb.Clear();
            for (int j = i; j <= 9; j++)
            {
                sb.Append(j);
                int num = int.Parse(sb.ToString());
                if (num >= low && num <= high)
                {
                    result.Add(num);
                }
            }
        }
        result.Sort();
        return result;
    }
}
