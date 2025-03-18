using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1117
{
    /// <summary>
    /// 1117. Building H2O - Medium
    /// <a href="https://leetcode.com/problems/building-h2o">See the problem</a>
    /// </summary>
    public class H2O
    {
        private readonly object _lock = new();
        private int _hCount = 0;

        public void Hydrogen(Action releaseHydrogen)
        {
            lock (_lock)
            {
                while (_hCount == 2)
                {
                    Monitor.Wait(_lock);
                }

                releaseHydrogen();
                _hCount++;
                Monitor.PulseAll(_lock);
            }
        }

        public void Oxygen(Action releaseOxygen)
        {
            lock (_lock)
            {
                while (_hCount != 2)
                {
                    Monitor.Wait(_lock);
                }

                releaseOxygen();
                _hCount = 0;
                Monitor.PulseAll(_lock);
            }
        }
    }
}
