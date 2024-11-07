using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution771
{
    /// <summary>
    /// 771. Jewels and Stones - Easy
    /// <a href="https://leetcode.com/problems/jewels-and-stones">See the problem</a>
    /// </summary>
    public int NumJewelsInStones(string jewels, string stones)
    {
        var jewelSet = new HashSet<char>(jewels);
        var result = 0;

        foreach (var stone in stones)
        {
            if (jewelSet.Contains(stone))
            {
                result++;
            }
        }

        return result;
    }
}
