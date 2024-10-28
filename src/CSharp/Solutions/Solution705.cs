namespace LeetCode.Solutions;

public class Solution705
{
    /// <summary>
    /// 705. Design HashSet - Easy
    /// <a href="https://leetcode.com/problems/design-hashset">See the problem</a>
    /// </summary>
    public class MyHashSet
    {
        private const int Capacity = 1000001;
        private readonly bool[] _hashSet;

        public MyHashSet()
        {
            _hashSet = new bool[Capacity];
        }

        public void Add(int key)
        {
            _hashSet[key] = true;
        }

        public void Remove(int key)
        {
            _hashSet[key] = false;
        }

        public bool Contains(int key)
        {
            return _hashSet[key];
        }
    }
}
