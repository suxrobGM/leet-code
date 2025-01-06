using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution933
{
    /// <summary>
    /// 933. Number of Recent Calls - Easy
    /// <a href="https://leetcode.com/problems/number-of-recent-calls">See the problem</a>
    /// </summary>
    public class RecentCounter
    {
        private Queue<int> _queue = new();

        public int Ping(int t)
        {
            _queue.Enqueue(t);
            while (_queue.Peek() < t - 3000)
            {
                _queue.Dequeue();
            }
            return _queue.Count;
        }
    }
}
