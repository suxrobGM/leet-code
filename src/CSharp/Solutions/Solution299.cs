using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution299
{
    /// <summary>
    /// 299. Bulls and Cows - Medium
    /// <a href="https://leetcode.com/problems/bulls-and-cows">See the problem</a>
    /// </summary>
    public string GetHint(string secret, string guess)
    {
        var bulls = 0;
        var cows = 0;
        var secretCount = new int[10];
        var guessCount = new int[10];

        for (var i = 0; i < secret.Length; i++)
        {
            if (secret[i] == guess[i])
            {
                bulls++;
            }
            else
            {
                secretCount[secret[i] - '0']++;
                guessCount[guess[i] - '0']++;
            }
        }

        for (var i = 0; i < 10; i++)
        {
            cows += Math.Min(secretCount[i], guessCount[i]);
        }
        
        return $"{bulls}A{cows}B";
    }
}
