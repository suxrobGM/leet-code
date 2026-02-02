namespace LeetCode.Solutions;

public class Solution2013
{
    /// <summary>
    /// 2013. Detect Squares - Medium
    /// <a href="https://leetcode.com/problems/detect-squares">See the problem</a>
    /// </summary>
    public class DetectSquares
    {
        private readonly Dictionary<(int x, int y), int> _pointCount = [];
        private readonly List<(int x, int y)> _points = [];

        public void Add(int[] point)
        {
            var p = (point[0], point[1]);
            if (!_pointCount.ContainsKey(p))
            {
                _pointCount[p] = 0;
                _points.Add(p);
            }
            _pointCount[p]++;
        }

        public int Count(int[] point)
        {
            int qx = point[0], qy = point[1];
            int result = 0;

            foreach (var (px, py) in _points)
            {
                // Check if this could be diagonal corner (same distance in x and y)
                if (Math.Abs(qx - px) != Math.Abs(qy - py) || qx == px)
                    continue;

                // Other two corners of the square
                var corner1 = (qx, py);
                var corner2 = (px, qy);

                if (_pointCount.TryGetValue(corner1, out int c1) &&
                    _pointCount.TryGetValue(corner2, out int c2))
                {
                    result += _pointCount[(px, py)] * c1 * c2;
                }
            }

            return result;
        }
    }
}
