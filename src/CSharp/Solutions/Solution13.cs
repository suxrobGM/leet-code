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
        var romansMap = new Dictionary<char, int>()
        {
            {'I', 1 },
            {'V', 5 },
            {'X', 10 },
            {'L', 50 },
            {'C', 100 },
            {'D', 500 },
            {'M', 1000 },
        };

        var result = 0;

        for (var i = 0; i < s.Length; i++)
        {
            var currentChar = s[i];
            
            if (i == s.Length - 1)
            {
                result += romansMap[currentChar];
                break;
            }

            var nextChar = s[i + 1];

            if (romansMap[currentChar] >= romansMap[nextChar])
            {
                result += romansMap[currentChar];
            }
            else
            {
                result -= romansMap[currentChar];
            }
        }

        return result;
    }
}
