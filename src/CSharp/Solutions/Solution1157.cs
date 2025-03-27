using System.Text;
using LeetCode.DataStructures;

namespace LeetCode.Solutions;

public class Solution1157
{
    /// <summary>
    /// 1157. Online Majority Element In Subarray - Hard
    /// <a href="https://leetcode.com/problems/online-majority-element-in-subarray">See the problem</a>
    /// </summary>
    public class MajorityChecker
    {
        private readonly int[] _arr;
        private readonly int[] _count;
        private readonly int[] _lastIndex;
        private readonly Random _random;

        public MajorityChecker(int[] arr)
        {
            _arr = arr;
            _count = new int[20001];
            _lastIndex = new int[20001];
            _random = new Random();

            for (var i = 0; i < arr.Length; i++)
            {
                _count[arr[i]]++;
                _lastIndex[arr[i]] = i;
            }
        }

        public int Query(int left, int right, int threshold)
        {
            for (var i = 0; i < 20; i++)
            {
                var index = _random.Next(left, right + 1);
                var candidate = _arr[index];

                if (_count[candidate] < threshold)
                {
                    continue;
                }

                var count = 0;
                for (var j = left; j <= right; j++)
                {
                    if (_arr[j] == candidate)
                    {
                        count++;
                    }
                }

                if (count >= threshold)
                {
                    return candidate;
                }
            }

            return -1;
        }
    }
}
