using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution735
{
    /// <summary>
    /// 735. Asteroid Collision - Medium
    /// <a href="https://leetcode.com/problems/asteroid-collision">See the problem</a>
    /// </summary>
    public int[] AsteroidCollision(int[] asteroids)
    {
        var stack = new Stack<int>();

        foreach (var asteroid in asteroids)
        {
            if (asteroid > 0)
            {
                stack.Push(asteroid);
            }
            else
            {
                while (stack.Count > 0 && stack.Peek() > 0 && stack.Peek() < Math.Abs(asteroid))
                {
                    stack.Pop();
                }

                if (stack.Count == 0 || stack.Peek() < 0)
                {
                    stack.Push(asteroid);
                }
                else if (stack.Peek() == Math.Abs(asteroid))
                {
                    stack.Pop();
                }
            }
        }

        return stack.ToArray().Reverse().ToArray();
    }
}
