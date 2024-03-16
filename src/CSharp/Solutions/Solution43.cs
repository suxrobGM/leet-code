using System.Text;

namespace LeetCode.Solutions;

public class Solution43
{
    /// <summary>
    /// 43. Multiply Strings - Medium
    /// <a href="https://leetcode.com/problems/multiply-strings">See the problem</a>
    /// </summary>
    public string Multiply(string num1, string num2)
    {
        if (num1 == "0" || num2 == "0")
        {
            return "0";
        }
        
        var result = new int[num1.Length + num2.Length];
        
        // Multiply each digit and sum at the corresponding positions
        for (var i = num1.Length - 1; i >= 0; i--)
        {
            for (var j = num2.Length - 1; j >= 0; j--)
            {
                var product = (num1[i] - '0') * (num2[j] - '0');
                var sum = product + result[i + j + 1]; // Add the current product to the previous sum
                result[i + j] += sum / 10; // Add the carry to the previous result
                result[i + j + 1] = sum % 10; // Set the current result
            }
        }
        
        var sb = new StringBuilder();
        
        for (var i = 0; i < result.Length; i++)
        {
            if (i == 0 && result[i] == 0)
            {
                continue;
            }
            
            sb.Append(result[i]);
        }
        
        return sb.ToString();
    }
}
