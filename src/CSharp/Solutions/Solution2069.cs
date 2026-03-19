namespace LeetCode.Solutions;

public class Solution2069
{
    /// <summary>
    /// 2069. Walking Robot Simulation II - Medium
    /// <a href="https://leetcode.com/problems/walking-robot-simulation-ii">See the problem</a>
    /// </summary>
    public class Robot
    {
        private readonly int _width;
        private readonly int _height;
        private readonly int _perimeter;
        private int _pos;
        private bool _moved;

        public Robot(int width, int height)
        {
            _width = width;
            _height = height;
            _perimeter = 2 * (width + height - 2);
        }

        public void Step(int num)
        {
            _moved = true;
            _pos = (_pos + num) % _perimeter;
        }

        public int[] GetPos()
        {
            var (x, y, _) = Decode();
            return [x, y];
        }

        public string GetDir()
        {
            var (_, _, dir) = Decode();
            return dir;
        }

        private (int x, int y, string dir) Decode()
        {
            if (!_moved) return (0, 0, "East");

            if (_pos < _width)
                return (_pos, 0, _pos == 0 ? "South" : "East");

            if (_pos < _width + _height - 1)
                return (_width - 1, _pos - _width + 1, "North");

            if (_pos < 2 * _width + _height - 2)
                return (_width - 1 - (_pos - _width - _height + 2), _height - 1, "West");

            return (0, _height - 1 - (_pos - 2 * _width - _height + 3), "South");
        }
    }
}
