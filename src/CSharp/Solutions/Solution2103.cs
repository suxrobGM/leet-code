using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution2103
{
    /// <summary>
    /// 2103. Rings and Rods - Easy
    /// <a href="https://leetcode.com/problems/rings-and-rods">See the problem</a>
    /// </summary>
    public int CountPoints(string rings)
    {
        var rods = new HashSet<char>[10];
        for (var i = 0; i < 10; i++) rods[i] = [];

        for (var i = 0; i < rings.Length; i += 2)
        {
            var color = rings[i];
            var rod = rings[i + 1] - '0';
            rods[rod].Add(color);
        }

        var count = 0;
        foreach (var rod in rods)
            if (rod.Count == 3)
                count++;

        return count;
    }
}
