using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution781
{
    /// <summary>
    /// 781. Rabbits in Forest - Medium
    /// <a href="https://leetcode.com/problems/rabbits-in-forest">See the problem</a>
    /// </summary>
    public int NumRabbits(int[] answers)
    {
        var count = new Dictionary<int, int>();
        var result = 0;

        foreach (var answer in answers)
        {
            if (!count.ContainsKey(answer))
            {
                count[answer] = 0;
            }

            count[answer]++;
        }

        foreach (var (answer, total) in count)
        {
            result += (int)Math.Ceiling((double)total / (answer + 1)) * (answer + 1);
        }

        return result;
    }
}
