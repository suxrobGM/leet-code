namespace LeetCode.Solutions;

public class Solution478
{
    /// <summary>
    /// 478. Generate Random Point in a Circle - Medium
    /// <a href="https://leetcode.com/problems/generate-random-point-in-a-circle">See the problem</a>
    /// </summary>
    public class Solution
    {
        private readonly double _radius;
        private readonly double _xCenter;
        private readonly double _yCenter;
        private readonly Random _random;

        public Solution(double radius, double xCenter, double yCenter)
        {
            _radius = radius;
            _xCenter = xCenter;
            _yCenter = yCenter;
            _random = new Random();
        }

        public double[] RandPoint()
        {
            var angle = _random.NextDouble() * 2 * Math.PI;
            var length = Math.Sqrt(_random.NextDouble()) * _radius;

            var x = _xCenter + length * Math.Cos(angle);
            var y = _yCenter + length * Math.Sin(angle);

            return [x, y];
        }
    }
}
