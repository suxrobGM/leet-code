using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution874
{
    /// <summary>
    /// 874. Walking Robot Simulation - Medium
    /// <a href="https://leetcode.com/problems/walking-robot-simulation">See the problem</a>
    /// </summary>
    public int RobotSim(int[] commands, int[][] obstacles)
    {
        // Directions: North, East, South, West
        int[][] directions = [
            [0, 1],  // North
            [1, 0],  // East
            [0, -1], // South
            [-1, 0]  // West
        ];

        // Convert obstacles to a set for quick lookup
        var obstacleSet = new HashSet<(int, int)>();
        foreach (var obstacle in obstacles) {
            obstacleSet.Add((obstacle[0], obstacle[1]));
        }

        // Initialize the robot's position and direction
        int x = 0, y = 0, dir = 0;
        int maxDistance = 0;

        foreach (var command in commands) {
            if (command == -2) {
                // Turn left
                dir = (dir + 3) % 4;
            } else if (command == -1) {
                // Turn right
                dir = (dir + 1) % 4;
            } else {
                // Move forward
                int dx = directions[dir][0];
                int dy = directions[dir][1];
                for (int step = 0; step < command; step++) {
                    int nx = x + dx;
                    int ny = y + dy;
                    if (obstacleSet.Contains((nx, ny))) {
                        break; // Stop moving if there's an obstacle
                    }
                    x = nx;
                    y = ny;
                    maxDistance = Math.Max(maxDistance, x * x + y * y);
                }
            }
        }

        return maxDistance;
    }
}
