using System.Text;

namespace LeetCode.Solutions;

public class Solution38
{
    /// <summary>
    /// 38. Count and Say - Medium
    /// <a href="https://leetcode.com/problems/count-and-say">See the problem</a>
    /// </summary>
    public string CountAndSay(int n)
    {
        var result = "1";
        
        for (var i = 1; i < n; i++)
        {
            var sb = new StringBuilder();
            var count = 1;
            
            for (var j = 1; j < result.Length; j++)
            {
                if (result[j] == result[j - 1])
                {
                    count++;
                }
                else
                {
                    sb.Append(count).Append(result[j - 1]);
                    count = 1;
                }
            }
            
            sb.Append(count).Append(result[^1]);
            result = sb.ToString();
        }
        
        return result;
    }
}
