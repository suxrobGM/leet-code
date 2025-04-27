using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1298
{
    /// <summary>
    /// 1298. Maximum Candies You Can Get from Boxes - Hard
    /// <a href="https://leetcode.com/problems/maximum-candies-you-can-get-from-boxes">See the problem</a>
    /// </summary>
    public int MaxCandies(int[] status, int[] candies, int[][] keys, int[][] containedBoxes, int[] initialBoxes)
    {
        var queue = new Queue<int>();
        var haveKey = new HashSet<int>();
        var lockedBoxes = new HashSet<int>();
        var visited = new bool[status.Length];

        foreach (var box in initialBoxes)
            queue.Enqueue(box);

        int totalCandies = 0;

        while (queue.Count > 0)
        {
            int box = queue.Dequeue();

            if (visited[box])
                continue;

            if (status[box] == 0 && !haveKey.Contains(box))
            {
                lockedBoxes.Add(box);
                continue;
            }

            visited[box] = true;
            totalCandies += candies[box];

            // Add new keys
            foreach (var key in keys[box])
            {
                haveKey.Add(key);
                if (lockedBoxes.Contains(key))
                {
                    queue.Enqueue(key);
                    lockedBoxes.Remove(key);
                }
            }

            // Add contained boxes
            foreach (var contained in containedBoxes[box])
            {
                queue.Enqueue(contained);
            }
        }

        return totalCandies;
    }
}
