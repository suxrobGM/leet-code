namespace LeetCode.Solutions;

public class Solution706
{
    /// <summary>
    /// 706. Design HashMap - Easy
    /// <a href="https://leetcode.com/problems/design-hashmap">See the problem</a>
    /// </summary>
    public class MyHashMap
    {
        private const int Capacity = 1000001;
        private readonly int?[] _hashMap;

        public MyHashMap()
        {
            _hashMap = new int?[Capacity];
        }

        public void Put(int key, int value)
        {
            _hashMap[key] = value;
        }

        public int Get(int key)
        {
            return _hashMap[key] ?? -1;
        }

        public void Remove(int key)
        {
            _hashMap[key] = null;
        }
    }
}
