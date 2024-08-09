namespace LeetCode.Solutions;

public class Solution455
{
    /// <summary>
    /// 455. Assign Cookies - Easy
    /// <a href="https://leetcode.com/problems/assign-cookies">See the problem</a>
    /// </summary>
    public int FindContentChildren(int[] g, int[] s) 
    {
        Array.Sort(g);
        Array.Sort(s);
        
        var i = 0;
        var j = 0;
        
        while (i < g.Length && j < s.Length)
        {
            if (g[i] <= s[j])
            {
                i++;
            }
            
            j++;
        }
        
        return i;
    }
}
