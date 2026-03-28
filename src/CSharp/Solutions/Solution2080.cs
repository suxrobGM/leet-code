namespace LeetCode.Solutions;

public class Solution2080
{
    /// <summary>
    /// 2080. Range Frequency Queries - Medium
    /// <a href="https://leetcode.com/problems/range-frequency-queries">See the problem</a>
    /// </summary>
    public class RangeFreqQuery
    {
        private readonly Dictionary<int, List<int>> _dict;

        public RangeFreqQuery(int[] arr)
        {
            _dict = [];

            for (var i = 0; i < arr.Length; i++)
            {
                if (!_dict.ContainsKey(arr[i]))
                {
                    _dict[arr[i]] = new List<int>();
                }

                _dict[arr[i]].Add(i);
            }
        }

        public int Query(int left, int right, int value)
        {
            if (!_dict.ContainsKey(value))
            {
                return 0;
            }

            var list = _dict[value];
            var leftIndex = list.BinarySearch(left);
            var rightIndex = list.BinarySearch(right);

            if (leftIndex < 0)
            {
                leftIndex = ~leftIndex;
            }

            if (rightIndex < 0)
            {
                rightIndex = ~rightIndex - 1;
            }

            return rightIndex - leftIndex + 1;
        }
    }
}
