using System.Text;

namespace LeetCode.Solutions;

public class Solution1776
{
    /// <summary>
    /// 1776. Car Fleet II - Hard
    /// <a href="https://leetcode.com/problems/car-fleet-ii">See the problem</a>
    /// </summary>
    public double[] GetCollisionTimes(int[][] cars)
    {
        int n = cars.Length;
        var ans = new double[n];
        Array.Fill(ans, -1.0);

        var stack = new Stack<int>(); // indices of candidate cars ahead

        for (int i = n - 1; i >= 0; i--)
        {
            int pos = cars[i][0];
            int speed = cars[i][1];

            while (stack.Count > 0)
            {
                int j = stack.Peek();
                int pos2 = cars[j][0];
                int speed2 = cars[j][1];

                if (speed <= speed2)
                {
                    // Can't catch up
                    stack.Pop();
                    continue;
                }

                double t = (pos2 - pos) * 1.0 / (speed - speed2);

                // If car j collides later, ensure i collides before that
                if (ans[j] < 0 || t <= ans[j])
                {
                    ans[i] = t;
                    break;
                }
                else
                {
                    stack.Pop(); // j is useless for i
                }
            }

            stack.Push(i);
        }

        return ans;
    }
}
