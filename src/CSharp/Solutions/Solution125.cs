namespace LeetCode.Solutions;

public class Solution125
{
    /// <summary>
    /// 125. Valid Palindrome
    /// <a href="https://leetcode.com/problems/valid-palindrome">See the problem</a>
    /// </summary>
    public bool IsPalindrome(string s)
    {
        var left = 0;
        var right = s.Length - 1;
        var lowerStr = s.ToLower();
        
        while (left < right)
        {
            if (!char.IsLetterOrDigit(lowerStr[left]))
            {
                left++;
                continue;
            }
            
            if (!char.IsLetterOrDigit(lowerStr[right]))
            {
                right--;
                continue;
            }
            
            if (lowerStr[left] != lowerStr[right])
            {
                return false;
            }
            
            left++;
            right--;
        }
        
        return true;
    }
}
