using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution232
{
    /// <summary>
    /// 232. Implement Queue using Stacks - Easy
    /// <a href="https://leetcode.com/problems/implement-queue-using-stacks">See the problem</a>
    /// </summary>
    public class MyQueue 
    {
        private Stack<int> _input = new();
        private Stack<int> _output = new();

        public void Push(int x) 
        {
            _input.Push(x);
        }

        public int Pop() 
        {
            if (_output.Count == 0)
            {
                while (_input.Count > 0)
                {
                    _output.Push(_input.Pop());
                }
            }

            return _output.Pop();
        }

        public int Peek() 
        {
            if (_output.Count == 0)
            {
                while (_input.Count > 0)
                {
                    _output.Push(_input.Pop());
                }
            }

            return _output.Peek();
        }

        public bool Empty() 
        {
            return _input.Count == 0 && _output.Count == 0;
        }
    }
}
