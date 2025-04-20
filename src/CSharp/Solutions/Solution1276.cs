using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1276
{
    /// <summary>
    /// 1276. Number of Burgers with No Waste of Ingredients - Medium
    /// <a href="https://leetcode.com/problems/number-of-burgers-with-no-waste-of-ingredients">See the problem</a>
    /// </summary>
    public IList<int> NumOfBurgers(int tomatoSlices, int cheeseSlices)
    {
        // 0 => jumbo, 1 => small
        var jumbo = (tomatoSlices - 2 * cheeseSlices) / 2;
        var small = cheeseSlices - jumbo;

        if (jumbo < 0 || small < 0 || (tomatoSlices - 2 * cheeseSlices) % 2 != 0)
        {
            return [];
        }

        return [jumbo, small];
    }
}
