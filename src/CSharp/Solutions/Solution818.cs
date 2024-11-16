using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution818
{
    /// <summary>
    /// 818. Race Car - Hard
    /// <a href="https://leetcode.com/problems/race-car">See the problem</a>
    /// </summary>
    public int Racecar(int target)
    {
        // BFS queue: stores (position, speed, steps)
        var queue = new Queue<(int, int, int)>();
        var visited = new HashSet<(int, int)>();

        // Start at position 0, speed 1, with 0 steps
        queue.Enqueue((0, 1, 0));
        visited.Add((0, 1));

        while (queue.Count > 0)
        {
            var (position, speed, steps) = queue.Dequeue();

            // If we reach the target, return the number of steps
            if (position == target)
            {
                return steps;
            }

            // Generate the next state for 'A' (accelerate)
            int newPosition = position + speed;
            int newSpeed = speed * 2;
            if (Math.Abs(newPosition) <= 2 * target && Math.Abs(newSpeed) <= 2 * target)
            {
                if (!visited.Contains((newPosition, newSpeed)))
                {
                    queue.Enqueue((newPosition, newSpeed, steps + 1));
                    visited.Add((newPosition, newSpeed));
                }
            }

            // Generate the next state for 'R' (reverse)
            newSpeed = speed > 0 ? -1 : 1;
            if (!visited.Contains((position, newSpeed)))
            {
                queue.Enqueue((position, newSpeed, steps + 1));
                visited.Add((position, newSpeed));
            }
        }

        return -1; // Should never reach here
    }
}
