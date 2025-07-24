using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1656
{
    /// <summary>
    /// 1656. Design an Ordered Stream - Easy
    /// <a href="https://leetcode.com/problems/design-an-ordered-stream">See the problem</a>
    /// </summary>
    public class OrderedStream
    {
        private string[] stream;
        private int pointer;

        /// <summary>
        /// Initializes the OrderedStream with a given size.
        /// </summary>
        /// <param name="n">The size of the stream.</param>
        public OrderedStream(int n)
        {
            stream = new string[n + 1];
            pointer = 1;
        }

        public IList<string> Insert(int idKey, string value)
        {
            stream[idKey] = value;
            var result = new List<string>();

            while (pointer < stream.Length && stream[pointer] != null)
            {
                result.Add(stream[pointer]);
                pointer++;
            }

            return result;
        }
    }
}
