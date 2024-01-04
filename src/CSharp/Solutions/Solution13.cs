namespace LeetCode.Solutions;

public class Solution13
{
    /// <summary>
    /// Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
    /// For example, 2 is written as II in Roman numeral, just two one's added together. 12 is written as XII, which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.
    /// Roman numerals are usually written largest to smallest from left to right.However, the numeral for four is not IIII. Instead, the number four is written as IV.Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX.There are six instances where subtraction is used:
    /// Given a roman numeral, convert it to an integer.
    /// <see href="https://leetcode.com/problems/roman-to-integer/">See the problem</see>
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
