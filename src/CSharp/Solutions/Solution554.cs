using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution554
{
    /// <summary>
    /// 554. Brick Wall - Medium
    /// <a href="https://leetcode.com/problems/brick-wall">See the problem</a>
    /// </summary>
    public int LeastBricks(IList<IList<int>> wall)
    {
        var map = new Dictionary<int, int>();

        foreach (var row in wall)
        {
            int sum = 0;
            for (int i = 0; i < row.Count - 1; i++)
            {
                sum += row[i];
                map[sum] = map.GetValueOrDefault(sum) + 1;
            }
        }

        return wall.Count - (map.Count == 0 ? 0 : map.Values.Max());
    }
}
