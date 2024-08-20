namespace LeetCode.Solutions;

public class Solution481
{
    /// <summary>
    /// 481. Magical String - Medium
    /// <a href="https://leetcode.com/problems/magical-string">See the problem</a>
    /// </summary>
    public int MagicalString(int n)
    {
        if (n == 0) return 0;
        if (n <= 3) return 1;

        var s = new List<int> { 1, 2, 2 }; // Start with "122"
        var countOnes = 1; // We already have one '1' in the initial "122"
        var idx = 2; // Pointer to where we are reading to generate the sequence
        var num = 1; // Next number to add, which alternates between 1 and 2

        while (s.Count < n)
        {
            var repeat = s[idx];
            for (var i = 0; i < repeat; i++)
            {
                s.Add(num);
                if (s.Count == n && num == 1) countOnes++;
                else if (s.Count < n && num == 1) countOnes++;
            }
            num = num == 1 ? 2 : 1; // Alternate between 1 and 2
            idx++;
        }

        return countOnes;
    }
}
