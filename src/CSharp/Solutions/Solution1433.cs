namespace LeetCode.Solutions;

public class Solution1433
{
    /// <summary>
    /// 1433. Check If a String Can Break Another String - Medium
    /// <a href="https://leetcode.com/problems/check-if-a-string-can-break-another-string">See the problem</a>
    /// </summary>
    public bool CheckIfCanBreak(string s1, string s2)
    {
        var s1Chars = s1.ToCharArray();
        var s2Chars = s2.ToCharArray();
        
        Array.Sort(s1Chars);
        Array.Sort(s2Chars);
        
        var s1CanBreak = true;
        var s2CanBreak = true;
        
        for (var i = 0; i < s1Chars.Length; i++)
        {
            if (s1Chars[i] < s2Chars[i])
            {
                s1CanBreak = false;
            }
            else if (s1Chars[i] > s2Chars[i])
            {
                s2CanBreak = false;
            }
        }
        
        return s1CanBreak || s2CanBreak;
    }
    
    public bool CheckIfCanBreak2(string s1, string s2)
    {
        var s1Permutations = GeneratePermutations(s1);
        var s2Permutations = GeneratePermutations(s2);
        
        return s1Permutations.Any(s1Perm => s2Permutations.Any(s2Perm => CanBreak(s1Perm, s2Perm))) ||
               s2Permutations.Any(s2Perm => s1Permutations.Any(s1Perm => CanBreak(s2Perm, s1Perm)));
    }
    
    private static bool CanBreak(string s1, string s2)
    {
        for (var i = 0; i < s1.Length; i++)
        {
            if (s1[i] < s2[i])
            {
                return false;
            }
        }
        
        return true;
    }

    private static List<string> GeneratePermutations(string str)
    {
        var result = new List<string>();
        GeneratePermutations(str.ToCharArray(), 0, result);
        return result;
    }
    
    private static void GeneratePermutations(char[] str, int start, ICollection<string> result)
    {
        if (start == str.Length) // base case
        {
            result.Add(new string(str));
            return;
        }
        
        // Swap characters at start and i in the array to generate all permutations of the string
        for (var i = start; i < str.Length; i++)
        {
            (str[start], str[i]) = (str[i], str[start]); // swap
            GeneratePermutations(str, start + 1, result);
            (str[start], str[i]) = (str[i], str[start]);
        }
    }
}
