namespace LeetCode.Solutions;

public class Solution13
{
    /// <summary>
    /// Problem #13
    /// <a href="https://leetcode.com/problems/roman-to-integer/">See the problem</a>
    /// </summary>
    /// <remarks>Time complexity O(n)</remarks>
    public int RomanToInt(string s)
    {
        var romansSet = new Dictionary<char, int>()
        {
            {'I', 1 },
            {'V', 5 },
            {'X', 10 },
            {'L', 50 },
            {'C', 100 },
            {'D', 500 },
            {'M', 1000 },
        };

        int res = 0;

        for (int i = 0; i < s.Length; i++)
        {
            var currentChar = s[i];
            
            if (i == s.Length - 1)
            {
                res += romansSet[currentChar];
                break;
            }

            var nextChar = s[i + 1];

            if (romansSet[currentChar] >= romansSet[nextChar])
            {
                res += romansSet[currentChar];
            }
            else
            {
                res -= romansSet[currentChar];
            }
        }

        return res;
    }
}
