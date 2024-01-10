namespace LeetCode.Solutions;

public class Solution17
{
    /// <summary>
    /// Problem #17
    /// <a href="https://leetcode.com/problems/letter-combinations-of-a-phone-number/">See the problem</a>
    /// </summary>
    public IList<string> LetterCombinations(string digits)
    {
        if (string.IsNullOrEmpty(digits))
        {
            return [];
        }
        
        Dictionary<char, string> lettersMap = new()
        {
            { '2', "abc" },
            { '3', "def" },
            { '4', "ghi" },
            { '5', "jkl" },
            { '6', "mno" },
            { '7', "pqrs" },
            { '8', "tuv" },
            { '9', "wxyz" }
        };
        
        var result = new List<string>() { "" };

        foreach (var digit in digits) 
        {
            var letters = lettersMap[digit];
            var newCombinations = new List<string>();

            foreach (var combination in result) 
            {
                foreach (var letter in letters) 
                {
                    newCombinations.Add(combination + letter);
                }
            }

            result = newCombinations;
        }

        return result;
    }
}
