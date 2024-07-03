namespace LeetCode.Solutions;

public class Solution295
{
    /// <summary>
    /// 295. Find Median from Data Stream - Hard
    /// <a href="https://leetcode.com/problems/find-median-from-data-stream">See the problem</a>
    /// </summary>
    public class MedianFinder 
    {
        private readonly List<int> _list;
        
        public MedianFinder() => _list = new List<int>();

        public void AddNum(int num)
        {
            var index = _list.BinarySearch(num);
            if (index < 0)
            {
                index = ~index;
            }
            _list.Insert(index, num);
        }

        public double FindMedian()
        {
            var count = _list.Count;
            if (count % 2 == 0)
            {
                return (_list[count / 2 - 1] + _list[count / 2]) / 2.0;
            }
            return _list[count / 2];
        }
    }
}
