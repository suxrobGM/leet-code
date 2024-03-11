namespace LeetCode.Solutions;

public class Solution1071
{
    /// <summary>
    /// 1071. Greatest Common Divisor of Strings - Easy
    /// <a href="https://leetcode.com/problems/greatest-common-divisor-of-strings">See the problem</a>
    /// </summary>
    public string GcdOfStrings(string str1, string str2)
    {
        if (str1.Length < str2.Length)
        {
            return GcdOfStrings(str2, str1);
        }
        
        if (str2.Length == 0)
        {
            return str1;
        }
        
        if (str1.StartsWith(str2))
        {
            return GcdOfStrings(str1[str2.Length..], str2);
        }
        
        return "";
    }
}
