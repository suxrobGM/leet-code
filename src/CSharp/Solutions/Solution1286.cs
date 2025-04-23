using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1286
{
    /// <summary>
    /// 1286. Iterator for Combination - Medium
    /// <a href="https://leetcode.com/problems/iterator-for-combination">See the problem</a>
    /// </summary>
    public class CombinationIterator
    {
        private readonly Queue<string> _combinationsQueue;

        public CombinationIterator(string characters, int combinationLength)
        {
            _combinationsQueue = new Queue<string>();
            GenerateCombinations(characters, combinationLength, 0, new StringBuilder(), _combinationsQueue);
        }

        private void GenerateCombinations(string characters, int length, int start, StringBuilder current, Queue<string> queue)
        {
            if (current.Length == length)
            {
                queue.Enqueue(current.ToString());
                return;
            }

            for (int i = start; i < characters.Length; i++)
            {
                current.Append(characters[i]);
                GenerateCombinations(characters, length, i + 1, current, queue);
                current.Length--; // Backtrack
            }
        }

        public string Next()
        {
            return _combinationsQueue.Dequeue();
        }

        public bool HasNext()
        {
            return _combinationsQueue.Count > 0;
        }
    }
}
