using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1665
{
    /// <summary>
    /// 1665. Minimum Initial Energy to Finish Tasks - Hard
    /// <a href="https://leetcode.com/problems/minimum-initial-energy-to-finish-tasks">See the problem</a>
    /// </summary>
    public int MinimumEffort(int[][] tasks)
    {
        // Sort tasks by (minimum - actual) descending
        Array.Sort(tasks, (a, b) =>
        {
            int diffA = a[1] - a[0];
            int diffB = b[1] - b[0];
            return diffB.CompareTo(diffA);
        });

        int energy = 0, curr = 0;

        foreach (var task in tasks)
        {
            int actual = task[0], minimum = task[1];

            // If current energy is less than required minimum, increase it
            if (curr < minimum)
            {
                energy += minimum - curr;
                curr = minimum;
            }

            curr -= actual;
        }

        return energy;
    }
}
