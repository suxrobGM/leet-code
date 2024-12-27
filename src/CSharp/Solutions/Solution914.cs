using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution914
{
    /// <summary>
    /// 914. X of a Kind in a Deck of Cards - Easy
    /// <a href="https://leetcode.com/problems/x-of-a-kind-in-a-deck-of-cards">See the problem</a>
    /// </summary>
    public bool HasGroupsSizeX(int[] deck)
    {
        var count = new Dictionary<int, int>();
        foreach (var card in deck)
        {
            count[card] = count.GetValueOrDefault(card, 0) + 1;
        }

        var x = count.Values.First();
        foreach (var value in count.Values)
        {
            x = Gcd(x, value);
            if (x == 1)
            {
                return false;
            }
        }

        return x >= 2;
    }

    private int Gcd(int a, int b)
    {
        return b == 0 ? a : Gcd(b, a % b);
    }
}
