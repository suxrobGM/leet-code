using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution853
{
    /// <summary>
    /// 853. Car Fleet - Medium
    /// <a href="https://leetcode.com/problems/car-fleet">See the problem</a>
    /// </summary>
    public int CarFleet(int target, int[] position, int[] speed)
    {
        var n = position.Length;
        var cars = new Car[n];
        for (int i = 0; i < n; i++)
        {
            cars[i] = new Car(position[i], (double)(target - position[i]) / speed[i]);
        }

        Array.Sort(cars, (a, b) => a.position - b.position);

        var fleets = 0;
        var time = 0.0;
        for (int i = n - 1; i >= 0; i--)
        {
            if (cars[i].time > time)
            {
                time = cars[i].time;
                fleets++;
            }
        }

        return fleets;
    }

    private class Car(int position, double time)
    {
        public int position = position;
        public double time = time;
    }
}
