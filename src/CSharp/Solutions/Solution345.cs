using System.Text;

namespace LeetCode.Solutions;

public class Solution345
{
    /// <summary>
    /// 345. Reverse Vowels of a String - Easy
    /// <a href="https://leetcode.com/problems/reverse-vowels-of-a-string">See the problem</a>
    /// </summary>
    public string ReverseVowels(string s)
    {
        var vowels = new HashSet<char>(['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U']);
        var left = 0;
        var right = s.Length - 1;
        var strBuilder = new StringBuilder(s);
        
        while (left < right)
        {
            while (left < right && !vowels.Contains(s[left]))
            {
                left++;
            }
            
            while (left < right && !vowels.Contains(s[right]))
            {
                right--;
            }
            
            if (left < right)
            {
                (strBuilder[left], strBuilder[right]) = (strBuilder[right], strBuilder[left]);
                left++;
                right--;
            }
        }
        
        return strBuilder.ToString();
    }
}
